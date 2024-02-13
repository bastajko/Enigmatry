using EnigmatryFinancial.Data;
using EnigmatryFinancial.Models;
using EnigmatryFinancial.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnigmatryFinancial.Repositories
{
    public class FinancialDocumentRepository : IFinancialDocumentRepository
    {
        private readonly AppDbContext _context;

        public FinancialDocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialDocumentData> GetDocumentForProductAAsync(Guid tenantId, Guid documentId)
        {
            var retDoc = await this._context.Documents.Where(d => d.TenantId == tenantId && d.Id == documentId)
                .Select(d => new FinancialDocumentData
                {
                    AccountNumber = d.AccountNumber,
                    Balance = d.Balance,
                    Currency = d.Currency,
                    Transactions = (IReadOnlyList<TransactionResponse>)d.Transactions.ToList(),
                })
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if(retDoc == null)
            {
                throw new BadHttpRequestException($"Not able to find document for id: {documentId}", (int)HttpStatusCode.NotFound);
            }

            return retDoc;
        }

        public async Task<FinancialDocumentData> GetDocumentForProductBAsync(Guid tenantId, Guid documentId)
        {
            var retDoc = await this._context.Documents.Where(d => d.TenantId == tenantId && d.Id == documentId)
               .Select(d => new FinancialDocumentDataExtended
               {
                   AccountNumber = d.AccountNumber,
                   Balance = d.Balance,
                   Currency = d.Currency,
                   Transactions = (IReadOnlyList<TransactionResponse>)d.Transactions.ToList(),
                   // TODO: add properties
                   Comments = "",
                   InvoiceNumber = ""
               })
               .FirstOrDefaultAsync().ConfigureAwait(false);

            if (retDoc == null)
            {
                throw new BadHttpRequestException($"Not able to find document for id: {documentId}", (int)HttpStatusCode.NotFound);
            }

            return retDoc;
        }
    }
}
