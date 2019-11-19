using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RouteVersioningIssue.Controllers
{
    [ApiController]
    [Route("a{version:apiVersion}/[controller]")]
    [ApiVersion("1-literAl")]
    [ApiVersion("1-preview")]
    [ApiVersion("1")]
    public class WeatherForecastVersionLiteralAController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastVersionLiteralAController> _logger;

        public WeatherForecastVersionLiteralAController(ILogger<WeatherForecastVersionLiteralAController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}