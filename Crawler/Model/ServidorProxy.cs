using System.Text.Json.Serialization;

namespace Crawler.Model
{
    public class ServidorProxy
    {
        [JsonPropertyName("alive")]
        public bool? Alive { get; set; }

        [JsonPropertyName("alive_since")]
        public double? AliveSince { get; set; }

        [JsonPropertyName("anonymity")]
        public string? Anonymity { get; set; }

        [JsonPropertyName("average_timeout")]
        public double? AverageTimeout { get; set; }

        [JsonPropertyName("first_seen")]
        public double? FirstSeen { get; set; }

        [JsonPropertyName("ip_data")]
        public ServidorIp? IpData { get; set; }

        [JsonPropertyName("ip_data_last_update")]
        public double? IpDataLastUpdate { get; set; }

        [JsonPropertyName("last_seen")]
        public double? LastSeen { get; set; }

        [JsonPropertyName("port")]
        public int? Port { get; set; }

        [JsonPropertyName("protocol")]
        public string? Protocol { get; set; }

        [JsonPropertyName("proxy")]
        public string? Proxy { get; set; }

        [JsonPropertyName("ssl")]
        public bool? Ssl { get; set; }

        [JsonPropertyName("timeout")]
        public double? Timeout { get; set; }

        [JsonPropertyName("times_alive")]
        public int? TimesAlive { get; set; }

        [JsonPropertyName("times_dead")]
        public int? TimesDead { get; set; }

        [JsonPropertyName("uptime")]
        public double? Uptime { get; set; }

        [JsonPropertyName("ip")]
        public string? Ip { get; set; }
    }
}
