using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T:class,new()//kısıtlayıcılardır
    {
        protected readonly RepositoryContext _context;//devraldığım classlardada kullanmak için procted yaptım
        protected RepositoryBase(RepositoryContext context)
        {
            _context=context;
        }

        public void Create(T entity)//create işlemini buraya yansıttık implementasyon yaptık 
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T>FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
        }//base için ilgili tanım tüm kayıktları getiriyo

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ?_context.Set<T>().Where(expression).SingleOrDefault()
                :_context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();//değişiklikleri kaydetme
                //implomente edilmiş hali
        }
    }//temel sınıflar newlenmicek abstract metotlar

    
}