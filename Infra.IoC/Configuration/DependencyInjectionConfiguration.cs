
using Application.Interfaces;
using Application.Interfaces.SubscriptionType;
using Application.Services;
using Application.Services.SubscriptionType;
using Core.Interfaces.SubscriptionType;
using Infra.Data.Context;
using Infra.Data.Repositories.SubscriptionType;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //DB Context
            services.AddScoped<IDbContext, ApplicationDbContext>();

            //repositories
            services.AddScoped<ICreateSubscriptionTypeRepository, CreateSubscriptionTypeRepository>();
            services.AddScoped<IUpdateSubscriptionTypeRepository, UpdateSubscriptionTypeRepository>();
            services.AddScoped<IDeleteSubscriptionTypeRepository, DeleteSubscriptionTypeRepository>();
            services.AddScoped<ISearchSubscriptionTypeRepository, SearchSubscriptionTypeRepository>();

            //services
            services.AddScoped<ICreateSubscriptionTypeService, CreateSubscriptionTypeService>();
            services.AddScoped<IUpdateSubscriptionTypeService, UptadeSubscriptionTypeService>();
            services.AddScoped<IDeleteSubscriptionTypeService, DeleteSubscriptionTypeService>();
        }
    }
}
