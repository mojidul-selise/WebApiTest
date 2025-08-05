using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebApiVersioning.Models;

namespace WebApiVersioning.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/weather")]
    [ApiVersion("2.0")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ServiceResponseModel> Get()
        {
            var response = new ServiceResponseModel();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
            response.SuccessResponse("Data Get from Version 2.0", data);
            return response;
        }
    }
}
