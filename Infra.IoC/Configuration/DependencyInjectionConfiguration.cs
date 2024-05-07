
using Application.Interfaces.Book;
using Application.Interfaces.MonthlyShipping;
using Application.Interfaces.Subscriber;
using Application.Interfaces.SubscriptionType;
using Application.Services.Book;
using Application.Services.MonthlyShipping;
using Application.Services.Subscriber;
using Application.Services.SubscriptionType;
using Core.Interfaces.Book;
using Core.Interfaces.MonthlyShipping;
using Core.Interfaces.Subscriber;
using Core.Interfaces.SubscriptionType;
using Infra.Data.Context;
using Infra.Data.Repositories.Book;
using Infra.Data.Repositories.MonthlyShipping;
using Infra.Data.Repositories.Subscriber;
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
            services.AddScoped<ICreateBookRepository, CreateBookRepository>();
            services.AddScoped<IUpdateBookRepository, UpdateBookRepository>();
            services.AddScoped<IDeleteBookRepository, DeleteBookRepository>();
            services.AddScoped<ISearchBookRepository, SearchBookRepository>();
            services.AddScoped<ISearchMonthlyShippingRepository, SearchMonthlyShippingRepository>();
            services.AddScoped<ICreateMonthlyShippingRepository, CreateMonthlyShippingRepository>();
            services.AddScoped<IUpdateMonthlyShippingRepository, UpdateMonthlyShippingRepository>();
            services.AddScoped<IDeleteMonthlyShippingRepository, DeleteMonthlyShippingRepository>();
            services.AddScoped<ICreateSubscriberRepository, CreateSubscriberRepository>();
            services.AddScoped<IUpdateSubscriberRepository, UpdateSubscriberRepository>();
            services.AddScoped<IDeleteSubscriberRepository, DeleteSubscriberRepository>();
            services.AddScoped<ISearchSubscriberRepository, SearchSubscriberRepository>();

            //services
            services.AddScoped<ICreateSubscriptionTypeService, CreateSubscriptionTypeService>();
            services.AddScoped<IUpdateSubscriptionTypeService, UptadeSubscriptionTypeService>();
            services.AddScoped<IDeleteSubscriptionTypeService, DeleteSubscriptionTypeService>();
            services.AddScoped<ISearchSubscriptionTypeService, SearchSubscriptionTypeService>();
            services.AddScoped<ICreateBookService, CreateBookService>();
            services.AddScoped<IUpdateBookService, UpdateBookService>();
            services.AddScoped<IDeleteBookService, DeleteBookService>();
            services.AddScoped<ISearchBookService, SearchBookService>();
            services.AddScoped<ICreateMonthlyShippingService, CreateMonthlyShippingService>();
            services.AddScoped<IUpdateMonthlyShippingService, UpdateMonthlyShippingService>();
            services.AddScoped<IDeleteMonthlyShippingService, DeleteMonthlyShippingService>();
            services.AddScoped<ISearchMonthlyShippingService, SearchMonthlyShippingService>();
            services.AddScoped<ICreateSubscriberService, CreateSubscriberService>();
            services.AddScoped<IUpdateSubscriberService, UpdateSubscriberService>();
            services.AddScoped<IDeleteSubscriberService, DeleteSubscriberService>();
            services.AddScoped<ISearchSubscriberService, SearchSubscriberService>();
        }
    }
}
