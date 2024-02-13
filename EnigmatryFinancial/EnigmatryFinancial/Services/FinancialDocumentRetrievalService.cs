using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;
using System.Net;
using System.Text.Json;

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
        public async Task<string> RetrieveDocument(DocumentRetrievalRequest request)
        {
            // Step 1: Validate Product Code
            await _productService.AssertProductSupported(request.ProductCode).ConfigureAwait(false);

            // Step 2: Tenant ID Whitelisting
            await _tenantService.AssertTenantWhitelisted(request.TenantId).ConfigureAwait(false);

            // Step 3: Client ID Whitelisting
            (Guid clientId, string clientVat) = await _clientService.GetClientIdAndVat(request.TenantId, request.DocumentId).ConfigureAwait(false);
            // TODO: Change types of ids
            // TODO: Do the argument validation!
            await _clientService.AssertClientWhitelisted(request.TenantId, clientId.ToString() ?? string.Empty).ConfigureAwait(false);

            // Step 4: Fetch Additional Client Information
            var companyInfo = await _clientService.GetCompanyInfoAsync(clientVat).ConfigureAwait(false);

            // Step 5: Company Type Check
            if(companyInfo.companyType == CompanyTypeEnum.Small)
            {
                throw new BadHttpRequestException("Company type is small, and can't be processed", (int)HttpStatusCode.Forbidden);
            }

            // Step 6: Retrieve Financial Document
            string financialDocumentJson = await _financialDocumentService.RetrieveFinancialDocumentAsync(request.TenantId, request.DocumentId, request.ProductCode).ConfigureAwait(false);


            // financialDocument = AppendToJsonString(financialDocument, "NewProperty1", "Value1");

            // Step 7: Enrich Response Model
            /*var response = new FinancialDocumentResponse
            {
                Data = financialDocument,
                Company = companyInfo
            };*/

            // Step 8: Financial Data Anonymization
            // _financialDocumentService.AnonymizeFinancialData(response);

            return financialDocumentJson;

        }
    }
}
