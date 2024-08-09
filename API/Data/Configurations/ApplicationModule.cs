using API.Data.Context;
using API.Data.Repositories;
using API.Domain.Interfaces.Common;
using API.Service;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Configurations
{
    public static class ApplicationModule
    {
        public static void AdicionarDependencias(this IServiceCollection services)
        {
            services.AddContext();
            services.AddInjections();
        }

        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            return services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("DB"));
            });
        }

        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IServidorProxyService, ServidorProxyService>();
            services.AddTransient<IServidorProxyRepository,ServidorProxyRepository>();

            return services;
        }
    }
}
