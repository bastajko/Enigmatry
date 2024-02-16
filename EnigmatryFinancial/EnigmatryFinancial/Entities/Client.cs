using EnigmatryFinancial.Entities.Enums;
using EnigmatryFinancial.Models;
using EnigmatryFinancial.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Tenant.Id))]
        [JsonPropertyName("tenantId")]
        public Guid TenantId { get; set; }

        [Required]
        [JsonPropertyName("clientVAT")]
        public required string ClientVAT { get; set; }

        [Required]
        [JsonPropertyName("registrationNumber")]
        public required string RegistrationNumber { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("website")]
        public string Website { get; set; } = string.Empty;

        [JsonConverter(typeof(CompanyTypeConverter))]
        public CompanyTypeEnum CompanyType { get; set; }

        [JsonPropertyName("isWhitelisted")]
        public bool IsWhitelisted { get; set; }

        // Navigation property
        [JsonIgnore]
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }

        [JsonIgnore]
        public virtual ICollection<FinancialDocument>? FinancialDocuments { get; set; }
    }
}
