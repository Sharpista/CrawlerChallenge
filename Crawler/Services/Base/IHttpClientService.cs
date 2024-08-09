namespace Crawler.Services.Base
{
    public interface IHttpClientService
    {
        public Task<string> CrawlerServidoresProxy(string url, CancellationToken cancellationToken);
        public Task<string> EnviarServidoresProxy(string url, string? request, CancellationToken cancellationToken);
    }
}
