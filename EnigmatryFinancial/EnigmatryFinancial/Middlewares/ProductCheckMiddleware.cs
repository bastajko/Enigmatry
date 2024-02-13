using EnigmatryFinancial.Services;

namespace EnigmatryFinancial.Middlewares
{
    public class ProductCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IProductService _productService;

        public ProductCheckMiddleware(RequestDelegate next, IProductService productService)
        {
            _next = next;
            _productService = productService;
        }

        public async Task Invoke(HttpContext context)
        {
            // TODO: remove this from middleware
            // Check if the product code is supported
            string productCode = context.Request.Query["productCode"];
            await _productService.AssertProductSupported(productCode).ConfigureAwait(false);

            // If service check passes, proceed to the next middleware in the pipeline
            await _next(context);
        }
    }
}
