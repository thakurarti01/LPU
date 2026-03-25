using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ApiGateway.Aggregators
{
    /// <summary>
    /// Aggregates payment and order information for a specific order
    /// Combines data from Payment Service and Order Service
    /// </summary>
    public class PaymentOrderAggregator : IDefinedAggregator
    {
        private readonly ILogger<PaymentOrderAggregator> _logger;

        public PaymentOrderAggregator(ILogger<PaymentOrderAggregator> logger)
        {
            _logger = logger;
        }

        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            _logger.LogInformation("Starting Payment-Order aggregation");

            if (responses == null || responses.Count == 0)
            {
                _logger.LogWarning("No responses received for aggregation");
                return CreateErrorResponse("No responses received from downstream services");
            }

            // Responses order: [0] = Payment Service, [1] = Order Service
            var paymentResponse = responses.Count > 0 ? responses[0] : null;
            var orderResponse = responses.Count > 1 ? responses[1] : null;

            // Parse responses
            var paymentData = await ParseResponse(paymentResponse);
            var orderData = await ParseResponse(orderResponse);

            // Check for errors
            var errors = new List<string>();

            if (paymentResponse?.Response.StatusCode.ToString() != HttpStatusCode.OK.ToString())
            {
                errors.Add($"Payment service returned status: {paymentResponse?.Response.StatusCode}");
                _logger.LogWarning("Payment service error: {StatusCode}", paymentResponse?.Response.StatusCode);
            }

            if (orderResponse?.Response.StatusCode.ToString() != HttpStatusCode.OK.ToString())
            {
                errors.Add($"Order service returned status: {orderResponse?.Response.StatusCode}");
                _logger.LogWarning("Order service error: {StatusCode}", orderResponse?.Response.StatusCode);
            }

            // Create aggregated result
            var aggregatedResult = new
            {
                Order = orderData,
                Payment = paymentData,
                Status = DetermineOverallStatus(paymentData, orderData),
                Timestamp = DateTime.UtcNow,
                CorrelationId = GetCorrelationId(paymentResponse ?? orderResponse),
                Errors = errors.Count > 0 ? errors : null
            };

            // Serialize to JSON
            var json = JsonSerializer.Serialize(aggregatedResult, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var statusCode = errors.Count > 0 ? HttpStatusCode.MultiStatus : HttpStatusCode.OK;

            _logger.LogInformation("Payment-Order aggregation completed with status: {StatusCode}", statusCode);

            return new DownstreamResponse(content, statusCode,
                new List<KeyValuePair<string, IEnumerable<string>>>(),
                "PaymentOrderAggregation");
        }

        private async Task<object?> ParseResponse(HttpContext? context)
        {
            if (context == null)
                return null;

            try
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var content = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                if (string.IsNullOrEmpty(content))
                    return null;

                return JsonSerializer.Deserialize<object>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing response content");
                return new { Error = "Failed to parse response" };
            }
        }

        private string DetermineOverallStatus(object? paymentData, object? orderData)
        {
            // Try to extract status from payment data
            var paymentStatus = ExtractStatus(paymentData);
            var orderStatus = ExtractStatus(orderData);

            if (string.IsNullOrEmpty(paymentStatus) && string.IsNullOrEmpty(orderStatus))
                return "Unknown";

            if (paymentStatus == "Failed" || orderStatus == "Failed" ||
                paymentStatus == "Cancelled" || orderStatus == "Cancelled")
                return "Failed";

            if (paymentStatus == "Processed" && orderStatus == "Completed")
                return "Completed";

            if (paymentStatus == "Processed" && orderStatus == "Shipped")
                return "Shipped";

            if (paymentStatus == "Pending" || orderStatus == "Pending" ||
                paymentStatus == "PaymentPending")
                return "Pending";

            return "Processing";
        }

        private string ExtractStatus(object? data)
        {
            if (data == null)
                return string.Empty;

            try
            {
                var jsonElement = (JsonElement)data;

                // Try to find status in response
                if (jsonElement.TryGetProperty("status", out var statusElement))
                {
                    return statusElement.GetString() ?? string.Empty;
                }

                if (jsonElement.TryGetProperty("paymentStatus", out var paymentStatus))
                {
                    return paymentStatus.GetString() ?? string.Empty;
                }

                if (jsonElement.TryGetProperty("orderStatus", out var orderStatus))
                {
                    return orderStatus.GetString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error extracting status from response");
            }

            return string.Empty;
        }

        private string GetCorrelationId(HttpContext? context)
        {
            if (context == null)
                return Guid.NewGuid().ToString();

            if (context.Request.Headers.TryGetValue("X-Correlation-Id", out var correlationId))
                return correlationId.ToString();

            return Guid.NewGuid().ToString();
        }

        private DownstreamResponse CreateErrorResponse(string message)
        {
            var errorResponse = new
            {
                Error = message,
                Timestamp = DateTime.UtcNow,
                CorrelationId = Guid.NewGuid().ToString()
            };

            var json = JsonSerializer.Serialize(errorResponse);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return new DownstreamResponse(content, HttpStatusCode.BadRequest,
                new List<KeyValuePair<string, IEnumerable<string>>>(), "AggregationError");
        }
    }
}