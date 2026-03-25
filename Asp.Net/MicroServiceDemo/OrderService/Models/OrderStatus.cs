namespace OrderServiceAPI.Models
{
    public enum OrderStatus
    {
        Pending,
        PaymentPending,
        PaymentCompleted,
        PaymentFailed,
        ShippingPending,
        Shipped,
        Completed,
        Cancelled
    }
}
