using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.DTOs;
using OrderServiceAPI.Models;
using Shared.Events;
using Shared.Infrastructure;


namespace OrderServiceAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            ApplicationDbContext context,
            IEventPublisher eventPublisher,
            ILogger<OrderService> logger)
        {
            _context = context;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public async Task<Order_ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                UserId = createOrderDto.UserId,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                Items = createOrderDto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList(),
                ShippingAddress = new Address
                {
                    Street = createOrderDto.ShippingAddress.Street,
                    City = createOrderDto.ShippingAddress.City,
                    State = createOrderDto.ShippingAddress.State,
                    Country = createOrderDto.ShippingAddress.Country,
                    ZipCode = createOrderDto.ShippingAddress.ZipCode
                }
            };

            order.TotalAmount = order.Items.Sum(i => i.Quantity * i.UnitPrice);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Order created with ID: {order.Id}");

            // Publish OrderCreatedEvent to start the saga
            var orderCreatedEvent = new OrderCreatedEvent
            {
                CorrelationId = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                OrderId = order.Id,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                Items = createOrderDto.Items.Select(x => new Shared.Events.OrderItemDto
                {
                    ProductId = x.ProductId,
                    ProductName= x.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList(),
                ShippingAddress = createOrderDto.ShippingAddress == null ? null : new Shared.Events.AddressDto()
                {
                    Street = createOrderDto.ShippingAddress.Street,
                    City = createOrderDto.ShippingAddress.City,
                    State = createOrderDto.ShippingAddress.State,
                    ZipCode = createOrderDto.ShippingAddress.ZipCode,
                    Country = createOrderDto.ShippingAddress.Country
                }
            };

            await _eventPublisher.PublishAsync(orderCreatedEvent);

            // Update order status
            await UpdateOrderStatusAsync(order.Id, OrderStatus.PaymentPending.ToString());

            return MapToResponseDto(order);
        }

        public async Task<Order_ResponseDto> GetOrderAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                throw new KeyNotFoundException($"Order with ID {id} not found");

            return MapToResponseDto(order);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status, string message = null)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = Enum.Parse<OrderStatus>(status);
                order.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Order {orderId} status updated to {status}. Message: {message}");
            }
        }

        public async Task CompensateOrderAsync(int orderId, string reason)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null && order.Status != OrderStatus.Cancelled)
            {
                order.Status = OrderStatus.Cancelled;
                order.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogWarning($"Order {orderId} compensated (cancelled). Reason: {reason}");
            }
        }

        private Order_ResponseDto MapToResponseDto(Order order)
        {
            return new Order_ResponseDto
            {
                Id = order.Id,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt,
                Items = order.Items.Select(i => new OrderServiceAPI.DTOs.OrderItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList(),
                ShippingAddress = order.ShippingAddress != null ? new OrderServiceAPI.DTOs.AddressDto
                {
                    Street = order.ShippingAddress.Street,
                    City = order.ShippingAddress.City,
                    State = order.ShippingAddress.State,
                    Country = order.ShippingAddress.Country,
                    ZipCode = order.ShippingAddress.ZipCode
                } : null
            };
        }
    }
}