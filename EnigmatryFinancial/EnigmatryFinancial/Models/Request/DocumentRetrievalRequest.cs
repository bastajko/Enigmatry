namespace EnigmatryFinancial.Models.Request
{
    public class DocumentRetrievalRequest
    {
        public required string ProductCode { get; set; }
        public Guid TenantId { get; set; }
        public Guid DocumentId { get; set; }
    }
}
