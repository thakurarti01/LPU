using OrderServiceAPI.DTOs;

namespace OrderServiceAPI.Services
{
    public interface IOrderService
    {
        Task<Order_ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<Order_ResponseDto> GetOrderAsync(int id);
        Task UpdateOrderStatusAsync(int orderId, string status, string message = null);
        Task CompensateOrderAsync(int orderId, string reason);
    }
}
