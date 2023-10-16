using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChessApi.Controllers;

public class WeatherForecastData
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly IEnumerable<WeatherForecast> data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Id = index,
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    });
    
    private static readonly IEnumerator<WeatherForecast> enumerator = data.GetEnumerator();

    private static bool MoveNext()
    {
        return enumerator.MoveNext();
    }

    public static WeatherForecast? GetWeatherForecast()
    {
        return MoveNext() == true ? enumerator.Current : null;
    }
};

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public WeatherForecast? Get()
    {
        WeatherForecast? data = WeatherForecastData.GetWeatherForecast();

        return data;
    }
}
