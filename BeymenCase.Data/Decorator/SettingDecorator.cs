using System.Linq.Expressions;
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Redis;
using BeymenCase.Core.Utilities.Settings;
using BeymenCase.Data.Repositories;
using Microsoft.Extensions.Options;
using SahaBT.Retro.Data.Repositories;

namespace BeymenCase.Data.Decorator
{
    public class SettingDecorator : ISettingRepository
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IRedisContext _redisContext;
        private readonly CacheItemSettings _cacheItemSetting;
        public SettingDecorator(ISettingRepository settingRepository, IRedisContext redisContext, IOptions<CacheItemSettings> cacheItemSettings)
        {
            _settingRepository = settingRepository;
            _redisContext = redisContext;
            _cacheItemSetting = cacheItemSettings.Value;
        }
        public IQueryable<Setting> Table => _settingRepository.Table;

        public async Task AddRangeAsync(IEnumerable<Setting> entities)
        {
            await _settingRepository.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<Setting, bool>> predicate)
        {
            return await _settingRepository.AnyAsync(predicate);
        }

        public IEnumerable<Setting> Find(Expression<Func<Setting, bool>> predicate)
        {
            return _settingRepository.Find(predicate);
        }

        public async Task<IEnumerable<Setting>> FindAsync(Expression<Func<Setting, bool>> predicate)
        {
            return await _settingRepository.FindAsync(predicate);
        }

        public async Task<PagedResult<Setting>> FindPagedAsync(int page, int pageSize, Expression<Func<Setting, bool>> predicate)
        {
            return await _settingRepository.FindPagedAsync(page, pageSize, predicate);
        }

        public async Task<Setting> FirstOrDefaultAsync(Expression<Func<Setting, bool>> predicate)
        {
            return await _settingRepository.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync();
        }

        public async Task<PagedResult<Setting>> GetAllPagedAsync(int page, int pageSize)
        {
            return await _settingRepository.GetAllPagedAsync(page, pageSize);
        }

        public async Task<Setting> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _settingRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<PagedResult<Setting>> GetSettings(int page, int pageSize, string applicationName, string? name, string? type, string? value)
        {
            var prefix = string.Format("{0}:{1}", applicationName, name);
            var result = await _redisContext.GetAsync<IList<Setting>>(_cacheItemSetting.Db, prefix);

            if (result != null)
                return await result.AsQueryable().GetPaged(page, pageSize);

            var settings = await _settingRepository.GetSettings(page, pageSize, applicationName, name, type, value);

            await _redisContext
                .SaveAsync(_cacheItemSetting.Db, prefix, settings, null);

            return settings;
        }
        public async Task<Setting> AddAsync(Setting entity)
        {
            var prefix = string.Format("{0}:{1}", entity.ApplicationName, entity.Name);
            await _settingRepository.AddAsync(entity);
            _redisContext.Remove(_cacheItemSetting.Db, prefix);
            return entity;
        }

        public void Remove(Setting entity)
        {
            var prefix = string.Format("{0}:{1}", entity.ApplicationName, entity.Name);
            _settingRepository.Remove(entity);
            _redisContext.Remove(_cacheItemSetting.Db, prefix);
        }

        public void RemoveRange(IEnumerable<Setting> entities)
        {
            _settingRepository.RemoveRange(entities);
        }

        public async Task<Setting> SingleOrDefaultAsync(Expression<Func<Setting, bool>> predicate)
        {
            return await _settingRepository.SingleOrDefaultAsync(predicate);
        }

        public void SoftRemove(Setting entity)
        {
            _settingRepository.SoftRemove(entity);
        }

        public void SoftRemoveRange(IEnumerable<Setting> entities)
        {
            _settingRepository.SoftRemoveRange(entities);
        }

        public void Update(Setting entity)
        {
            var prefix = string.Format("{0}:{1}", entity.ApplicationName, entity.Name);
            _settingRepository.Update(entity);
            _redisContext.Remove(_cacheItemSetting.Db, prefix);
        }

        public void UpdateRange(IEnumerable<Setting> entities)
        {
            _settingRepository.UpdateRange(entities);
        }

        async ValueTask<Setting> IGenericRepository<Setting>.GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _settingRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}