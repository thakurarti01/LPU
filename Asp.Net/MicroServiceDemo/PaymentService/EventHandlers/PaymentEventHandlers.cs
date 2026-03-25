using Shared.Events;
using PaymentServiceAPI.Services;
using Shared.Infrastructure;

namespace PaymentServiceAPI.EventHandlers
{
    public class PaymentEventHandlers : IHostedService
    {
        private readonly IEventSubscriber _eventSubscriber;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentEventHandlers> _logger;

        public PaymentEventHandlers(
            IEventSubscriber eventSubscriber,
            IPaymentService paymentService,
            ILogger<PaymentEventHandlers> logger)
        {
            _eventSubscriber = eventSubscriber;
            _paymentService = paymentService;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventSubscriber.Subscribe<OrderCreatedEvent>(HandleOrderCreatedEvent);
            _eventSubscriber.Subscribe<OrderCompensationEvent>(HandleOrderCompensationEvent);

            return Task.CompletedTask;
        }

        private async Task HandleOrderCreatedEvent(OrderCreatedEvent @event)
        {
            _logger.LogInformation($"Received OrderCreatedEvent for Order {@event.OrderId}");
            await _paymentService.ProcessPaymentAsync(@event);
        }

        private async Task HandleOrderCompensationEvent(OrderCompensationEvent @event)
        {
            _logger.LogInformation($"Received OrderCompensationEvent for Order {@event.OrderId}, Reason: {@event.Reason}");
            await _paymentService.RefundPaymentAsync(@event.OrderId);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}