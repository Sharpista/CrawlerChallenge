using System.Text.Json.Serialization;

namespace Crawler.Model
{
    public class ServidorIp
    {
        [JsonPropertyName("as")]
        public string? As { get; set; }

        [JsonPropertyName("asname")]
        public string? AsName { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("continent")]
        public string? Continent { get; set; }

        [JsonPropertyName("continentCode")]
        public string? ContinentCode { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("district")]
        public string? District { get; set; }

        [JsonPropertyName("hosting")]
        public bool Hosting { get; set; }

        [JsonPropertyName("isp")]
        public string? Isp { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("mobile")]
        public bool Mobile { get; set; }

        [JsonPropertyName("org")]
        public string? Org { get; set; }

        [JsonPropertyName("proxy")]
        public bool Proxy { get; set; }

        [JsonPropertyName("regionName")]
        public string? RegionName { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("zip")]
        public string? Zip { get; set; }
    }
}
