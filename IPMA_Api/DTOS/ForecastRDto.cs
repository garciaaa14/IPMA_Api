namespace IPMA_Api.DTOS
{
    public class ForecastRDto
    {
        public DateTime Date { get; set; }
        public int PrecipitationProbability { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public string WindDirection { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        public string WindDescription { get; set; }
        public string PrecipitationDescription { get; set; }
    }
}
