using CityNews_Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CityNews_Service.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  public class CityNewsController : ControllerBase {
    private readonly ICityNewsApplication _cityNewsApplication;

    public CityNewsController(ICityNewsApplication cityNewsApplication) {
      _cityNewsApplication = cityNewsApplication;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> Post(string city) {
      var response = await _cityNewsApplication.GetNews(city);
      return Ok(response);
    }

  }
}
