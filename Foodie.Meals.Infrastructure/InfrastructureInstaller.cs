﻿using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Authentication;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Database.Interceptors;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Infrastructure.Database;
using Foodie.Meals.Infrastructure.Database.Repositories;
using Foodie.Meals.Infrastructure.Database.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Meals.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddMealsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<SoftDeleteForBaseEntitiesInterceptor>();

            services.AddDbContext<MealsDbContext>((sp, options) => options
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("DbConnection"))
                .AddInterceptors(
                    sp.GetRequiredService<SoftDeleteForBaseEntitiesInterceptor>())
            );

            services.AddCache(configuration);

            services.AddScoped<IUnitOfWork, MealsUnitOfWork>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.Decorate<ICategoriesRepository, CachedCategoriesRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.Decorate<ICitiesRepository, CachedCitiesRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.Decorate<ILocationsRepository, CachedLocationsRepository>();
            services.AddScoped<IMealsRepository, MealsRepository>();
            services.Decorate<IMealsRepository, CachedMealsRepository>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.Decorate<IRestaurantsRepository, CachedRestaurantsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.Decorate<ICountriesRepository, CachedCountriesRepository>();
            services.AddTransient<IApplicationUserContext, ApplicationUserContext>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
