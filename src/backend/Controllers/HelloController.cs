using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet(Name = "Hi")]
    public IActionResult Get()
    {
        return Ok("hi");
    }
}