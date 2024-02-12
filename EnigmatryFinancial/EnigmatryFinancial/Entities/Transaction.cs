namespace EnigmatryFinancial.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid FinancialDocumentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
