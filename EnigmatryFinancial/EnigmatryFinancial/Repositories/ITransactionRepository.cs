using EnigmatryFinancial.Entities;

namespace EnigmatryFinancial.Repositories
{
    public interface ITransactionRepository
    {
        Task<IReadOnlyList<Transaction>> GetTransactionsByDocId(Guid documentId);
    }
}
