using EnigmatryFinancial.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models
{
    public class FinancialDocument : BaseEntity
    {
        [Required]
        public int TenantId { get; set; }

        [Required]
        public int ClientId { get; set; }

        // TODO: Revisit this
        public string Data { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string AccountNumber { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public string Currency { get; set; } = string.Empty;

        [JsonIgnore]
        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [JsonIgnore]
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
