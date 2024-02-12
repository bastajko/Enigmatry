using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class TransactionResponse
    {
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; } // Assuming date is represented as string for simplicity

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
