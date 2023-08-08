using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task ProcessNewOrderAsync(OrderEntity newOrder);
    }
}
