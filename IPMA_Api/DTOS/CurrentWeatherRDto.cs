namespace IPMA_Api.DTOS
{
    public class CurrentWeatherRDto
    {
        public string Local { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string WindDescription { get; set; }
        public double PrecipitationAccumulated { get; set; }
        public double Radiation { get; set; }

    }
}
