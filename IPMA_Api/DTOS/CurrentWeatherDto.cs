using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class CurrentWeatherDto
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("rh")]
        public double Humidity { get; set; }

        [JsonPropertyName("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("windDirection")]
        public string WindDirection { get; set; }

        [JsonPropertyName("precipitationIntensity")]
        public double Precipitation { get; set; }

        [JsonPropertyName("radiation")]
        public double Radiation { get; set; }
    }

}
