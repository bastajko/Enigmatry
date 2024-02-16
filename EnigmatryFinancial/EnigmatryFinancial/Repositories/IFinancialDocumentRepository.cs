using EnigmatryFinancial.Entities;

namespace EnigmatryFinancial.Repositories
{
    public interface IFinancialDocumentRepository
    {
        Task<FinancialDocument> GetFinancialDocumentForDocId(Guid documentId);
    }
}
