using BeymenCase.Core.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SahaBT.Retro.Core.Utilities;
using System.Reflection;

namespace BeymenCase.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            

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

            return services;
        }
    }
}