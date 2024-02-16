using EnigmatryFinancial.Services;
using System.Text;

namespace EnigmatryFinancial.Middlewares
{
    public class TenantWhitelistingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantService _tenantService;

        public TenantWhitelistingMiddleware(RequestDelegate next, ITenantService tenantWhitelistingService)
        {
            _next = next;
            _tenantService = tenantWhitelistingService;
        }

        public async Task Invoke(HttpContext context)
        {
            // Extract tenantId from the request
            if (!Guid.TryParse(context.Request.Query["tenantId"], out Guid tenantId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Tenant is not whitelisted.", Encoding.UTF8);
                return;
            }

            // Check if the tenant is whitelisted
            await _tenantService.AssertTenantWhitelisted(tenantId).ConfigureAwait(false);

            // If tenant is whitelisted, proceed to the next middleware in the pipeline
            await _next(context);
        }
    }

}
