using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryServic
    {
        IEnumerable<Category>GetCategories(bool trackChanges);
        
        IEnumerable<Category> GetAllCategories(bool trackChanges); 
    }
}