using EnigmatryFinancial.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Transaction : BaseEntity
    {
        [Key]
        [Required]
        [JsonPropertyName("transactionId")]
        public int TransactionId { get; set; }

        [Required]
        [ForeignKey("FinancialDocument")]
        public int FinancialDocumentId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        // Navigation property
        public FinancialDocument FinancialDocument { get; set; }
    }
}
