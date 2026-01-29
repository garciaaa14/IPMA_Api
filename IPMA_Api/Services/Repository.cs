using System.Text.Json;
using IPMA_Api.Models;

namespace IPMA_Api.Services
{
    public class Repository
    {
        private string baseUrl = "https://api.ipma.pt";

        private readonly HttpClient _http;

        public Repository(HttpClient http)
        {
            _http = http;
        }

        // =========================
        // LISTA DE LOCAIS
        // =========================
        public async Task<List<Local>> GetLocations()
        {
            var url = $"{baseUrl}/open-data/distrits-islands.json";

            var json = await _http.GetStringAsync(url);
            var root = JsonDocument.Parse(json).RootElement;

            var list = new List<Local>();

            foreach (var item in root.GetProperty("data").EnumerateArray())
            {
                list.Add(new Local
                {
                    globalIdLocal = item.GetProperty("globalIdLocal").GetInt32(),
                    local = item.GetProperty("local").GetString()
                });
            }

            return list.OrderBy(l => l.local).ToList();
        }

        // =========================
        // TEMPO ATUAL
        // =========================
        public async Task<CurrentWeather> GetCurrentWeather(int localId)
        {
            var url = $"{baseUrl}/open-data/observation/meteorology/stations/observations.json";

            var json = await _http.GetStringAsync(url);
            var root = JsonDocument.Parse(json).RootElement;

            // ⚠️ O IPMA usa o ID como string
            var station = root.GetProperty(localId.ToString());

            var current = new CurrentWeather
            {
                temperature = GetDouble(station, "temp"),
                humidity = GetDouble(station, "humidity"),
                precAcumulated = GetDouble(station, "precipitation"),
                windIntensityKm = GetDouble(station, "windSpeed"),
                WindDirection = station.GetProperty("windDir").GetString(),
                radiation = GetDouble(station, "rad")
            };

            return current;
        }

        // =========================
        // PREVISÃO 5 DIAS
        // =========================
        public async Task<List<Forecast>> GetForecast(int localId)
        {
            var url = $"{baseUrl}/open-data/forecast/meteorology/cities/daily/{localId}.json";

            var json = await _http.GetStringAsync(url);
            var root = JsonDocument.Parse(json).RootElement;

            var weatherTypes = await GetWeatherTypes();
            var windTypes = await GetWindTypes();

            var list = new List<Forecast>();

            foreach (var day in root.GetProperty("data").EnumerateArray().Take(5))
            {
                int weatherTypeId = day.GetProperty("idWeatherType").GetInt32();
                int windClassId = day.GetProperty("classWindSpeed").GetInt32();

                list.Add(new Forecast
                {
                    forecastDate = DateTime.Parse(day.GetProperty("forecastDate").GetString()),
                    tMin = GetDouble(day, "tMin"),
                    tMax = GetDouble(day, "tMax"),
                    precipitaProb= GetDouble(day, "precipitaProb"),
                    weatherType = weatherTypes.ContainsKey(weatherTypeId) ? weatherTypes[weatherTypeId] : "Desconhecido",
                    windSpeed = windTypes.ContainsKey(windClassId) ? windTypes[windClassId] : "Desconhecido",
                    predWindDir = day.GetProperty("predWindDir").GetString(),
                    rainIntensity = GetDouble(day, "precipitaIntensity"),
                    icon = $"w_ic_d_{weatherTypeId:00}.png"
                });
            }

            return list;
        }

        // =========================
        // TABELAS AUXILIARES
        // =========================

        private async Task<Dictionary<int, string>> GetWeatherTypes()
        {
            var url = $"{baseUrl}/open-data/weather-type-classe.json";
            var json = await _http.GetStringAsync(url);
            var root = JsonDocument.Parse(json).RootElement;

            var dict = new Dictionary<int, string>();

            foreach (var item in root.GetProperty("data").EnumerateArray())
            {
                dict[item.GetProperty("idWeatherType").GetInt32()] =
                    item.GetProperty("descWeatherTypePT").GetString();
            }

            return dict;
        }

        private async Task<Dictionary<int, string>> GetWindTypes()
        {
            var url = $"{baseUrl}/open-data/wind-speed-daily-classe.json";
            var json = await _http.GetStringAsync(url);
            var root = JsonDocument.Parse(json).RootElement;

            var dict = new Dictionary<int, string>();

            foreach (var item in root.GetProperty("data").EnumerateArray())
            {
                dict[item.GetProperty("classWindSpeed").GetInt32()] =
                    item.GetProperty("descClassWindSpeedDailyPT").GetString();
            }

            return dict;
        }

        // =========================
        // FUNÇÃO DE SEGURANÇA
        // =========================
        private double GetDouble(JsonElement el, string prop)
        {
            if (!el.TryGetProperty(prop, out var p)) return 0;
            if (p.ValueKind == JsonValueKind.Null) return 0;
            if (p.ValueKind == JsonValueKind.String && string.IsNullOrEmpty(p.GetString())) return 0;

            return p.GetDouble();
        }
    }
}
