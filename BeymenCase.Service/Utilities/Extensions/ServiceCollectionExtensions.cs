using BeymenCase.Core.Utilities;
using BeymenCase.Data.Repositories;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Redis;
using BeymenCase.Service.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SahaBT.Retro.Data.UnitOfWork;
using System.Reflection;

namespace BeymenCase.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(opt =>
            {
                opt.Filters.Add<ValidationFilter>();
            }).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

            services.AddFluentValidationAutoValidation()
               .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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

            #endregion Cors Settings

            #region Redis

            services.AddSingleton<IRedisContext>(sp =>
            {
                var redis = new RedisContext(configuration.GetSection("RedisConfig").Value);
                redis.Connect();
                return redis;
            });

            #endregion Redis

            #region Service Life

            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            // services.AddScoped<IConfigurationReader>();

            #endregion Service Life

            return services;
        }
    }
}