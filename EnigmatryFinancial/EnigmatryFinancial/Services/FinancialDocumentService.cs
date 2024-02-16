using EnigmatryFinancial.Models.Response;
using EnigmatryFinancial.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Services
{
    public class FinancialDocumentService : IFinancialDocumentService
    {
        private readonly IFinancialDocumentRepository _financialDocumentRepository;

        public FinancialDocumentService(IProductService productService, IFinancialDocumentRepository financialDocumentRepository)
        {
            _financialDocumentRepository = financialDocumentRepository;
        }

        public async Task<string> RetrieveFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode)
        {
            FinancialDocumentData returnDoc;
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
            string json = JsonSerializer.Serialize(_financialDocumentRepository.RetrieveEntity(documentId, "Document", productCode), options);
            /*

            // Fetch the financial document based on the product code
            switch (productCode)
            {
                case "ProductA":
                    // Retrieve financial document for ProductA
                    returnDoc = await _financialDocumentRepository.GetDocumentForProductAAsync(tenantId, documentId).ConfigureAwait(false);
                    break;
                case "ProductB":
                    // Retrieve financial document for ProductB
                    returnDoc = await _financialDocumentRepository.GetDocumentForProductBAsync(tenantId, documentId).ConfigureAwait(false);
                    break;
                // Add cases for other product codes as needed
                default:
                    // TODO: Change type of exception
                    throw new NotSupportedException($"Product with code '{productCode}' is not supported.");
            }
            */
            //return JsonSerializer.Serialize(returnDoc);
            return json;
        }
    }
}