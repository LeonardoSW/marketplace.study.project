using Marketplace.Domain.Entities;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<ResultModel<string>> CreatePurchaseRequestAsync(NewOrderInputModel input);
        Task ProcessNewOrderAsync(OrderEntity input);
    }
}
