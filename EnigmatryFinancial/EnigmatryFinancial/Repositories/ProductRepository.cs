using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsProductSupported(string productCode)
        {
            return await _context.Products.AnyAsync(p => p.ProductCode == productCode).ConfigureAwait(false);
        }

        public List<string> GetConfigurationsForEntity(string productCode, string entityName)
        {
            return _context.Products
                .Where(pc => pc.ProductCode == productCode && pc.EntityName == entityName && pc.IsRetrieved)
                .Select(pc => pc.PropertyName)
                .ToList();
        }
    }
}
