using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  [EnableCors]
  public class TestController : ControllerBase {
    [HttpGet]
    public IActionResult GetStatus() {
      return Ok();
    }
  }
}
