using Marketplace.Domain.Models.Commons;

namespace Marketplace.Domain.Models.Output
{
    public class ProductOutputModel : ProductCommon
    {

        public ProductOutputModel()
        { }

        public ProductOutputModel(string productName, string productDescription, decimal price, short stock)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Stock = stock;
        }
    }
}
