using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Text.Json;

namespace ApiGateway.Aggregators
{
    public class OrderDetailsAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var orderResponse = responses[0];
            var paymentResponse = responses[1];
            var shippingResponse = responses[2];

            var orderContent = await GetContent(orderResponse);
            var paymentContent = await GetContent(paymentResponse);
            var shippingContent = await GetContent(shippingResponse);

            var aggregatedResult = new
            {
                Order = orderContent,
                Payment = paymentContent,
                Shipping = shippingContent,
                Timestamp = DateTime.UtcNow
            };

            var content = JsonSerializer.Serialize(aggregatedResult);
            var stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }

        private async Task<object> GetContent(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var content = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            if (string.IsNullOrEmpty(content))
                return null;

            return JsonSerializer.Deserialize<object>(content);
        }
    }
}