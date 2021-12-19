using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductStore.Core.Interfaces.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindThenIncludeAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression); 
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> RemoveAsync(TEntity entity);
    }
}
