using Microsoft.AspNetCore.Mvc;

namespace GuildView.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : Controller
{
    [HttpGet]
    public IActionResult DemoGet()
    {
        return NoContent();
    }
}