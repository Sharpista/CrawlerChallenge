using Crawler.Application.Modules;
using Crawler.BackgroudServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);
        services.AddHostedService<CrawlerBackgroundService>();
        services.AddModuleCrawler();
    })
.ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
.Build();

await host.RunAsync();
