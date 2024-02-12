using EnigmatryFinancial.Models.Request;
using EnigmatryFinancial.Models.Response;

namespace EnigmatryFinancial.Services
{
    public class FinancialDocumentRetrievalService : IFinancialDocumentRetrievalService
    {
        private readonly ProductService _productService;
        private readonly TenantService _tenantService;
        private readonly ClientService _clientService;
        private readonly CompanyService _companyService;
        private readonly FinancialDocumentService _financialDocumentService;

        public FinancialDocumentRetrievalService(
            ProductService productService,
            TenantService tenantService,
            ClientService clientService,
            CompanyService companyService,
            FinancialDocumentService financialDocumentService)
        {
            _productService = productService;
            _tenantService = tenantService;
            _clientService = clientService;
            _companyService = companyService;
            _financialDocumentService = financialDocumentService;
        }
        public FinancialDocumentResponse RetrieveDocument(DocumentRetrievalRequest request)
        {
            // Implement logic to retrieve document based on request
            throw new System.NotImplementedException();
        }
    }
}
