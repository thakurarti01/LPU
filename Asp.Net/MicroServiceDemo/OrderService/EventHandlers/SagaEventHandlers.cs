using Shared.Events;
using OrderServiceAPI.Services;
using Shared.Infrastructure;

namespace OrderServiceAPI.EventHandlers
{
    public class SagaEventHandlers : IHostedService
    {
        private readonly IEventSubscriber _eventSubscriber;
        private readonly IEventPublisher _eventPublisher;
        private readonly IOrderService _orderService;
        private readonly ILogger<SagaEventHandlers> _logger;

        public SagaEventHandlers(
            IEventSubscriber eventSubscriber,
            IEventPublisher eventPublisher,
            IOrderService orderService,
            ILogger<SagaEventHandlers> logger)
        {
            _eventSubscriber = eventSubscriber;
            _eventPublisher = eventPublisher;
            _orderService = orderService;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventSubscriber.Subscribe<PaymentProcessedEvent>(HandlePaymentProcessedEvent);
            _eventSubscriber.Subscribe<ShippingProcessedEvent>(HandleShippingProcessedEvent);
            _eventSubscriber.Subscribe<PaymentFailedEvent>(HandlePaymentFailedEvent);

            return Task.CompletedTask;
        }

        private async Task HandlePaymentProcessedEvent(PaymentProcessedEvent @event)
        {
            _logger.LogInformation($"Received PaymentProcessedEvent for Order {@event.OrderId}, Success: {@event.IsSuccess}");

            if (@event.IsSuccess)
            {
                await _orderService.UpdateOrderStatusAsync(@event.OrderId, "PaymentCompleted");
                // Payment successful - order continues
            }
            else
            {
                await _orderService.UpdateOrderStatusAsync(@event.OrderId, "PaymentFailed", @event.FailureReason);
                // Payment failed - no need to compensate as payment wasn't completed
            }
        }

        private async Task HandleShippingProcessedEvent(ShippingProcessedEvent @event)
        {
            _logger.LogInformation($"Received ShippingProcessedEvent for Order {@event.OrderId}, Success: {@event.IsSuccess}");

            if (@event.IsSuccess)
            {
                await _orderService.UpdateOrderStatusAsync(@event.OrderId, "Shipped");
                // Order completed successfully
            }
            else
            {
                await _orderService.UpdateOrderStatusAsync(@event.OrderId, "ShippingFailed", @event.FailureReason);
                // Compensation needed - payment needs to be reversed
                var compensationEvent = new OrderCompensationEvent
                {
                    CorrelationId = @event.CorrelationId,
                    Timestamp = DateTime.UtcNow,
                    OrderId = @event.OrderId,
                    Reason = @event.FailureReason
                };

                // Publish compensation event
                await _eventPublisher.PublishAsync(compensationEvent);
            }
        }

        private async Task HandlePaymentFailedEvent(PaymentFailedEvent @event)
        {
            _logger.LogInformation($"Received PaymentFailedEvent for Order {@event.OrderId}, Reason: {@event.Reason}");
            await _orderService.UpdateOrderStatusAsync(@event.OrderId, "PaymentFailed", @event.Reason);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
