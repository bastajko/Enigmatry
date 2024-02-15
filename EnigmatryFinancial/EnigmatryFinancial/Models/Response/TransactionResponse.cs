using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class TransactionResponse
    {
        [JsonPropertyName("transactionId")]
        public Guid TransactionId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty; // Assuming date is represented as string for simplicity

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
    }
}
