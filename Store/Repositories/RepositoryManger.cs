using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManger:IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManger(IProductRepository productRepository,RepositoryContext context,ICategoryRepository categoryRepository)
        {
            _context=context;
            _productRepository = productRepository;
            _categoryRepository=categoryRepository;
        }

        public IProductRepository Product=> _productRepository;

        public ICategoryRepository Category =>_categoryRepository;

        // throw new NotImplementedException();
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}