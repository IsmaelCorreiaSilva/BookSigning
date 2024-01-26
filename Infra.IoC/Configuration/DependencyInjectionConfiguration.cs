
using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
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

            //services
            services.AddScoped<IBookService, BookService>();
        }
    }
}
