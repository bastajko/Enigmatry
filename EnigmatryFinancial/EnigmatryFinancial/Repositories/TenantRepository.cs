using EnigmatryFinancial.Data;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> IsTenantWhitelisted(Guid tenantId)
        {
            return _context.Tenants.AnyAsync(t => t.Id == tenantId && t.IsWhitelisted);
        }
    }
}
