using Marketplace.Domain.Enums;

namespace Marketplace.Domain.Entities
{
    public class OrderEntity
    {
        public long Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public Guid OrderNumber { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public long IdUser { get; private set; }

        public OrderEntity()
        { }

        public OrderEntity(long idUser, Guid orderNumber)
        {
            IdUser = idUser;
            CreateDate = DateTime.Now;
            OrderNumber = orderNumber;
            Status = OrderStatusEnum.EmProcessamento;
        }

    }
}
