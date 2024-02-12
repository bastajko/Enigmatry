namespace EnigmatryFinancial.Entities
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
