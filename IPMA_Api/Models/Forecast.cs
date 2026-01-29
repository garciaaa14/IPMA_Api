public class Forecast
{
    public DateTime forecastDate { get; set; }

    public double tMin { get; set; }
    public double tMax { get; set; }

    public double precipitaProb { get; set; }

    public string weatherType { get; set; }
    public string windSpeed { get; set; }
    public double rainIntensity { get; set; }

    public string predWindDir { get; set; }

    public string icon { get; set; }
}
