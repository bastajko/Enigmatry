namespace EnigmatryFinancial.Services
{
    public interface ITenantWhitelistingService
    {
        Task<bool> IsTenantWhitelistedAsync(Guid tenantId);
    }

}
