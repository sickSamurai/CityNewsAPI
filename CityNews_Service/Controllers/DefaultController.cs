using Microsoft.AspNetCore.Mvc;

namespace CityNews_Service.Controllers {
  [ApiController]
  [Route("/")]
  public class DefaultController: ControllerBase {
    [HttpGet]
    public IActionResult GetStatus() { 
      return Ok();
    }
  }
}
