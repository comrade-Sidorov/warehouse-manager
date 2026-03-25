using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Warehouse.DAL.Entities;

namespace Warehouse.Api;

public class TokenService
{
    private readonly IConfiguration _config;
    private readonly string _secretKey;
    private readonly int _accessTokenExpiryMinutes;

    public TokenService(IConfiguration config)
    {
        _config = config;
        _secretKey = _config["ApiSettings:Secret"] ?? throw new ArgumentNullException("secret");
        _accessTokenExpiryMinutes = _config.GetValue<int>("ApiSettings:AccessTokenExpiryMinutes", 60);
    }

    public string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, 1.ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "user")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["ApiSettings:Issuer"],
            audience: _config["ApiSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(_accessTokenExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}