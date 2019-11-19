using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RouteVersioningIssue.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1-preView")]
    [ApiVersion("1-status")]
    [ApiVersion("1")]
    public class WeatherForecastVersionLiteralVController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastVersionLiteralVController> _logger;

        public WeatherForecastVersionLiteralVController(ILogger<WeatherForecastVersionLiteralVController> logger)
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
