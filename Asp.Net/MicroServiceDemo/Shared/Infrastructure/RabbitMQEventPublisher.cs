using System.Text;
using System.Text.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Shared.Events;
using RabbitMQ.Client.Events;

namespace Shared.Infrastructure
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event) where T : IEvent;
    }

    public interface IEventSubscriber
    {
        void Subscribe<T>(Func<T, Task> handler) where T : IEvent;
    }

    public class RabbitMQEventPublisher : IEventPublisher, IEventSubscriber, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName;
        private readonly ILogger<RabbitMQEventPublisher> _logger;
        private readonly Dictionary<string, List<Delegate>> _handlers = new();


        public RabbitMQEventPublisher(IConfiguration configuration, ILogger<RabbitMQEventPublisher> logger)
        {
           
            _logger = logger;
            var rabbitMQConfig = configuration.GetSection("RabbitMQ");
            _exchangeName = rabbitMQConfig["ExchangeName"] ?? "microservice_demo_exchange";

            var factory = new ConnectionFactory
            {
                HostName = rabbitMQConfig["HostName"] ?? "localhost",
                UserName = rabbitMQConfig["UserName"] ?? "guest",
                Password = rabbitMQConfig["Password"] ?? "guest",
                Port = int.Parse(rabbitMQConfig["Port"] ?? "5672")
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare exchange
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic, durable: true);

            _logger.LogInformation($"RabbitMQ connection established. Exchange: {_exchangeName}");
        }

        public async Task PublishAsync<T>(T @event) where T : IEvent
        {
            var eventType = typeof(T).Name;
            var routingKey = eventType;

            var message = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: _exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: body);

            _logger.LogInformation($"Published event {eventType} with CorrelationId: {@event.CorrelationId}");
            await Task.CompletedTask;
        }

        public void Subscribe<T>(Func<T, Task> handler) where T : IEvent
        {
            var eventType = typeof(T).Name;
            var queueName = $"{eventType}_{Guid.NewGuid():N}";

            // Declare queue
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);

            // Bind queue to exchange
            _channel.QueueBind(queueName, _exchangeName, eventType);

            // Store handler
            if (!_handlers.ContainsKey(eventType))
                _handlers[eventType] = new List<Delegate>();

            _handlers[eventType].Add(handler);

            // Start consuming
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    var @event = JsonSerializer.Deserialize<T>(message);
                    if (@event != null)
                    {
                        await handler(@event);
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error processing event {eventType}");
                    _channel.BasicNack(ea.DeliveryTag, false, true);
                }
            };

            _channel.BasicConsume(queueName, autoAck: false, consumer: consumer);
            _logger.LogInformation($"Subscribed to event {eventType} on queue {queueName}");
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}