namespace CarRental.Gateway.Middleware
{
    public class ApiKeyMiddleware
    {
        private const string ACCESS_KEY_HEADER_NAME = "X-API-KEY";
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _apiKey = config.GetValue<string>("ApiKey")
                ?? throw new ArgumentNullException("API key not configured.");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ACCESS_KEY_HEADER_NAME, out var extractedApiKey) ||
                string.IsNullOrEmpty(extractedApiKey) || extractedApiKey != _apiKey)
            {
                context.Response.StatusCode = 401; 
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized",
                    message = "Missing or invalid API key."
                });
                return;
            }
            await _next(context);
        }
    }
}
