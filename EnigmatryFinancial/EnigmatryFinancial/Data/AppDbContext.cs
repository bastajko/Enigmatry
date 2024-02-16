using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml;

namespace EnigmatryFinancial.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FinancialDocument> Documents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PropertyConfig> PropertyConfigs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Tenant)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TenantId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FinancialDocument)
                .WithMany(fd => fd.Transactions)
                .HasForeignKey(t => t.FinancialDocumentId);

            modelBuilder.Entity<FinancialDocument>()
                .HasOne(fd => fd.Tenant)
                .WithMany(t => t.FinancialDocuments)
                .HasForeignKey(fd => fd.TenantId);

            modelBuilder.Entity<FinancialDocument>()
                .HasOne(fd => fd.Client)
                .WithMany(c => c.FinancialDocuments)
                .HasForeignKey(fd => fd.ClientId);

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.ClientVAT)
                .IsUnique();

#if !TEST_PROJECT
            SeedData(modelBuilder);
#endif
            base.OnModelCreating(modelBuilder);
        }

        void SeedData(ModelBuilder modelBuilder)
        {
            // Seed initial data if needed

            _ = modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "ProductA", ProductCode = "ProductA" },
                new Product { Id = Guid.NewGuid(), Name = "ProductB", ProductCode = "ProductB" }
            );

            Guid[] tenantIds = new Guid[3];
            for (int i = 0; i < 3; i++)
            {
                tenantIds[i] = Guid.NewGuid();
            }

            _ = modelBuilder.Entity<Tenant>().HasData(
                new Tenant { Id = tenantIds[0], Name = "TenantA", IsWhitelisted = true },
                new Tenant { Id = tenantIds[1], Name = "TenantB", IsWhitelisted = true },
                new Tenant { Id = tenantIds[2], Name = "TenantC", IsWhitelisted = false }
            );

            _ = modelBuilder.Entity<PropertyConfig>().HasData(
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.AccountNumber, VisibilityType = VisibilityTypeEnum.Hashed },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.Currency, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.Balance, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Id, VisibilityType = VisibilityTypeEnum.Masked },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Amount, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Date, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Description, VisibilityType = VisibilityTypeEnum.Masked },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductA", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Category, VisibilityType = VisibilityTypeEnum.Unchanged },

                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.AccountNumber, VisibilityType = VisibilityTypeEnum.Hashed },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.Currency, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.Balance, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Document, PropertyName = PropertyEnum.Status, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Id, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Amount, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Date, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Description, VisibilityType = VisibilityTypeEnum.Unchanged },
                    new PropertyConfig { Id = Guid.NewGuid(), ProductCode = "ProductB", EntityName = EntityEnum.Transaction, PropertyName = PropertyEnum.Category, VisibilityType = VisibilityTypeEnum.Unchanged }
                );

            Guid[] clientIds = new Guid[6];
            for (int i = 0; i < 6; i++)
            {
                clientIds[i] = Guid.NewGuid();
            }
            _ = modelBuilder.Entity<Client>().HasData(
                new Client { Id = clientIds[0], TenantId = tenantIds[0], Name = "ClientA", ClientVAT = "123456789", RegistrationNumber = "ABC123", CompanyType = CompanyTypeEnum.Small, IsWhitelisted = true },
                new Client { Id = clientIds[1], TenantId = tenantIds[1], Name = "ClientB", ClientVAT = "987654321", RegistrationNumber = "XYZ456", CompanyType = CompanyTypeEnum.Small, IsWhitelisted = true },
                new Client { Id = clientIds[2], TenantId = tenantIds[2], Name = "ClientC", ClientVAT = "246813579", RegistrationNumber = "DEF789", CompanyType = CompanyTypeEnum.Medium, IsWhitelisted = true },
                new Client { Id = clientIds[3], TenantId = tenantIds[0], Name = "ClientD", ClientVAT = "654321987", RegistrationNumber = "GHI012", CompanyType = CompanyTypeEnum.Medium, IsWhitelisted = true },
                new Client { Id = clientIds[4], TenantId = tenantIds[1], Name = "ClientE", ClientVAT = "135792468", RegistrationNumber = "JKL345", CompanyType = CompanyTypeEnum.Large, IsWhitelisted = true },
                new Client { Id = clientIds[5], TenantId = tenantIds[1], Name = "ClientF", ClientVAT = "369258147", RegistrationNumber = "MNO678", CompanyType = CompanyTypeEnum.Large, IsWhitelisted = true }
            );

            Guid[] financialDocIds = new Guid[2] { Guid.NewGuid(), Guid.NewGuid() };

            _ = modelBuilder.Entity<FinancialDocument>().HasData(
                new FinancialDocument { Id = financialDocIds[0], TenantId = tenantIds[0], ClientId = clientIds[3], Type = "Invoice", Balance = 1000.00m, Currency = CurrencyEnum.USD, AccountNumber = "95867648", Status = TaxReturnStatusEnum.Accepted },
                new FinancialDocument { Id = financialDocIds[1], TenantId = tenantIds[1], ClientId = clientIds[4], Type = "Receipt", Balance = 2500.00m, Currency = CurrencyEnum.EUR, AccountNumber = "93577094", Status = TaxReturnStatusEnum.Finalized }
            );

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

            modelBuilder.Entity<Transaction>().HasData(transactions);
        }
    }
}
