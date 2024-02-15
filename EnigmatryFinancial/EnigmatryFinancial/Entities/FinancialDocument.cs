using EnigmatryFinancial.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models
{
    public class FinancialDocument : BaseEntity
    {
        [Required]
        [JsonPropertyName("tenantId")]
        public Guid TenantId { get; set; }

        [Required]
        [JsonPropertyName("clientId")]
        public Guid ClientId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty; // This should be enum, but I don't have time

        // Navigation properties

        [JsonIgnore]
        [ForeignKey("TenantId")]
        public virtual Tenant? Tenant { get; set; }

        [JsonIgnore]
        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
