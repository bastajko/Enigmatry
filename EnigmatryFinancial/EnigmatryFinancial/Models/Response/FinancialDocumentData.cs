using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class FinancialDocumentData
    {
        [JsonPropertyName("accountNumber")]
        public required string AccountNumber { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        [JsonPropertyName("transactions")]
        public IReadOnlyList<TransactionResponse> Transactions { get; set; } = ImmutableList<TransactionResponse>.Empty;
    }
}
