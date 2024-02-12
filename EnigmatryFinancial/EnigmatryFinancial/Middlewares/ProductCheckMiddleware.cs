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
            // Check if the product code is supported
            string productCode = context.Request.Query["productCode"];
            if (!_productService.IsProductSupported(productCode))
            {
                // TODO: Add logging
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            // If service check passes, proceed to the next middleware in the pipeline
            await _next(context);
        }
    }
}
