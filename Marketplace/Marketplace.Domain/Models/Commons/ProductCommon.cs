namespace Marketplace.Domain.Models.Commons
{
    public class ProductCommon
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public short Stock { get; set; }
    }
}
