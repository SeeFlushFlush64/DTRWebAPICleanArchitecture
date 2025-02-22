using DTRProject.Application;
using DTRProject.Infrastructure;

namespace DTRProject.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            
            services.AddApplicationDI().AddInfrastructureDI();
            return services;
        }
    }
}
