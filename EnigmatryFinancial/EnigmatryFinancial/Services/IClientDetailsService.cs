namespace EnigmatryFinancial.Services
{
    public interface IClientDetailsService
    {
        Task<(Guid clientId, string clientVat)> GetClientDetailsAsync(Guid tenantId, Guid documentId);
    }
}
