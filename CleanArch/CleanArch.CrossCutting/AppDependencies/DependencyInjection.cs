using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;

namespace CleanArch.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
                                                            IConfiguration configuration)
        {
            var sqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnection));

            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new SqlConnection(sqlConnection);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(myHandlers);
                //cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

           // services.AddValidatorsFromAssembly(Assembly.Load("CleanArch.Application"));

            return services;
        }
    }
}