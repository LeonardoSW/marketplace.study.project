using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<ResultModel<string>> CreatePurchaseRequestAsync();
        void Teste(string message);
    }
}
