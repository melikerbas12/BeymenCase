using System.Linq.Expressions;
using BeymenCase.Core.Models;
using BeymenCase.Data;
using BeymenCase.Data.Context;
using Microsoft.EntityFrameworkCore;
using SahaBT.Retro.Data.Repositories;

namespace BeymenCode.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly BeymenCaseDbContext _context;

        public GenericRepository(BeymenCaseDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Table =>  _context.Set<TEntity>().AsQueryable();
        public async ValueTask<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<PagedResult<TEntity>> GetAllPagedAsync(int page, int pageSize)
        {
            return await _context.Set<TEntity>().GetPaged(page, pageSize);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<PagedResult<TEntity>> FindPagedAsync(int page, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).GetPaged(page, pageSize);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Attach(entities);
            _context.Entry(entities).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SoftRemove(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsActive");

            var propertyValue = (bool?)property.GetValue(entity);

            if (propertyValue.HasValue)
            {
                property.SetValue(entity, false);

            }
        }

        public void SoftRemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var property = entity.GetType().GetProperty("IsActive");

                var propertyValue = (bool?)property.GetValue(entity);

                if (propertyValue.HasValue)
                {
                    property.SetValue(entity, false);
                }
            }
        }
    }
}