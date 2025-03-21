using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        IQueryable<Product>GetAllProducts(bool trackChanges);//değişikliklerin tek yerden izlenmisi gibi birşiy

        Product? GetOneProduct(int id,bool trackChanges);//burda gösterdik
    }
}