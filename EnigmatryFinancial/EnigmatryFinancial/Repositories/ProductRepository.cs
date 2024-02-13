using EnigmatryFinancial.Data;
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
    }
}
