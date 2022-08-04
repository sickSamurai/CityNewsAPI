using CityNews_Application.Interfaces;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CityNews_Service.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  public class WeatherController : ControllerBase {
    public IWeatherApplication WeatherApplication { get; set; }
    public WeatherController(IWeatherApplication weatherApplication) {
      this.WeatherApplication = weatherApplication;
    }

    [EnableCors]
    [HttpGet]
    public async Task<IActionResult> Get(double lat, double lon) {
      var response = await WeatherApplication.GetWeatherInfo(lat, lon);
      return Ok(response);
    }
  }
}
