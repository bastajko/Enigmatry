using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models;
using EnigmatryFinancial.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace EnigmatryFinancialTests.RepositoryTests
{
    [TestClass]
    public class TenantRepositoryTests : BaseTest
    {
        public TenantRepositoryTests()
        {
        }

        [TestMethod]
        public async Task IsTenantWhitelisted_Valid_Success()
        {
            using (_dbContext)
            {
                ITenantRepository tenantRepository = new TenantRepository(_dbContext);
                bool isWhitelisted = await tenantRepository.IsTenantWhitelisted(_tenantIds[0]).ConfigureAwait(false);

                Assert.IsTrue(isWhitelisted);
            }
        }

        [TestMethod]
        public async Task IsTenantWhitelisted_InvalidId_False()
        {
            using (_dbContext)
            {
                ITenantRepository tenantRepository = new TenantRepository(_dbContext);
                bool isWhitelisted = await tenantRepository.IsTenantWhitelisted(Guid.Empty).ConfigureAwait(false);

                Assert.IsFalse(isWhitelisted);
            }
        }
    }
}
