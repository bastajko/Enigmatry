namespace EnigmatryFinancial.Repositories
{
    public interface ITenantRepository
    {
        Task<bool> IsTenantWhitelisted(Guid tenantId);
    }
}
