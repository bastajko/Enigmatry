using EnigmatryFinancial.Entities.Enums;
using System.Net;

namespace EnigmatryFinancial.Services
{
    public class FinancialDocumentRetrievalService : IFinancialDocumentRetrievalService
    {
        private readonly IProductService _productService;
        private readonly ITenantService _tenantService;
        private readonly IClientService _clientService;
        private readonly IFinancialDocumentService _financialDocumentService;

        public FinancialDocumentRetrievalService(
            IProductService productService,
            ITenantService tenantService,
            IClientService clientService,
            IFinancialDocumentService financialDocumentService)
        {
            _productService = productService;
            _tenantService = tenantService;
            _clientService = clientService;
            _financialDocumentService = financialDocumentService;
        }
        public async Task<string> RetrieveDocument(Guid tenantId, Guid documentId, string productCode)
        {
            // Step 1: Validate Product Code
            await _productService.AssertProductSupported(productCode).ConfigureAwait(false);

            // Step 2: Tenant ID Whitelisting
            await _tenantService.AssertTenantWhitelisted(tenantId).ConfigureAwait(false);

            // Step 3: Client ID Whitelisting
            (Guid clientId, string clientVat) = await _clientService.GetClientIdAndVat(tenantId, documentId).ConfigureAwait(false);
            
            await _clientService.AssertClientWhitelisted(tenantId, clientId).ConfigureAwait(false);

            // Step 4: Fetch Additional Client Information
            (CompanyTypeEnum companyType, string registrationNumber) companyInfo = await _clientService.GetCompanyInfoAsync(clientVat).ConfigureAwait(false);

            // Step 5: Company Type Check
            if(companyInfo.companyType == CompanyTypeEnum.Small)
            {
                throw new BadHttpRequestException("Company type is small, and can't be processed", StatusCodes.Status403Forbidden);
            }

            // Step 6, 7 and 8: Retrieve Financial Document, Enrich Response Model, Financial Data Anonymization
            string financialDocumentJson = await _financialDocumentService.RetrieveFinancialDocumentAsync(tenantId, documentId, productCode, companyInfo.companyType, companyInfo.registrationNumber).ConfigureAwait(false);

            return financialDocumentJson;
        }
    }
}
