using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class PaymentFailedEvent : IEvent
    {
        public Guid CorrelationId { get; set; }
        public DateTime Timestamp { get; set; }
        public int OrderId { get; set; }
        public string Reason { get; set; }
    }
}
