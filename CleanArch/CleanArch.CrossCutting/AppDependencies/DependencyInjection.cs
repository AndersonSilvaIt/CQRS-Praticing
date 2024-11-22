﻿using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
                                                            IConfiguration configuration)
        {
            var sqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnection));

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}