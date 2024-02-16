using EnigmatryFinancial.Repositories;
using EnigmatryFinancial.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmatryFinancialTests.ServiceTests
{
    [TestClass]
    public class FinancialDocumentRetrievalTests : BaseTest
    {
        [TestMethod]
        public async Task RetrieveDocument_ValidInput_ReturnsData()
        {
            using (_dbContext)
            {
                IProductRepository productRepository = new ProductRepository(_dbContext);
                ITenantRepository tenantRepository = new TenantRepository(_dbContext);
                IClientRepository clientRepository = new ClientRepository(_dbContext);
                IFinancialDocumentRepository financialDocumentRepository = new FinancialDocumentRepository(_dbContext);
                ITransactionRepository transactionRepository = new TransactionRepository(_dbContext);
                IPropertyConfigRepository propertyConfigRepository = new PropertyConfigRepository(_dbContext);

                IProductService productService = new ProductService(productRepository);
                ITenantService tenantService = new TenantService(tenantRepository);
                IClientService clientService = new ClientService(clientRepository);
                IFinancialDocumentService financialDocumentService = new FinancialDocumentService(financialDocumentRepository, transactionRepository, propertyConfigRepository);

                FinancialDocumentRetrievalService financialDocumentRetrievalService = new FinancialDocumentRetrievalService(productService, tenantService, clientService, financialDocumentService);
                
                string response = await financialDocumentRetrievalService.RetrieveDocument(_tenantIds[0], _financialDocIds[0], "ProductA").ConfigureAwait(false);

                Assert.IsTrue(response != "");
            }
        }

        [TestMethod]

        public async Task RetrieveDocument_ProductNotSupported_ThrowsBadHttpException403()
        {
            using (_dbContext)
            {
                IProductRepository productRepository = new ProductRepository(_dbContext);
                ITenantRepository tenantRepository = new TenantRepository(_dbContext);
                IClientRepository clientRepository = new ClientRepository(_dbContext);
                IFinancialDocumentRepository financialDocumentRepository = new FinancialDocumentRepository(_dbContext);
                ITransactionRepository transactionRepository = new TransactionRepository(_dbContext);
                IPropertyConfigRepository propertyConfigRepository = new PropertyConfigRepository(_dbContext);

                IProductService productService = new ProductService(productRepository);
                ITenantService tenantService = new TenantService(tenantRepository);
                IClientService clientService = new ClientService(clientRepository);
                IFinancialDocumentService financialDocumentService = new FinancialDocumentService(financialDocumentRepository, transactionRepository, propertyConfigRepository);

                FinancialDocumentRetrievalService financialDocumentRetrievalService = new FinancialDocumentRetrievalService(productService, tenantService, clientService, financialDocumentService);

                try
                {
                    string response = await financialDocumentRetrievalService.RetrieveDocument(_tenantIds[0], _financialDocIds[0], "ProductC").ConfigureAwait(false);
                }
                catch(BadHttpRequestException ex)
                {
                    Assert.AreEqual(StatusCodes.Status403Forbidden, ex.StatusCode);
                }
            }
        }
    }
}
