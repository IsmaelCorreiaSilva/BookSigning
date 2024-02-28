
using Application.Interfaces;
using Application.Interfaces.SubscriptionType;
using Application.Services;
using Application.Services.SubscriptionType;
using Core.Interfaces;
using Core.Interfaces.SubscriptionType;
using Infra.Data.Context;
using Infra.Data.Repositories;
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
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICreateSubscriptionTypeRepository, CreateSubscriptionTypeRepository>();

            //services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICreateSubscriptionTypeService, CreateSubscriptionTypeService>();
        }
    }
}
