using Crawler.Services.Base;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Crawler.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILogger<HttpClientService> _logger;

        public HttpClientService(HttpClient? httpClient, ILogger<HttpClientService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> CrawlerServidoresProxy(string url, CancellationToken cancellationToken)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient!.SendAsync(requestMessage, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            return responseString;
        }

        public async Task<string> EnviarServidoresProxy(string url, string? request, CancellationToken cancellationToken)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(request!, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient!.SendAsync(requestMessage, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            return responseString;
        }
    }
}
