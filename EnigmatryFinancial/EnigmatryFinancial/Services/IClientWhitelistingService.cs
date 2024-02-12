namespace EnigmatryFinancial.Services
{
    public interface IClientWhitelistingService
    {
        Task<bool> IsClientWhitelistedAsync(Guid tenantId, Guid clientId);
    }
}
