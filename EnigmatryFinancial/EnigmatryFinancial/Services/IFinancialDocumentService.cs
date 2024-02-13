namespace EnigmatryFinancial.Services
{
    public interface IFinancialDocumentService
    {
        Task<string> RetrieveFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode);
    }
}
