using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Product : BaseEntity
    {
        [JsonPropertyName("productCode")]
        public string ProductCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
