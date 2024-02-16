using System.Text;

namespace EnigmatryFinancial.Middlewares
{
    public class TenantIdMiddleware
    {
        private readonly ILogger<TenantIdMiddleware> _logger;
        private readonly RequestDelegate _next;

        public TenantIdMiddleware(RequestDelegate next, ILogger<TenantIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.StartsWithSegments("/swagger-ui"))
            {
                await _next(context);
                return;
            }
            // Retrieve tenant ID from the request headers
            string tenantIdHeader = context.Request.Headers["TenantId"].ToString();

            // Validation
            if (string.IsNullOrEmpty(tenantIdHeader) || !Guid.TryParse(tenantIdHeader, out Guid tenantId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Invalid or missing TenantId header.", Encoding.UTF8).ConfigureAwait(false);
                _logger.LogError("Invalid or missing TenantId header.");
                return;
            }

            // Store the tenant ID in the HttpContext for later use
            context.Items["TenantId"] = tenantId;

            await _next(context);
        }
    }
}
