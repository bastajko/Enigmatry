using EnigmatryFinancial.Entities.Enums;
using EnigmatryFinancial.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnigmatryFinancial.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<(Guid clientId, string clientVat)> GetClientIdAndVat(Guid tenantId, Guid documentId)
        {
            return await _clientRepository.GetClientIdAndClientVatAsync(tenantId, documentId).ConfigureAwait(false);
        }

        public async Task AssertClientWhitelisted(Guid tenantId, Guid clientId)
        {

            if(!(await _clientRepository.IsClientIdWhitelisted(tenantId, clientId).ConfigureAwait(false)))
            {
                throw new BadHttpRequestException($"Client with clientId: {clientId} isn't whitelisted", StatusCodes.Status403Forbidden);
            }
        }

        public async Task<(CompanyTypeEnum companyType, string registrationNumber)> GetCompanyInfoAsync(string clientVat)
        {
            return await this._clientRepository.GetClientDetailsAsync(clientVat).ConfigureAwait(false);
        }
    }
}
