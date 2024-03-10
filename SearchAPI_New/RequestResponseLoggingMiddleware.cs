// RequestResponseLoggingMiddleware.cs
public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log request
        _logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");

        // Capture request body if necessary
        if (context.Request.ContentLength.HasValue && context.Request.ContentLength > 0)
        {
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            _logger.LogInformation($"Request body: {requestBody}");
            context.Request.Body.Position = 0;
        }

        // Continue processing the request
        await _next(context);

        // Log response
        _logger.LogInformation($"Outgoing response: {context.Response.StatusCode}");
    }
}
