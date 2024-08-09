using Crawler.Model;

namespace Crawler.Services.Base
{
    public interface ICrawlerService
    {
        Task<string> CrawlerServidoresProxy(CancellationToken cancellationToken);

        string CrawlerServidoresProxySelenium(CancellationToken cancellationToken);
    }
}
