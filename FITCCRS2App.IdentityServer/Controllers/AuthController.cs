using FITCCRS2App.Services.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace FITCCRS2App.IdentityServer.Controllers;

[ApiController]
[Route("[action]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration Configuration;
    private readonly IUserService _userService;

    public AuthController(
        IConfiguration configuration,
        IUserService userService)
    {
        Configuration = configuration;
        _userService = userService;
    }

    [HttpGet]
    public async Task<string> Login(string email, string password)
    {
        var user = await _userService.GetByEmailAndPasswordAsync(email, password);

        if (user is null)
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return String.Empty;
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecret")!));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, user.UserId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Email),
            new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
            new Claim(ClaimTypes.Email, user.Email)
        };

        user.Roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.ToString())));

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}