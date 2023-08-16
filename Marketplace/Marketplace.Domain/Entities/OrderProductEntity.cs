namespace Marketplace.Domain.Entities
{
    public class OrderProductEntity
    {
        public long Id { get; private set; }
        public Guid OrderNumber { get; private set; }
        public long IdProduct { get; private set; }

        public OrderProductEntity()
        { }

        public OrderProductEntity(Guid orderNumber, long idProduct)
        {
            OrderNumber = orderNumber;
            IdProduct = idProduct;
        }
    }
}
