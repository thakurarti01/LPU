using Microsoft.EntityFrameworkCore;
using PaymentServiceAPI.Data;
using PaymentServiceAPI.Models;
using Shared.Events;
using Shared.Infrastructure;

namespace PaymentServiceAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(
            ApplicationDbContext context,
            IEventPublisher eventPublisher,
            ILogger<PaymentService> logger)
        {
            _context = context;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public async Task ProcessPaymentAsync(OrderCreatedEvent orderEvent)
        {
            _logger.LogInformation($"Processing payment for Order {orderEvent.OrderId}, Amount: {orderEvent.TotalAmount}");

            var payment = new Payment
            {
                OrderId = orderEvent.OrderId,
                Amount = orderEvent.TotalAmount,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            // Simulate payment processing (can be successful or fail)
            bool isSuccess = await SimulatePaymentProcessing(orderEvent.OrderId);

            var paymentProcessedEvent = new PaymentProcessedEvent
            {
                CorrelationId = orderEvent.CorrelationId,
                Timestamp = DateTime.UtcNow,
                OrderId = orderEvent.OrderId,
                IsSuccess = isSuccess,
                TransactionId = isSuccess ? Guid.NewGuid().ToString() : null,
                FailureReason = isSuccess ? null : "Insufficient funds"
            };

            if (isSuccess)
            {
                payment.Status = PaymentStatus.Processed;
                payment.TransactionId = paymentProcessedEvent.TransactionId;
                payment.ProcessedAt = DateTime.UtcNow;
                _logger.LogInformation($"Payment successful for Order {orderEvent.OrderId}");
            }
            else
            {
                payment.Status = PaymentStatus.Failed;
                payment.FailureReason = paymentProcessedEvent.FailureReason;
                _logger.LogWarning($"Payment failed for Order {orderEvent.OrderId}: {paymentProcessedEvent.FailureReason}");
            }

            await _context.SaveChangesAsync();

            // Publish the payment processed event
            await _eventPublisher.PublishAsync(paymentProcessedEvent);
        }

        public async Task RefundPaymentAsync(int orderId)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.OrderId == orderId);

            if (payment != null && payment.Status == PaymentStatus.Processed)
            {
                payment.Status = PaymentStatus.Refunded;
                payment.ProcessedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Payment refunded for Order {orderId}, Transaction: {payment.TransactionId}");
            }
        }

        private async Task<bool> SimulatePaymentProcessing(int orderId)
        {
            // Simulate some async processing time
            await Task.Delay(1000);

            // For demo purposes, let's make payments succeed 80% of the time
            // You can modify this logic based on your requirements
            var random = new Random();
            bool isSuccess = random.NextDouble() > 0.2; // 80% success rate

            return isSuccess;
        }
    }
}