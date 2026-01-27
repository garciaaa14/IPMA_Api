namespace IPMA_Api.DTOS
{
    public class ForecastListRDto
    {
        public string Local { get; set; }
        public List<ForecastRDto> Forecasts { get; set; }
    }
}
