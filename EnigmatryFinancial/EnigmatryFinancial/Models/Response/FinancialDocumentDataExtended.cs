using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class FinancialDocumentDataExtended : FinancialDocumentData
    {
        [JsonPropertyName("comments")]
        public string Comments { get; set; } = string.Empty;

        [JsonPropertyName("invoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;
    }
}
