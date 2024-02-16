using EnigmatryFinancial.Data;
using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Entities.Enums;
using EnigmatryFinancial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EnigmatryFinancialTests
{
    public class BaseTest
    {
        protected AppDbContext _dbContext;
        protected Guid[] _tenantIds = [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()];

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            _dbContext = new AppDbContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();
            /*
            var productList = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "ProductA", ProductCode = "ProductA" },
                new Product { Id = Guid.NewGuid(), Name = "ProductB", ProductCode = "ProductB" }
            };
            */

            List<Tenant> tenants = new List<Tenant>
            {
                new Tenant { Id = _tenantIds[0], Name = "Tenant1", IsWhitelisted = true },
                new Tenant { Id = _tenantIds[1], Name = "Tenant2", IsWhitelisted = true },
                new Tenant { Id = _tenantIds[2], Name = "Tenant3", IsWhitelisted = false }
            };

            Guid[] clientIds = new Guid[6];
            for (int i = 0; i < 6; i++)
            {
                clientIds[i] = Guid.NewGuid();
            }
            List<Client> clients = new List<Client>
            {
                new Client { Id = clientIds[0], TenantId = _tenantIds[0], Name = "Client1", ClientVAT = "321456789", RegistrationNumber = "IJK123", CompanyType = CompanyTypeEnum.Small, IsWhitelisted = true },
                new Client { Id = clientIds[1], TenantId = _tenantIds[1], Name = "Client2", ClientVAT = "789650321", RegistrationNumber = "PRS456", CompanyType = CompanyTypeEnum.Small, IsWhitelisted = true },
                new Client { Id = clientIds[2], TenantId = _tenantIds[2], Name = "Client3", ClientVAT = "642813579", RegistrationNumber = "LFT789", CompanyType = CompanyTypeEnum.Medium, IsWhitelisted = true },
                new Client { Id = clientIds[3], TenantId = _tenantIds[0], Name = "Client4", ClientVAT = "113320987", RegistrationNumber = "JPP012", CompanyType = CompanyTypeEnum.Medium, IsWhitelisted = true },
                new Client { Id = clientIds[4], TenantId = _tenantIds[1], Name = "Client5", ClientVAT = "721792468", RegistrationNumber = "HRS345", CompanyType = CompanyTypeEnum.Large, IsWhitelisted = true },
                new Client { Id = clientIds[5], TenantId = _tenantIds[1], Name = "Client6", ClientVAT = "803258147", RegistrationNumber = "SFK678", CompanyType = CompanyTypeEnum.Large, IsWhitelisted = true }
            };

            Guid[] financialDocIds = [Guid.NewGuid(), Guid.NewGuid()];

            List<FinancialDocument> financialDocs = new List<FinancialDocument>()
            {
                new FinancialDocument { Id = financialDocIds[0], TenantId = _tenantIds[0], ClientId = clientIds[3], Type = "Invoice", Balance = 1000.00m, Currency = "USD", AccountNumber = "95867648" },
                new FinancialDocument { Id = financialDocIds[1], TenantId = _tenantIds[1], ClientId = clientIds[4], Type = "Receipt", Balance = 2500.00m, Currency = "EUR", AccountNumber = "93577094" }
            };

            List<Transaction> transactions = new List<Transaction>();
            Random random = new Random();

            // Generate transactions
            for (int i = 0; i < 20; i++)
            {
                // Generate random transaction properties
                decimal amount = (decimal)random.NextDouble() * 1000;
                DateTime date = DateTime.Now.AddDays(-random.Next(1, 365));
                string[] descriptions = { "Grocery shopping", "Gas station purchase", "Dinner at restaurant", "Online shopping" };
                string[] categories = { "Food & Dining", "Utilities", "Entertainment", "Shopping" };

                // Create a new transaction
                Transaction transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = Math.Round(amount, 2),
                    Date = date,
                    Description = descriptions[random.Next(descriptions.Length)],
                    Category = categories[random.Next(categories.Length)],
                    FinancialDocumentId = financialDocIds[random.Next(financialDocIds.Length)],
                };

                // Add transaction to the list
                transactions.Add(transaction);
            }

            _dbContext.Tenants.AddRange(tenants);
            _dbContext.Clients.AddRange(clients);
            _dbContext.Documents.AddRange(financialDocs);
            _dbContext.Transactions.AddRange(transactions);
            _dbContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
