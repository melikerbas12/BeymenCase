using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeymenCase.Core.Redis;
using BeymenCase.Core.Utilities;
using BeymenCase.Data.Decorator;
using BeymenCase.Data.Repositories;
using BeymenCase.Data.UnitOfWork;
using BeymenCase.Service.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MapsterMapper;
using BeymenCase.Data.UnitOfWork;

namespace BeymenCase.Service.Utilities.Extensions
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

            #region Service Life

            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISettingRepository, SettingRepository>();

            #endregion Service Life

            #region Decorates
            services.Decorate<ISettingRepository, SettingDecorator>();
            #endregion

            return services;
        }
    }
}