using System.Linq.Expressions;

namespace tour.repos.Base
{
    public interface IBaseRepository<T>
    {
            IQueryable<T> FindByCondiction(Expression<Func<T, bool>> expression, bool trackChanges);
            Task Create(T entity);
            Task Update(T entity);
        
    }
}
