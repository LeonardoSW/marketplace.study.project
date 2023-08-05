using Marketplace.Domain.Entities;
using Marketplace.Domain.Models.Output;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductOutputModel> GetProductByIdAsync(long id);
        Task<List<ProductOutputModel>> GetProductListByNameAsync(string name);
        Task<bool> RegisterNewProductAsync(ProductEntity product);
    }
}
