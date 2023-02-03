using Application.Interfaces;

using Domain.Business.GeocodingApi;
using Domain.Entities;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace Service.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  [EnableCors]
  public class HistorialController : ControllerBase {
    private readonly IHistorialApplication HistorialApplication;

    public HistorialController(IHistorialApplication historialApplication) {
      HistorialApplication = historialApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var response = await HistorialApplication.GetHistorial();
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostCity(CityObject city) {
      City cityDTO = new City {
        ID = Guid.NewGuid().ToString(),
        Name = city.Name,
        Country = city.Country,
        Lat = city.Lat,
        Lon = city.Lon
      };
      var response = await HistorialApplication.SaveToDB(cityDTO);
      return Ok(response);
    }
  }
}
