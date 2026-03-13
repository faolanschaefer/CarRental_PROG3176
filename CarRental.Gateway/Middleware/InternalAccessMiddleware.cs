namespace CarRental.Gateway.Middleware
{
    public class InternalAccessMiddleware
    {
        private const string ACCESS_KEY_HEADER_NAME = "X-Internal-Access-Key";
        private readonly RequestDelegate _next;
        private readonly string _accessKey;

        public InternalAccessMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _accessKey = config.GetValue<string>("InternalAccessKey")
                ?? throw new ArgumentNullException("Internal access key not configured.");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ACCESS_KEY_HEADER_NAME, out var extractedAccessKey) ||
                string.IsNullOrEmpty(extractedAccessKey) || extractedAccessKey != _accessKey)
            {
                context.Response.StatusCode = 401; 
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Unauthorized",
                    message = "Missing or invalid internal access key."
                });
                return;
            }
            await _next(context);
        }
    }
}
