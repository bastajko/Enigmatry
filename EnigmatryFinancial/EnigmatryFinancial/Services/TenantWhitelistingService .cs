namespace EnigmatryFinancial.Services
{
    public class TenantWhitelistingService : ITenantWhitelistingService
    {
        private readonly HashSet<Guid> _whitelistedTenants = new HashSet<Guid>
    {
        // Hardcoded list of whitelisted tenant IDs
        // TODO: Fetch this list from a database
        Guid.NewGuid(),
        Guid.NewGuid()
    };

        public Task<bool> IsTenantWhitelistedAsync(Guid tenantId)
        {
            return Task.FromResult(_whitelistedTenants.Contains(tenantId));
        }
    }
}
