using EnigmatryFinancial.Data;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Services
{
    public class ClientWhitelistingService : IClientWhitelistingService
    {
        private readonly AppDbContext _dbContext;

        public ClientWhitelistingService(AppDbContext dbContext)
        {
            // TODO: Create generic repository.

            _dbContext = dbContext;
        }

        public async Task<bool> IsClientWhitelistedAsync(Guid tenantId, Guid clientId)
        {
            // TODO: Create generic repostitory.

            // TODO: Replace vars with real types.

            // Check if the client ID is whitelisted for the given tenant ID
            Entities.WhitelistClient? clientWhitelist = await _dbContext.ClientWhitelist
            .FirstOrDefaultAsync(cw => cw.TenantId == tenantId && cw.ClientId == clientId);

            return clientWhitelist != null;
        }
    }
}
