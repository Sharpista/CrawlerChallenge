namespace Crawler.Configurations.Extensions
{
    public class SettingsOptions
    {
        public SevidorProxyOptions? SevidorProxy { get; init; }
    }
    public class SevidorProxyOptions
    {
        public string? Url { get; set; }
    }
}
