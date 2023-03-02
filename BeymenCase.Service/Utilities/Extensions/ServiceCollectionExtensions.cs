using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BeymenCase.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                // opt.Filters.Add(new DefaultResponseAttribute());
                // opt.Filters.Add(new LogAttribute());
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            #region Mapper Settings
            // services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            // TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
            #endregion
            #region Cors Settings
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_cors",
                                builder =>
                                {
                                    builder
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                    //.AllowCredentials();
                                });
            });
            #endregion

            return services;
        }
    }
}