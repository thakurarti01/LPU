using Shared.Events;

namespace ShippingServiceAPI.Services
{
    public interface IShippingService
    {
        Task ProcessShippingAsync(PaymentProcessedEvent paymentEvent);
    }
}