using System.Text.Json.Serialization;

namespace Crawler.Model
{
    public class ApiResult<TData>
    {
        [JsonPropertyName("proxies")]
        public TData? Data { get; set; }
    }
}
