using Microsoft.EntityFrameworkCore;
using tour.models;

namespace tour.repos.Base
{
    public class BaseRepository<T>: IBaseRepository<T> where T :class
    {
        protected MyDBContext _context;
        public BaseRepository(MyDBContext dbContext) => dbContext = _context;

  

        public IQueryable<T> FindByCondiction(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
         return    !trackChanges ?
                _context.Set<T>().Where(expression).AsNoTracking() :
                _context.Set<T>().Where(expression);
        }

        public async Task Update(T entity) => await Task.FromResult(_context.Set<T>().Update(entity));
        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);
    }
}
