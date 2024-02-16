using EnigmatryFinancial.Entities.Enums;

namespace EnigmatryFinancial.Entities
{
    public class PropertyConfig : BaseEntity
    {
        public string EntityName { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public VisibilityTypeEnum VisibilityType { get; set; }
    }
}
