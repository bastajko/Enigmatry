namespace EnigmatryFinancial.Repositories
{
    public interface IProductRepository
    {
        Task<bool> IsProductSupported(string productCode);
    }
}
