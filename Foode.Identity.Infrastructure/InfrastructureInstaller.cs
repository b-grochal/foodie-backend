﻿using Foode.Identity.Infrastructure.Repositories;
using Foode.Identity.Infrastructure.Services;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Foode.Identity.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<IApplicationUsersRepository, ApplicationUsersRepository>();
            services.AddTransient<IAdminsRepository, AdminsRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IOrderHandlersRepository, OrderHandlersRepository>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IPasswordService, PasswordService>();

            return services;
        }
    }
}
