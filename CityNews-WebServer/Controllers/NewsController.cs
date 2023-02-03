using Application.Interfaces;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Service.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  [EnableCors]
  public class NewsController : ControllerBase {
    private readonly INewsApplication newsApplication;

    public NewsController(INewsApplication newsApplication) {
      this.newsApplication = newsApplication;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> Get(string city) {
      var response = await newsApplication.GetNews(city);
      return Ok(response);
    }

  }
}
