using EnigmatryFinancial.Entities;
using EnigmatryFinancial.Models;
using Microsoft.EntityFrameworkCore;

namespace EnigmatryFinancial.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FinancialDocument> FinancialDocuments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
