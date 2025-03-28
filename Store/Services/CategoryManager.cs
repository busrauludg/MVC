using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryServic
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
           return _manager.Category.FindAll(trackChanges);
        }

        public IEnumerable<Category> GetCategories(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}