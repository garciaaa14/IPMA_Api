using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class WindDto
    {
        
        [JsonPropertyName("classWindSpeed")]
        public int Class { get; set; }

        [JsonPropertyName("descClassWindSpeedDailyPT")]
        public string DescriptionPt { get; set; }

        [JsonPropertyName("descClassWindSpeedDailyEN")]
        public string DescriptionEn { get; set; }
        
    }
}
