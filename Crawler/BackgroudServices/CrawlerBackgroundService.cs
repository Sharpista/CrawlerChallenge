using Crawler.Services.Base;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crawler.BackgroudServices
{
    public class CrawlerBackgroundService : BackgroundService
    {
        const string BASE = "https://localhost:7010/";
        const string PATH = "api/v1/servidores/data";
        private readonly ICrawlerService _crawlerService;
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<CrawlerBackgroundService> _logger;

        public CrawlerBackgroundService(ICrawlerService crawlerService, 
                                        ILogger<CrawlerBackgroundService> logger, 
                                        IHttpClientService httpClientService)
        {
            _crawlerService = crawlerService;
            _logger = logger;
            _httpClientService = httpClientService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CrawlerBackgroundService está iniciando");

            stoppingToken.Register(() => _logger.LogInformation("CrawlerBackgroundService está parando"));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("CrawlerBackgroundService está realizando o serviço em segundo plano");
                
                var crawlerResult = _crawlerService.CrawlerServidoresProxySelenium(stoppingToken);
                var result = await _httpClientService.EnviarServidoresProxy(BASE + PATH, crawlerResult, stoppingToken);

                _logger.LogInformation("CrawlerBackgroundService irá parar por 5 minutos");

                await Task.Delay(TimeSpan.FromMinutes(5), CancellationToken.None);
            }


            _logger.LogInformation("CrawlerBackgroundService está foi parado");

        }
    }
}
