using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class ForecastDto
    {
        [JsonPropertyName("precipitaProb")]
        public int PrecipitaProb { get; set; }

        [JsonPropertyName("tMin")]
        public double TempMin { get; set; }

        [JsonPropertyName("tMax")]
        public double TempMax { get; set; }

        [JsonPropertyName("predWindDir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("idWeatherType")]
        public int WeatherTypeId { get; set; }

        [JsonPropertyName("classWindSpeed")]
        public int WindSpeedClass { get; set; }

        [JsonPropertyName("classPrecInt")]
        public int PrecipitationClass { get; set; }

        [JsonPropertyName("forecastDate")]
        public DateTime Date { get; set; }
    }
}
