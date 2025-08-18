using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class DashboardsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Dashbord from backend");
    }
}