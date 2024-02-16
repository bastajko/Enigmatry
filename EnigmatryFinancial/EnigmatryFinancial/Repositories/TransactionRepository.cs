using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Transaction>> GetTransactionsByDocId(Guid documentId)
        {
            IReadOnlyList<Transaction> transactions = await _context.Transactions.Where(t => t.FinancialDocumentId == documentId).ToListAsync().ConfigureAwait(false);

            return transactions;
        }
    }
}
