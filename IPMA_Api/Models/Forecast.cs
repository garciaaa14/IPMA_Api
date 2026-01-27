namespace IPMA_Api.Models
{
    public class Forecast
    {
        public string precipitaProb { get; set; }
        public double tMin { get; set; }
        public double tMax { get; set; }
        public string predWindDir { get; set; }
        public int idWeatherType { get; set; }
        public int classWindSpeed { get; set; }
        public int classPrecInt { get; set; }
        public DateTime forecastDate { get; set; }

    }
}
