using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SpotiPie.Application.Services;

public class AuthService(IConfiguration configuration) : IAuthService
{
    private readonly IConfiguration _configuration = configuration;

    public ClaimsIdentity CreateClaimsIdentity(UserGetDto user)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim("role", user.Role),
        };

        var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

        return identity;
    }

    public string GenerateJwt(ClaimsIdentity claimsIdentity)
    {
        var handler = new JwtSecurityTokenHandler();

        var securityKey = Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]!);

        var credentials = new SigningCredentials(
                    new SymmetricSecurityKey(securityKey),
                    SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddMinutes(30),
            Subject = claimsIdentity,
        };

        var token = handler.CreateToken(tokenDescriptor);

        var tokenString = handler.WriteToken(token);

        return tokenString;
    }
}
