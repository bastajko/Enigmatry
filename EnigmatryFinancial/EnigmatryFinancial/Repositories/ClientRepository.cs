using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnigmatryFinancial.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> IsClientIdWhitelisted(Guid tenantId, string clientId)
        {
            // TODO: Change Guid.Parse part
            return _context.Clients.AnyAsync(c => c.TenantId == tenantId && c.Id == Guid.Parse(clientId) && c.IsWhitelisted);
        }

        public async Task<(Guid clientId, string clientVat)> GetClientIdAndClientVatAsync(Guid tenantId, Guid documentId)
        {
            var clientDetails = await _context.Documents
                .Where(d => d.TenantId == tenantId && d.Id == documentId)
                .Select(d => new { d.Client.Id, d.Client.ClientVAT })
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (clientDetails == null)
            {
                throw new BadHttpRequestException("Not able to retrieve Client Details", (int)HttpStatusCode.NotFound);
            }

            return (clientDetails.Id, clientDetails.ClientVAT);
        }

        public async Task<(CompanyTypeEnum companyType, string registrationNumber)> GetClientDetailsAsync(string clientVat)
        {
            var clientDetails = await _context.Clients.Where(c => c.ClientVAT == clientVat)
                .Select(c => new {c.CompanyType, c.RegistrationNumber})
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if(clientDetails == null)
            {
                throw new BadHttpRequestException($"Not able to find client for client vat: {clientVat}", (int)HttpStatusCode.NotFound);
            }

            return (clientDetails.CompanyType, clientDetails.RegistrationNumber);
        }
    }
}
