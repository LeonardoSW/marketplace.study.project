using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Input;
using Marketplace.Domain.Models.Output;
using Marketplace.Domain.Models.Response;

namespace Marketplace.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResultModel<ProductOutputModel>> GetProductByIdAsync(long id)
            => new ResultModel<ProductOutputModel>().AddResult(await _productRepository.GetProductByIdAsync(id));

        public async Task<ResultModel<List<ProductOutputModel>>> GetProductListByNameAsync(string nameProduct)
            => new ResultModel<List<ProductOutputModel>>().AddResult(await _productRepository.GetProductListByNameAsync(nameProduct));

        public async Task<ResultModel<string>> RegisterNewProductAsync(NewProductInputModel input)
        {
            var newProduct = new ProductEntity(input.ProductName, input.ProductDescription, input.Stock, input.Price);

            return (await _productRepository.RegisterNewProductAsync(newProduct))
                          ? new ResultModel<string>().AddResult(ServiceResources.ProductRegistred)
                          : new ResultModel<string>().AddError(ServiceResources.ProductRegisterFail);
        }
    }
}
