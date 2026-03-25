using Microsoft.EntityFrameworkCore;
using ShippingServiceAPI.Data;
using ShippingServiceAPI.Models;
using Shared.Events;
using Shared.Infrastructure;


namespace ShippingServiceAPI.Services
{
    public class ShippingService : IShippingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILogger<ShippingService> _logger;

        public ShippingService(
            ApplicationDbContext context,
            IEventPublisher eventPublisher,
            ILogger<ShippingService> logger)
        {
            _context = context;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public async Task ProcessShippingAsync(PaymentProcessedEvent paymentEvent)
        {
            if (!paymentEvent.IsSuccess)
            {
                _logger.LogInformation($"Payment failed for Order {paymentEvent.OrderId}, skipping shipping");
                return;
            }

            _logger.LogInformation($"Processing shipping for Order {paymentEvent.OrderId}");

            // For demo purposes, we need to get order details from somewhere
            // In a real application, you'd have an API call to Order Service
            // or have stored the order details in a database

            var shipment = new Shipment
            {
                OrderId = paymentEvent.OrderId,
                Status = ShipmentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();

            // Simulate shipping processing
            bool isSuccess = await SimulateShippingProcessing(paymentEvent.OrderId);

            var shippingProcessedEvent = new ShippingProcessedEvent
            {
                CorrelationId = paymentEvent.CorrelationId,
                Timestamp = DateTime.UtcNow,
                OrderId = paymentEvent.OrderId,
                IsSuccess = isSuccess,
                TrackingNumber = isSuccess ? $"TRK{Guid.NewGuid():N}".Substring(0, 12).ToUpper() : null,
                FailureReason = isSuccess ? null : "Shipping service unavailable"
            };

            if (isSuccess)
            {
                shipment.Status = ShipmentStatus.Processed;
                shipment.TrackingNumber = shippingProcessedEvent.TrackingNumber;
                shipment.ShippedAt = DateTime.UtcNow;
                _logger.LogInformation($"Shipping successful for Order {paymentEvent.OrderId}, Tracking: {shipment.TrackingNumber}");
            }
            else
            {
                shipment.Status = ShipmentStatus.Failed;
                shipment.FailureReason = shippingProcessedEvent.FailureReason;
                _logger.LogWarning($"Shipping failed for Order {paymentEvent.OrderId}: {shippingProcessedEvent.FailureReason}");
            }

            await _context.SaveChangesAsync();

            // Publish the shipping processed event
            await _eventPublisher.PublishAsync(shippingProcessedEvent);
        }

        private async Task<bool> SimulateShippingProcessing(int orderId)
        {
            // Simulate some async processing time
            await Task.Delay(1000);

            // For demo purposes, let's make shipping succeed 90% of the time
            var random = new Random();
            bool isSuccess = random.NextDouble() > 0.1; // 90% success rate

            return isSuccess;
        }
    }
}