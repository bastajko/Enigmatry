using EnigmatryFinancial.Repositories;
using System.Net;

namespace EnigmatryFinancial.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AssertProductSupported(string productCode)
        {
            if(! await _productRepository.IsProductSupported(productCode).ConfigureAwait(false))
            {
                throw new BadHttpRequestException("Product is not supported", StatusCodes.Status403Forbidden);
            }
        }
    }
}
