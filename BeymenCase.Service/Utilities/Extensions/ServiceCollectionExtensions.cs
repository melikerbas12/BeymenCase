using System.Reflection;
using BeymenCase.Core.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SahaBT.Retro.Core.Utilities;

namespace BeymenCase.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
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

            return services;
        }
    }
}