using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using BeymenCase.Data.Repositories;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Redis;
using BeymenCase.Service.Services;

using FluentValidation.AspNetCore;

using MapsterMapper;

using Newtonsoft.Json;

using SahaBT.Retro.Core.Utilities;
using SahaBT.Retro.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace BeymenCase.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add(new DefaultResponseAttribute());
            })
            .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true)
            .AddFluentValidation(options =>
                {
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            #region Mapper Settings

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
                                    // .AllowCredentials();
                                });
            });
            #endregion

            #region Redis
            services.AddSingleton<IRedisContext>(sp =>
            {
                var redis = new RedisContext(configuration.GetSection("RedisConfig").Value);
                redis.Connect();
                return redis;
            });
            #endregion

            #region Service Life
            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            #endregion

            return services;
        }
    }
}