using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FinancialDocument> Documents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships

            // Example: Configure a one-to-many relationship between Tenant and Client
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Tenant)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TenantId);

            // Configure indexes

            // Example: Configure an index on the Client's VAT field
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.ClientVAT)
                .IsUnique();

            // Define fluent API configurations for entity mappings

            // Example: Configure the Product entity mapping using Fluent API
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products"); // Map to the "Products" table in the database
                entity.HasKey(p => p.Id); // Specify the primary key
                entity.Property(p => p.Name).IsRequired(); // Set the "Name" property as required
                                                           // Add more configurations as needed
            });
        }
    }
}
