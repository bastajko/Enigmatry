using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Entities.Enums;
using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Services
{
    public class FinancialDocumentService : IFinancialDocumentService
    {
        private readonly IFinancialDocumentRepository _financialDocumentRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPropertyConfigRepository _propertyConfigRepository;

        public FinancialDocumentService(IFinancialDocumentRepository financialDocumentRepository, ITransactionRepository transactionRepository, IPropertyConfigRepository propertyConfigRepository)
        {
            _financialDocumentRepository = financialDocumentRepository;
            _propertyConfigRepository = propertyConfigRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<string> RetrieveFinancialDocumentAsync(Guid tenantId, Guid documentId, string productCode, CompanyTypeEnum companyType, string registrationNumber)
        {

            IReadOnlyDictionary<PropertyEnum, VisibilityTypeEnum> documentPropertyNameEnumToVisibilityTypeMap = await _propertyConfigRepository.GetConfigurationsForEntity(productCode, EntityEnum.Document).ConfigureAwait(false);

            IReadOnlyDictionary<PropertyEnum, VisibilityTypeEnum> transactionPropertyNameEnumToVisibilityTypeMap = await _propertyConfigRepository.GetConfigurationsForEntity(productCode, EntityEnum.Transaction).ConfigureAwait(false);

            Type financialDocumentType = typeof(FinancialDocument);
            Type transactionType = typeof(Transaction);

            FinancialDocument financialDocument = await _financialDocumentRepository.GetFinancialDocumentForDocId(documentId).ConfigureAwait(false);
            IReadOnlyList<Transaction> transactions = await _transactionRepository.GetTransactionsByDocId(documentId).ConfigureAwait(false);

            // Select properties dynamically based on the list of property names
            var result = new
            {
                FinancialDocument = SelectProperties(financialDocument, financialDocumentType, documentPropertyNameEnumToVisibilityTypeMap),
                Transactions = transactions.Select(transaction =>
                                    SelectProperties(transaction, transactionType, transactionPropertyNameEnumToVisibilityTypeMap)
                                ).ToList(),
                Company = new { RegistrationNumber = registrationNumber, CompanyType = companyType.ToString()},
            };


            /*var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };*/
            string json = JsonSerializer.Serialize(result);

            return json;
        }

        Dictionary<string, object> SelectProperties(object entity, Type entityType, IReadOnlyDictionary<PropertyEnum, VisibilityTypeEnum> visibilityMap)
        {
            return visibilityMap.Select(propertyPair =>
            {
                var propertyName = propertyPair.Key.ToString();
                var property = entityType.GetProperty(propertyName);
                if (property == null)
                    return new KeyValuePair<string, object>(propertyName, null);

                var value = property.GetValue(entity);
                switch (propertyPair.Value)
                {
                    case VisibilityTypeEnum.Unchanged:
                        return new KeyValuePair<string, object>(propertyName, value);
                    case VisibilityTypeEnum.Masked:
                        return new KeyValuePair<string, object>(propertyName, "#####");
                    case VisibilityTypeEnum.Hashed:
                        return new KeyValuePair<string, object>(propertyName, Util.ComputeSHA256Hash(value?.ToString() ?? string.Empty));
                    default:
                        throw new InvalidOperationException("Invalid visibility type.");
                }
            }).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}