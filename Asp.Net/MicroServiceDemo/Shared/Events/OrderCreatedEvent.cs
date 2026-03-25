using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public Guid CorrelationId { get; set; }
        public DateTime Timestamp { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public AddressDto ShippingAddress { get; set; }

        
    }
}
