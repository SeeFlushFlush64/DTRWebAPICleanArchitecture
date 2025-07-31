using DTRProject.Domain.Interfaces;
using DTRProject.Infrastructure.Data;
using DTRProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>
            (
                options =>
                {
                    options.UseSqlServer("Server=MICHAELRHEY\\SQLEXPRESS;Database=DTRDb;TrustServerCertificate=true;Trusted_connection=true;");
                }
            );

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITimeLogRepository, TimeLogRepository>();
            return services;
        }
    }
}
