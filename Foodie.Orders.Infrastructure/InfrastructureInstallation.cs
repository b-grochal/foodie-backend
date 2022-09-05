﻿using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Infrastructure.Contexts;
using Foodie.Orders.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure
{
    public static class InfrastructureInstallation
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IBuyersRepository, BuyersRepository>();
            services.AddScoped<IContractorsRepository, ContractorsRepository>();

            return services;
        }
    }
}