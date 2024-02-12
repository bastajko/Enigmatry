using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Tenant.Id))]
        public Guid TenantId { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("clientVAT")]
        public required string ClientVAT { get; set; }

        [JsonPropertyName("isWhitelisted")]
        public bool IsWhitelisted { get; set; }
    }
}
