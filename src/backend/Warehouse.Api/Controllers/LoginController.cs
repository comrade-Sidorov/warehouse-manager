using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly TokenService _tokenService;

    public LoginController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }
    [HttpPost("singin")]
    public async Task<ActionResult<string>> SingIn(
        [FromBody] string name)
    {
        var token = _tokenService.GenerateToken(name);
        return Ok(token);
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