using System.Diagnostics;
using System.Text;

namespace ApiGateway.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // Log request
            await LogRequest(context);

            // Capture response
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            stopwatch.Stop();

            // Log response
            await LogResponse(context, stopwatch.ElapsedMilliseconds);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task LogRequest(HttpContext context)
        {
            var request = context.Request;
            request.EnableBuffering();

            var body = await ReadStreamBody(request.Body);

            _logger.LogInformation(
                "Request: {Method} {Path} | Headers: {@Headers} | Body: {Body}",
                request.Method,
                request.Path,
                request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                body);

            request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context, long elapsedMilliseconds)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation(
                "Response: {StatusCode} | Elapsed: {Elapsed}ms | Body: {Body}",
                context.Response.StatusCode,
                elapsedMilliseconds,
                body);
        }

        private async Task<string> ReadStreamBody(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
            return await reader.ReadToEndAsync();
        }
    }
}