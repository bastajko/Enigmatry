namespace EnigmatryFinancial.Http
{
    public static class HttpContextExtensions
    {
        public static Guid GetTenantId(this HttpContext httpContext)
        {
            // This is for sure going to be populated since there are checks in middleware
            _ = httpContext.Items.TryGetValue("TenantId", out object? tenantIdPotential);
            return tenantIdPotential as Guid? ?? Guid.Empty;
        }
    }
}
