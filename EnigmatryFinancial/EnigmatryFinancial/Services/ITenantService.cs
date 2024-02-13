namespace EnigmatryFinancial.Services
{
    public interface ITenantService
    {
        Task AssertTenantWhitelisted(Guid tenantId);
    }

}
