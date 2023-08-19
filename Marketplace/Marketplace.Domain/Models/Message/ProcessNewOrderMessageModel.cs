using Marketplace.Domain.Models.Commons;

namespace Marketplace.Domain.Models.Message
{
    public class ProcessNewOrderMessageModel : NewOrderCommon
    {
        public Guid OrderNumber { get; set; }
    }
}
