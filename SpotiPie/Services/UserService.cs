using Microsoft.AspNetCore.Authentication;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;
using System.Security.Claims;

namespace SpotiPie.Services;

public class UserService: IUserService
{
    private readonly AppDbContext _appDbContext;
    private readonly HttpContext _httpContext;

    public UserService(AppDbContext appDbContext, IHttpContextAccessor accessor)
    {
        _appDbContext = appDbContext;

        if (accessor.HttpContext == null)
        {
            throw new ArgumentException(nameof(accessor.HttpContext));
        }
        _httpContext = accessor.HttpContext;
    }

    public async Task<User> SignUpAsync(UserDto userDto)
    {
        User user = new()
        {
            Login = userDto.Login,
            Password = userDto.Password,
            Roles = "User"
        };

        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Login),
            new(ClaimTypes.Role, user.Roles.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(claims, "cookie");
        await _httpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        return user;
    }
}
