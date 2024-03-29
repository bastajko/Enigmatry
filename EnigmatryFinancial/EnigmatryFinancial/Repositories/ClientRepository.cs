﻿using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities.Enums;
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

        public Task<bool> IsClientIdWhitelisted(Guid tenantId, Guid clientId)
        {
            return _context.Clients.AnyAsync(c => c.TenantId == tenantId && c.Id == clientId && c.IsWhitelisted);
        }

        public async Task<(Guid clientId, string clientVat)> GetClientIdAndClientVatAsync(Guid tenantId, Guid documentId)
        {
            try
            {
                var clientDetails = await _context.Documents
                    .Where(d => d.TenantId == tenantId && d.Id == documentId)
                    .Select(d => new { d.Client.Id, d.Client.ClientVAT })
                    .FirstOrDefaultAsync().ConfigureAwait(false);


                return (clientDetails.Id, clientDetails.ClientVAT);
            }
            catch(NullReferenceException)
            {
                throw new BadHttpRequestException($"Not able to retrieve Client Details for tenantId: {tenantId} and documentId: {documentId}", StatusCodes.Status404NotFound);
            }
        }

        public async Task<(CompanyTypeEnum companyType, string registrationNumber)> GetClientDetailsAsync(string clientVat)
        {
            var clientDetails = await _context.Clients.Where(c => c.ClientVAT == clientVat)
                .Select(c => new {c.CompanyType, c.RegistrationNumber})
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if(clientDetails == null)
            {
                throw new BadHttpRequestException($"Not able to find client for client vat: {clientVat}", StatusCodes.Status404NotFound);
            }

            return (clientDetails.CompanyType, clientDetails.RegistrationNumber);
        }
    }
}
