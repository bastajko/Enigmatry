using EnigmatryFinancial.Repositories;
using System.Net;

namespace EnigmatryFinancial.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task AssertTenantWhitelisted(Guid tenantId)
        {
            try
            {
                if(!(await _tenantRepository.IsTenantWhitelisted(tenantId).ConfigureAwait(false)))
                {
                    throw new BadHttpRequestException("Tenant is not whitelisted", StatusCodes.Status403Forbidden);
                }
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Failed to check tenant whitelist", ex);
            }
        }
    }

}
