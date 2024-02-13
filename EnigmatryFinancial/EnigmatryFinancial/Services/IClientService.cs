using EnigmatryFinancial.Entities;

namespace EnigmatryFinancial.Services
{
    public interface IClientService
    {
        Task<(Guid clientId, string clientVat)> GetClientIdAndVat(Guid tenantId, Guid documentId);
        Task AssertClientWhitelisted(Guid tenantId, string clientId);
        Task<(CompanyTypeEnum companyType, string registrationNumber)> GetCompanyInfoAsync(string clientVat);
    }
}
