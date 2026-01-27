namespace IPMA_Api.Models
{
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double humidity { get; set; }
        public double windIntensityKm { get; set; }
        public string WindDirection { get; set; }
        public double precAcumulated{ get; set; }
        public double radiation { get; set; }

    }
}
