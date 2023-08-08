using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqSender _rabbitMqHandler;
        private readonly IUserRepository _userRepository;

        public OrderService(IRabbitMqSender rabbitMqHandler, IUserRepository userRepository)
        {
            _rabbitMqHandler = rabbitMqHandler;
            _userRepository = userRepository;
        }

        public Task<ResultModel<string>> CreatePurchaseRequestAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<string>> CreateNewOrderAsync(NewOrderInputModel input)
        {
            if (!await _userRepository.CheckExistenceAsync(input.Cpf) || input.IdsProducts.Any(x => x is 0))
                return new ResultModel<string>().AddError(ServiceResources.ErroProcessarPedido);

            _rabbitMqHandler.SendMessage(input);
            return new ResultModel<string>().AddResult(ServiceResources.PedidoEmProcessamento);
        }
    }
}
