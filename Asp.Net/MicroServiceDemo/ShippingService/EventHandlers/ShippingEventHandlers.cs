using Shared.Events;
using Shared.Infrastructure;
using ShippingServiceAPI.Services;

namespace ShippingServiceAPI.EventHandlers
{
    public class ShippingEventHandlers : IHostedService
    {
        private readonly IEventSubscriber _eventSubscriber;
        private readonly IShippingService _shippingService;
        private readonly ILogger<ShippingEventHandlers> _logger;

        public ShippingEventHandlers(
            IEventSubscriber eventSubscriber,
            IShippingService shippingService,
            ILogger<ShippingEventHandlers> logger)
        {
            _eventSubscriber = eventSubscriber;
            _shippingService = shippingService;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventSubscriber.Subscribe<PaymentProcessedEvent>(HandlePaymentProcessedEvent);

            return Task.CompletedTask;
        }

        private async Task HandlePaymentProcessedEvent(PaymentProcessedEvent @event)
        {
            _logger.LogInformation($"Received PaymentProcessedEvent for Order {@event.OrderId}");
            await _shippingService.ProcessShippingAsync(@event);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}