using EnigmatryFinancial.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Transaction : BaseEntity
    {
        [Required]
        [ForeignKey("FinancialDocument")]
        public Guid FinancialDocumentId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty; // This should be enum, but I don't have time

        // Navigation property
        public virtual FinancialDocument? FinancialDocument { get; set; }
    }
}
