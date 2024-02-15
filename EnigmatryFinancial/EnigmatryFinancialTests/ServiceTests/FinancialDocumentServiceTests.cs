using EnigmatryFinancial.Data;
using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmatryFinancialTests.ServiceTests
{
    [TestClass]
    public class FinancialDocumentServiceTests : BaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public async Task RetrieveDocument_InValidProductAsync()
        {
            using (_dbContext)
            {
                FinancialDocumentService financialDocumentService = new FinancialDocumentService(Substitute.For<IProductService>(), Substitute.For<IFinancialDocumentRepository>());
                _ = await financialDocumentService.RetrieveFinancialDocumentAsync(Guid.NewGuid(), Guid.NewGuid(), "unsupportedProduct").ConfigureAwait(false);
            }
        }
    }
}
