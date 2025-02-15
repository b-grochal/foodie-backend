﻿using Foodie.Common.Application.Authorization;
using Foodie.Shared.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Foodie.Orders.Application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection AddOrdersApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationInstaller).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>)); // TODO: Move it to API project 
            services.AddAuthorizersFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
