using EnigmatryFinancial.Entities.Enums;

namespace EnigmatryFinancial.Entities
{
    public class PropertyConfig : BaseEntity
    {
        public required string ProductCode { get; set; }
        public EntityEnum EntityName { get; set; }
        public PropertyEnum PropertyName { get; set; }
        public VisibilityTypeEnum VisibilityType { get; set; }
    }
}
