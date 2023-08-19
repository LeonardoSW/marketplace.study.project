using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Message;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqSenderHandler _sender;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderService(IRabbitMqSenderHandler rabbitMqHandler, IUserRepository userRepository, IOrderProductRepository orderProductRepository, IOrderRepository orderRepository)
        {
            _sender = rabbitMqHandler;
            _userRepository = userRepository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ResultModel<string>> CreatePurchaseRequestAsync(NewOrderInputModel input)
        {
            if (!await _userRepository.CheckExistenceAsync(input.Cpf) || input.ProductIds.Any(x => x <= 0))
                return new ResultModel<string>().AddError(ServiceResources.ErroProcessarPedido);

            var orderMessageModel = new ProcessNewOrderMessageModel
            {
                Cpf = input.Cpf,
                OrderNumber = Guid.NewGuid(),
                ProductIds = input.ProductIds
            };

            return _sender.SendMessage(orderMessageModel)
                        ? new ResultModel<string>().AddResult(string.Format(ServiceResources.ProcessingOrder, $"'{orderMessageModel.OrderNumber}'"))
                        : new ResultModel<string>().AddError(ServiceResources.ErroProcessarPedido);
        }

        public async Task ProcessNewOrderAsync(ProcessNewOrderMessageModel message)
        {
            var idUser = await _userRepository.GetDataUserByCpf(x => x.Id, message.Cpf);
            var newOrder = new OrderEntity(idUser, message.OrderNumber);
            await _orderRepository.ProcessNewOrderAsync(newOrder);

            await ProcessOrderProductsAsync(message.ProductIds, newOrder.OrderNumber);

            await _orderRepository.CommitAsync();
            await _orderProductRepository.CommitAsync();
        }

        #region private methods
        private async Task ProcessOrderProductsAsync(List<long> productIds, Guid orderNumber)
        {
            var orderProducts = new List<OrderProductEntity>();
            productIds.ForEach(x =>
            {
                orderProducts.Add(new OrderProductEntity(orderNumber, x));
            });

            await _orderProductRepository.InsertNewOrderProductsAsync(orderProducts);
        }
        #endregion
    }
}
