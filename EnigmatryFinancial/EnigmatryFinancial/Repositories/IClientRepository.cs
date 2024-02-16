using EnigmatryFinancial.Entities.Enums;

namespace EnigmatryFinancial.Repositories
{
    public interface IClientRepository
    {
        Task<bool> IsClientIdWhitelisted(Guid tenantId, Guid clientId);
        Task<(Guid clientId, string clientVat)> GetClientIdAndClientVatAsync(Guid tenantId, Guid documentId);
        Task<(CompanyTypeEnum companyType, string registrationNumber)> GetClientDetailsAsync(string clientVat);
    }
}
