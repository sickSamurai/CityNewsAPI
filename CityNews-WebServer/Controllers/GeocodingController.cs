using Application.Apps;
using Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace Service.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  public class GeocodingController : ControllerBase {
    private readonly IGeocodingApplication _geocodingApplication;

    public GeocodingController(IGeocodingApplication historialApplication) {
      _geocodingApplication = historialApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string cityName) {
      var response = await _geocodingApplication.GetCities(cityName);
      return Ok(response);
    }
  }
}
