using DTRProject.Application;
using DTRProject.Infrastructure;

namespace DTRProject.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            //services.AddControllers()
            //        .AddJsonOptions(options =>
            //        {
            //            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //            options.JsonSerializerOptions.WriteIndented = true;
            //        });
            services.AddApplicationDI().AddInfrastructureDI();
            return services;
        }
    }
}
