using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class PrecipitaDto
    {
        [JsonPropertyName("classPrecInt")]
        public int Class { get; set; }

        [JsonPropertyName("descClassPrecIntPT")]
        public string DescriptionPt { get; set; }

        [JsonPropertyName("descClassPrecIntEN")]
        public string DescriptionEn { get; set; }
    }
}
