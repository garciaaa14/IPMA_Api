using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class WeatherTypeDto
    {
        [JsonPropertyName("idWeatherType")]
        public int Id { get; set; }

        [JsonPropertyName("descWeatherTypePT")]
        public string DescriptionPt { get; set; }

        [JsonPropertyName("descWeatherTypeEN")]
        public string DescriptionEn { get; set; }

        [JsonPropertyName("idWeatherIcon")]
        public int IconId { get; set; }
    }
}
