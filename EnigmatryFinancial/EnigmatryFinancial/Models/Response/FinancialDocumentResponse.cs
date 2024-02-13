using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class FinancialDocumentResponse
    {
        [JsonPropertyName("data")]
        public required FinancialDocumentData Data { get; set; }

        [JsonPropertyName("company")]
        public required CompanyResponse Company { get; set; }
    }
}
