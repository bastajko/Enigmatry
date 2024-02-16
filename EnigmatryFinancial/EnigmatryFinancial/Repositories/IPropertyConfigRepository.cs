using EnigmatryFinancial.Entities.Enums;

namespace EnigmatryFinancial.Repositories
{
    public interface IPropertyConfigRepository
    {
        Task<IReadOnlyDictionary<PropertyEnum, VisibilityTypeEnum>> GetConfigurationsForEntity(string productCode, EntityEnum entityName);
    }
}
