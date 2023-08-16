using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOrderProductRepository
    {
        Task CommitAsync();
        Task InsertNewOrderProductsAsync(List<OrderProductEntity> products);
    }
}
