using CityNews_Application.Interfaces;

using CityNews_Domain.Business.GeocodingApi;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CityNews_Service.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  public class HistorialController : ControllerBase {
    private readonly IHistorialApplication _historialApplication;

    public HistorialController(IHistorialApplication historialApplication) {
      _historialApplication = historialApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var response = await _historialApplication.GetHistorial();
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostCity(CityData city) {      
      var response = await _historialApplication.SaveToDB(city);
      return Ok(response);
    }
  }
}
