namespace EnigmatryFinancial.Services
{
    public interface IProductService
    {
        Task AssertProductSupported(string productCode);
    }
}
