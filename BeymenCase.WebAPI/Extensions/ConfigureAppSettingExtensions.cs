using BeymenCase.Core.Utilities.Settings;

namespace BeymenCase.WebAPI.Extensions
{
    public static class ConfigureAppSettingExtensions
    {
        public static IServiceCollection AddConfigureAppsetting(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<CacheItemSettings>(configuration.GetSection("CacheItem"));

            return services;
        }
    }
}
