using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AspireApp1.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AspireApp1.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {

    private readonly IConfiguration _configuration;

    public AuthController( IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        var userName = loginModel.UserName;
        var password = loginModel.Password;

        if (userName == "admin" && password == "admin") {
            var token = GenerateJwtToken(userName);
            return Ok(new LoginResponseModel {
                Token = token
            });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(string userName) {
        Claim[] claims = [new(ClaimTypes.Name, userName), new(ClaimTypes.Role, "Admin")];
        var secret = _configuration.GetValue<string>("Jwt:Secret");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: "truereality",
            audience: "truereality",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}