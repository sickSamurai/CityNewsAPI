using Application.Interfaces;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Service.Controllers {
  [EnableCors]
  [ApiController]
  [Route("api/v1/[controller]")]
  public class WeatherController : ControllerBase {
    public IWeatherApplication WeatherApplication { get; set; }
    public WeatherController(IWeatherApplication weatherApplication) {
      this.WeatherApplication = weatherApplication;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(double lat, double lon) {
      var response = await WeatherApplication.GetWeather(lat, lon);
      return Ok(response);
    }
  }
}
