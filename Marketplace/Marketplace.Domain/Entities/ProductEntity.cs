using Marketplace.Domain.Enums;

namespace Marketplace.Domain.Entities
{
    public class ProductEntity
    {
        public long? Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public short Stock { get; private set; }
        public decimal Price { get; private set; }
        public ProductStatus Status { get; private set; }

        public ProductEntity()
        { }

        public ProductEntity(string name, string description, short stock, decimal price)
        {
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Status = ProductStatus.Active;
        }
    }
}
