using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SpotiPie.Services;

public class AuthService(IConfiguration configuration) : IAuthService
{
    public ClaimsIdentity CreateClaimsIdentity(UserGetDto user)
    {
        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim("role", user.Role),
        ];

        var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

        return identity;
    }

    public string GenerateJwt(ClaimsIdentity claimsIdentity)
    {
        var handler = new JwtSecurityTokenHandler();

        var securityKey = Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]!);

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
