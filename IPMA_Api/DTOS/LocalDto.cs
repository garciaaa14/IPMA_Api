using System.Text.Json.Serialization;

namespace IPMA_Api.DTOS
{
    public class LocalDto
    {
        [JsonPropertyName("globalIdLocal")]
        public int GlobalIdLocal { get; set; }

        [JsonPropertyName("local")]
        public string Name { get; set; }
    }
}
