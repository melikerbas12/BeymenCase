

using BeymenCase.ConfLib.Context;
using BeymenCase.ConfLib.Repositories;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Redis;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.ConfLib.Services
{
    public class ConfigurationReader : IConfigurationReader
    {

        private string applicationName;
        private int refreshTimerIntervalInMS;
        private readonly IConfiguration Configuration;
        private readonly IRedisContext _redisContext;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly CancellationTokenSource _tokenSource;

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMS)
        {
            this.applicationName = applicationName;
            this.refreshTimerIntervalInMS = refreshTimerIntervalInMS;

            _redisContext = new RedisContext("localhost:6379");
            _configurationRepository = new ConfigurationRepository(connectionString);

            _tokenSource = new CancellationTokenSource();
            CancellationToken ct = _tokenSource.Token;
            Task.Run(() => RefreshConfig(this.refreshTimerIntervalInMS), ct);
        }

        public async Task<T> GetValue<T>(string key)
        {
            var prefix = string.Format("{0}:{1}", applicationName, key);
            var result = await _redisContext.GetAsync<Setting>(1, prefix);

            if (result != null)
                return (T)Convert.ChangeType(result.Value, typeof(T));

            var setting = await _configurationRepository.GetByApplicationName(applicationName,key);

            await _redisContext.SaveAsync(1, prefix, setting.Value, null);

            return (T)Convert.ChangeType(setting.Value, typeof(T));
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
                var list = await _configurationRepository.Get(applicationName);
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