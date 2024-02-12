using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("whenCreated")]
        public DateTime WhenCreated { get; set; }

        [JsonPropertyName("whenUpdated")]
        public DateTime WhenUpdated { get; set; }
    }
}
