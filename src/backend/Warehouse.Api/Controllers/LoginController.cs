using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

public class LoginController : ControllerBase
{
    public async Task<IActionResult> SingIn()
    {
        await Task.Delay(1);
        return Ok();
    }

    public async Task<IActionResult> Register()
    {
        await Task.Delay(1);
        return Ok();
    }

    public async Task<IActionResult> LogOut()
    {
        await Task.Delay(1);
        return Ok();
    }
}