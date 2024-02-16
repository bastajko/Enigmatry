using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models;
using EnigmatryFinancial.Models.Response;
using System.Reflection.Metadata;

namespace EnigmatryFinancial.Repositories
{
    public interface IFinancialDocumentRepository
    {
        object RetrieveEntity(Guid entityId, string entityName, string productCode);

        Task<FinancialDocumentData> GetDocumentForProductAAsync(Guid tenantId, Guid documentId);

        Task<FinancialDocumentData> GetDocumentForProductBAsync(Guid tenantId, Guid documentId);
    }
}
