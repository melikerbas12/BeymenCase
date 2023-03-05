using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Redis;
using BeymenCase.Core.Utilities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeymenCase.ConfLib
{
    public class ConfigurationReader : IConfigurationReader
    {

        private string applicationName;
        private int refreshTimerIntervalInMS;
        private readonly ConfigurationDbContext _context;
        private readonly IConfiguration Configuration;
        private readonly IRedisContext _redisContext;
        private readonly CancellationTokenSource _tokenSource;

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMS)
        {
            _context = new ConfigurationDbContext(connectionString);
            _redisContext = new RedisContext("localhost:6390");
            this.applicationName = applicationName;
            this.refreshTimerIntervalInMS = refreshTimerIntervalInMS;
            _tokenSource = new CancellationTokenSource();
            CancellationToken ct = _tokenSource.Token;
            Task.Run(() => RefreshConfig(this.refreshTimerIntervalInMS), ct);
        }

        public async Task<T> GetValue<T>(string key)
        {
            var prefix = string.Format("{0}:{1}", applicationName, key);
            var result = await _redisContext.GetAsync<T>(1, prefix);
            if (result != null)
                return result;

            var setting = await _context.Settings.Where(s => s.ApplicationName == applicationName && s.IsActive && s.Name == key).FirstOrDefaultAsync();

            await _redisContext.SaveAsync(1, prefix, setting, null);

            return (T)Convert.ChangeType(setting, typeof(T));
        }

        private async Task RefreshConfig(int refreshTimerIntervalInMS)
        {
            if (refreshTimerIntervalInMS < 5000)
            {
                refreshTimerIntervalInMS = 5000;
            }
            do
            {
                Thread.Sleep(refreshTimerIntervalInMS);
                var list = await _context.Settings.Where(s => s.ApplicationName == applicationName && s.IsActive).ToListAsync();
                foreach (var item in list)
                {
                    var prefix = string.Format("{0}:{1}", item.ApplicationName, item.Name);
                    var result = await _redisContext.GetAsync<Setting>(1, prefix);

                    if (result == null || result.Value != item.Value || result.Type != item.Type || result.IsActive != item.IsActive)
                        await _redisContext.SaveAsync(1, prefix, item, null);

                }

            } while (!_tokenSource.IsCancellationRequested);
        }
    }

}