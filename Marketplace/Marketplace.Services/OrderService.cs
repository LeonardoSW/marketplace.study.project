using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRabbitMqSender _rabbitMqHandler;

        public OrderService(IRabbitMqSender rabbitMqHandler)
        {
            _rabbitMqHandler = rabbitMqHandler;
        }

        public Task<ResultModel<string>> CreatePurchaseRequestAsync()
        {
            throw new NotImplementedException();
        }

        public void Teste(string message)
        {
            _rabbitMqHandler.SendMessage(message);
        }
    }
}
