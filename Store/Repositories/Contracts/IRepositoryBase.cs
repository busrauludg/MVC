using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T>FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T,bool>>expression,bool trackChanges);//bu ilgili kural bunun implomente edilmiş hali repositoray basede
        void Create(T entity);
    }
}