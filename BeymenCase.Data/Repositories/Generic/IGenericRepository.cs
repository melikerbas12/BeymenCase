using System.Linq.Expressions;
using BeymenCase.Core.Models;

namespace SahaBT.Retro.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {

        ValueTask<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedResult<TEntity>> GetAllPagedAsync(int page, int pageSize);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedResult<TEntity>> FindPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void SoftRemove(TEntity entity);
        void SoftRemoveRange(IEnumerable<TEntity> entities);
    }
}