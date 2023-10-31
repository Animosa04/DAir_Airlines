using Microsoft.AspNetCore.Mvc;

namespace DAir_Airlines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DAirController : Controller
    {
        private readonly ILogger<DAirController> _logger;

        public DAirController(ILogger<DAirController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "FirstQuery")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
