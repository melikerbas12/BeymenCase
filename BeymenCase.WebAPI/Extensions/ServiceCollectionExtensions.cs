using BeymenCase.ConfLib;

namespace BeymenCase.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConfigurationReader(this IServiceCollection services, string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            services.AddSingleton<IConfigurationReader>(new ConfigurationReader(applicationName,
                                                                                connectionString,
                                                                                refreshTimerIntervalInMs));
        }
    }
}