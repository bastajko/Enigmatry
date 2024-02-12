using EnigmatryFinancial.Data;

namespace EnigmatryFinancial.Repositories
{
    public class FinancialDocumentRepository
    {
        private readonly AppDbContext _context;

        FinancialDocumentRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}
