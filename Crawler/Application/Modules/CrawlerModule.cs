using Crawler.Configurations.Extensions;
using Crawler.Services;
using Crawler.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.Application.Modules
{
    public static class CrawlerModule
    {
        public static void AddModuleCrawler(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetSection("SettingsOptions");
            services.Configure<SettingsOptions>(configuration);
            services.ConfigureInjections();
        }

        public static IServiceCollection ConfigureInjections(this IServiceCollection services)
        {
         
            services.AddHttpClient();
            services.AddTransient(typeof(ICrawlerService), typeof(CrawlerService));
            services.AddTransient(typeof(IHttpClientService), typeof(HttpClientService));

            return services;
        }

       
    }
}
