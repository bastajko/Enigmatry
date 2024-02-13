﻿using EnigmatryFinancial.Services;

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
                // TODO: Add logging
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // Check if the tenant is whitelisted
            _tenantService.AssertTenantWhitelisted(tenantId);

            // If tenant is whitelisted, proceed to the next middleware in the pipeline
            await _next(context);
        }
    }

}
