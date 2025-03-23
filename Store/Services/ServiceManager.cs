using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryServic _categoryService;

        public ServiceManager(IProductService productService ,ICategoryServic categoryService)
        {
            _productService = productService;
            _categoryService=categoryService;
        }

        public IProductService ProductService => _productService;

        public ICategoryServic CategoryServic =>_categoryService;
    }
}