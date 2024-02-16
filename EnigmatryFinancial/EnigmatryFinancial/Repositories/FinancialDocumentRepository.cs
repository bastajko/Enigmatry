using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models;
using EnigmatryFinancial.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;

namespace EnigmatryFinancial.Repositories
{
    public class SelectedFinancialDocument
    {
        public string Currency { get; set; }
        public string Type { get; set; }
    }

    public class FinancialDocumentRepository : IFinancialDocumentRepository
    {
        private readonly AppDbContext _context;

        private readonly IProductRepository _productRepository;

        public FinancialDocumentRepository(AppDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        // TODO: Make this async
        public object RetrieveEntity(Guid entityId, string entityName, string productCode)
        {
            List<string> propertyNames = _productRepository.GetConfigurationsForEntity(productCode, entityName);

            var financialDocumentType = typeof(FinancialDocument);

            // Retrieve financial documents from the database
            var financialDocument = _context.Documents
            .Include(d => d.Transactions).Where(d => d.Id == entityId).FirstOrDefault();

            // Select properties dynamically based on the list of property names
            var result = new
                {
                    Properties = propertyNames.ToDictionary(
                        propertyName => propertyName,
                        propertyName => financialDocumentType.GetProperty(propertyName)?.GetValue(financialDocument)
                    )
                };

            // TODO: Add transactions
            result.Properties.Add();

            return result;

            /*object entity = null;
            switch (entityName)
            {
                case nameof(Transaction):
                    entity = _context.Transactions
                        .Where(e => e.Id == entityId)
                        .Select(CreateAnonymousObject(propertyNames))
                        .FirstOrDefault();
                    break;
                case nameof(Document):
                    entity = _context.Documents
                        .Where(e => e.Id == entityId)
                        .Select(CreateAnonymousObject(propertyNames))
                        .FirstOrDefault();
                    break;
                    // Add cases for other entity types as needed
            }
            return entity;
            */
        }

        /*
        private Expression<Func<T, object>> CreateAnonymousObject<T>(string[] propertyNames)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var bindings = propertyNames
                .Select(propertyName =>
                {
                    var property = typeof(T).GetProperty(propertyName);
                    if (property == null)
                    {
                        throw new ArgumentException($"Property {propertyName} not found in type {typeof(T)}");
                    }
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    return Expression.Bind(property, propertyAccess);
                });
            var anonymousType = AnonymousTypeBuilder.GetType(propertyNames);
            var anonymousObject = Expression.New(anonymousType.GetConstructor(Type.EmptyTypes));
            var memberInit = Expression.MemberInit(anonymousObject, bindings);
            return Expression.Lambda<Func<T, object>>(memberInit, parameter);
            
        }
        */

        public async Task<FinancialDocumentData> GetDocumentForProductAAsync(Guid tenantId, Guid documentId)
        {
            var retDoc = await this._context.Documents.Where(d => d.TenantId == tenantId && d.Id == documentId)
                .Select(d => new FinancialDocumentData
                {
                    AccountNumber = d.AccountNumber,
                    Balance = d.Balance,
                    Currency = d.Currency,
                    Transactions = d.Transactions.Select(t => new TransactionResponse 
                                                  { TransactionId = t.Id,
                                                    Amount = t.Amount,
                                                    Category = t.Category,
                                                    Description = t.Description,
                                                    Date = t.Date.ToString() }).ToList(),
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
