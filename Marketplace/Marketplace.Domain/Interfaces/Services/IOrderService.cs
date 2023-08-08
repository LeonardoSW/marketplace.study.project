using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<ResultModel<string>> CreatePurchaseRequestAsync();
        Task<ResultModel<string>> CreateNewOrderAsync(NewOrderInputModel input);
    }
}
