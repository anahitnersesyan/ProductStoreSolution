using Microsoft.EntityFrameworkCore;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductStore.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _appContext;  

        public BaseRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _appContext.Set<TEntity>().AddAsync(entity);
            await _appContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
           return await _appContext.Set<TEntity>().AnyAsync(expression);         
        }
   
        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _appContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindThenIncludeAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _appContext.Set<TEntity>().Where(expression);

            return await  (includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty))).ToListAsync();   
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return  await _appContext.Set<TEntity>().SingleOrDefaultAsync(expression);
        }

        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            _appContext.Set<TEntity>().Remove(entity);
            return await _appContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _appContext.Update<TEntity>(entity);
            return await _appContext.SaveChangesAsync() > 0;
        }
        
    }
}
