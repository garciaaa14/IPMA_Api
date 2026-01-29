using Microsoft.AspNetCore.Mvc;
using IPMA_Api.Services;
using IPMA_Api.Models;
using IPMA_Api.DTOS;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly Repository _repository;

    public WeatherController(Repository repository)
    {
        _repository = repository;
    }

    // =========================
    // LISTA DE LOCAIS
    // =========================
    [HttpGet("locations")]
    public async Task<ActionResult<List<Local>>> GetLocations()
    {
        var locations = await _repository.GetLocations();
        return Ok(locations);
    }

    // =========================
    // TEMPO ATUAL
    // =========================
    [HttpGet("current/{locationId}")]
    public async Task<ActionResult<CurrentWeather>> GetCurrentWeather(int locationId)
    {
        var weather = await _repository.GetCurrentWeather(locationId);

        if (weather == null)
            return NotFound("Local não encontrado");

        return Ok(weather);
    }

    // =========================
    // PREVISÃO 5 DIAS
    // =========================
    [HttpGet("forecast/{locationId}")]
    public async Task<ActionResult<List<Forecast>>> GetForecast(int locationId)
    {
        var forecast = await _repository.GetForecast(locationId);
        return Ok(forecast);
    }
}
