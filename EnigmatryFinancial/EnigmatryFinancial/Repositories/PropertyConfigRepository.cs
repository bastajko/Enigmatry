using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Repositories
{
    public class PropertyConfigRepository : IPropertyConfigRepository
    {
        private readonly AppDbContext _context;

        public PropertyConfigRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyDictionary<PropertyEnum, VisibilityTypeEnum>> GetConfigurationsForEntity(string productCode, EntityEnum entityName)
        {
            return await _context.PropertyConfigs
                .Where(pc => pc.ProductCode == productCode && pc.EntityName == entityName)
                .Select(pc => pc)
                .ToDictionaryAsync(pc => pc.PropertyName, pc => pc.VisibilityType).ConfigureAwait(false);
        }
    }
}
