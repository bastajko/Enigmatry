using EnigmatryFinancial.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EnigmatryFinancial.Repositories
{
    public interface IProductRepository
    {
        Task<bool> IsProductSupported(string productCode);

        List<string> GetConfigurationsForEntity(string productCode, string entityName);
    }
}
