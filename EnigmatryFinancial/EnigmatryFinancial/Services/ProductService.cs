namespace EnigmatryFinancial.Services
{
    public class ProductService : IProductService
    {
        // Simulated list of supported product codes
        private readonly HashSet<string> _supportedProducts = new HashSet<string> { "ProductA", "ProductB" };

        public bool IsProductSupported(string productCode)
        {
            // Check if the provided product code is in the list of supported products
            return _supportedProducts.Contains(productCode);
        } 
    }
}
