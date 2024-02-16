using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Repositories
{
    public class FinancialDocumentRepository : IFinancialDocumentRepository
    {
        private readonly AppDbContext _context;

        public FinancialDocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialDocument> GetFinancialDocumentForDocId(Guid documentId)
        {

            FinancialDocument? financialDocument = await _context.Documents.Where(d => d.Id == documentId).FirstOrDefaultAsync().ConfigureAwait(false);

            if(financialDocument == null)
            {
                throw new BadHttpRequestException($"Financial Document with id {documentId} not found.", StatusCodes.Status404NotFound);
            }
            else
            {
                return financialDocument;
            }
        }
    }
}
