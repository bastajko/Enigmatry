using EnigmatryFinancial.Services;

namespace EnigmatryFinancial.Middlewares
{
    public class TenantWhitelistingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantWhitelistingService _tenantWhitelistingService;

        public TenantWhitelistingMiddleware(RequestDelegate next, ITenantWhitelistingService tenantWhitelistingService)
        {
            _next = next;
            _tenantWhitelistingService = tenantWhitelistingService;
        }

        public async Task Invoke(HttpContext context)
        {
            // Extract tenantId from the request
            if (!Guid.TryParse(context.Request.Query["tenantId"], out Guid tenantId))
            {
                // TODO: Add logging
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // Check if the tenant is whitelisted
            bool isWhitelisted = await _tenantWhitelistingService.IsTenantWhitelistedAsync(tenantId);
            if (!isWhitelisted)
            {
                // TODO: Add logging
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            // If tenant is whitelisted, proceed to the next middleware in the pipeline
            await _next(context);
        }
    }

}
