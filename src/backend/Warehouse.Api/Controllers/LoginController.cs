using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("singin")]
    public async Task<IActionResult> SingIn()
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> LogOut()
    {
        await Task.Delay(1);
        return Ok();
    }
}