using BeymenCase.Core.Redis;
using BeymenCase.Core.Utilities.Settings;

namespace BeymenCase.WebAPI.Extensions
{
    public static class ConfigureAppSettingExtensions
    {
        public static IServiceCollection AddConfigureAppsetting(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<CacheItemSettings>(configuration.GetSection("CacheItem"));
            #region Redis

            services.AddSingleton<IRedisContext>(sp =>
            {
                var redis = new RedisContext(configuration.GetSection("RedisConfig").Value);
                redis.Connect();
                return redis;
            });

            #endregion Redis

            return services;
        }
    }
}
