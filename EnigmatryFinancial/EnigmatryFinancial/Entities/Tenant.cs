using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Tenant : BaseEntity
    {

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("isWhitelisted")]
        public bool IsWhitelisted { get; set; }

        [JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        [JsonIgnore]
        public virtual ICollection<FinancialDocument> FinancialDocuments { get; set; } = new List<FinancialDocument>();
    }
}
