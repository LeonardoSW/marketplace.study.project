using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Output;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface IProductService
    {
        ResultModel<ProductOutputModel> GetProductByIdAsync(long id);
        Task<ResultModel<List<ProductOutputModel>>> GetProductListByNameAsync(string nameProduct);
        Task<ResultModel<string>> RegisterNewProductAsync(NewProductInputModel input);
    }
}
