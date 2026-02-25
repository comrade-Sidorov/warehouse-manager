using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("singin")]
    public async Task<ActionResult<string>> SingIn(
        [FromBody] string name
    )
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very-VERY-very-secret-key-KEY-AAAAAaaaaaa"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new []
        {
            new Claim(ClaimTypes.Name, name)
        };

        var token = new JwtSecurityToken(
            issuer: "http://localhost:5083",
            audience: "http://localhost:5083", 
            claims: claims, 
            expires:DateTime.Now.AddHours(1), 
            signingCredentials: credentials);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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