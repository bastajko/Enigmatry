using EnigmatryFinancial.Controllers;
using EnigmatryFinancial.Entities.Enums;
using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ExceptionExtensions;

namespace EnigmatryFinancialTests.ServiceTests
{
    [TestClass]
    public class FinancialDocumentServiceTests : BaseTest
    {
        // Test method created for purposes of showing subsititution and test mocking
        [TestMethod]
        [ExpectedException(typeof(BadHttpRequestException))]
        public async Task RetrieveDocument_Substitute_ThrowsException()
        {
            using (_dbContext)
            {
                IFinancialDocumentRepository docRepo = Substitute.For<IFinancialDocumentRepository>();
                var financialDocumentService = new FinancialDocumentService(docRepo, Substitute.For<ITransactionRepository>(), Substitute.For<IPropertyConfigRepository>());

                docRepo.GetFinancialDocumentForDocId(Arg.Any<Guid>()).Throws(new BadHttpRequestException("", StatusCodes.Status403Forbidden));

                await financialDocumentService
                    .RetrieveFinancialDocumentAsync(Guid.NewGuid(), Guid.NewGuid(), string.Empty, CompanyTypeEnum.Small, string.Empty)
                    .ConfigureAwait(false);
            }
        }
    }
}
