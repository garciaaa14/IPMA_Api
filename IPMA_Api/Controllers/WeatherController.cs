// /Controllers/WeatherController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IpmaService _ipmaService;

    public WeatherController(IpmaService ipmaService)
    {
        _ipmaService = ipmaService;
    }

    [HttpGet("locations")]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await _ipmaService.GetLocationsAsync();
        return Ok(locations);
    }

    [HttpGet("current/{locationId}")]
    public async Task<IActionResult> GetCurrentWeather(int locationId)
    {
        var weather = await _ipmaService.GetCurrentWeatherAsync(locationId);
        return Ok(weather);
    }

    [HttpGet("forecast/{locationId}")]
    public async Task<IActionResult> GetForecast(int locationId)
    {
        var forecast = await _ipmaService.GetForecastAsync(locationId);
        return Ok(forecast);
    }
}
