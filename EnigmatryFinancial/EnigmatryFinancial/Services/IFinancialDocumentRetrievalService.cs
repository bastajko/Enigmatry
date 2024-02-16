namespace EnigmatryFinancial.Services
{
    public interface IFinancialDocumentRetrievalService
    {
        Task<string> RetrieveDocument(Guid tenantId, Guid documentId, string productCode);
    }
}
