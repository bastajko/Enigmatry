using EnigmatryFinancial.Data;

namespace EnigmatryFinancial.Services
{
    public class ClientDetailsService
    {
        private readonly AppDbContext _dbContext;

        public ClientDetailsService(AppDbContext dbContext)
        {
            // TODO: Move this to repository
            _dbContext = dbContext;
        }

        public async Task<(Guid clientId, string clientVat)> GetClientDetailsAsync(Guid tenantId, Guid documentId)
        {
            // Retrieve ClientId and ClientVat based on TenantId and DocumentId
            var document = await _dbContext.Documents.FirstOrDefaultAsync(d => d.TenantId == tenantId && d.Id == documentId);
            if (document == null)
            {
                throw new InvalidOperationException("Document not found.");
            }

            // Assuming ClientId and ClientVat are stored in the Document entity
            return (document.ClientId, document.ClientVat);
        }
    }
}
