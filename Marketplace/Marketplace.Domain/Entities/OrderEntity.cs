using Marketplace.Domain.Enums;

namespace Marketplace.Domain.Entities
{
    public class OrderEntity
    {
        public long? Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public Guid OrderNumber { get; private set; }
        public OrderStatusEnum Status { get; private set; }

        public OrderEntity()
        {
            CreateDate = DateTime.Now;
            OrderNumber = Guid.NewGuid();
            Status = OrderStatusEnum.EmProcessamento;
        }
    }
}
