using Shared.Events;
namespace PaymentServiceAPI.Services
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(OrderCreatedEvent orderEvent);
        Task RefundPaymentAsync(int orderId);
    }
}
