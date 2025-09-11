using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Test : ControllerBase
{
    [HttpGet("test")]
    public IActionResult TestString([Required][FromQuery] string testString)
    {
        return Ok();
    }
}