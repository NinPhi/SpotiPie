using Microsoft.AspNetCore.Authentication;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;
using System.Security.Claims;

namespace SpotiPie.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly HttpContext _httpContext;

    public UserService(AppDbContext dbContext, IHttpContextAccessor accessor)
    {
        _dbContext = dbContext;

        if (accessor.HttpContext is null)
        {
            throw new ArgumentException(nameof(accessor.HttpContext));
        }

        _httpContext = accessor.HttpContext;
    }

    public async Task<UserGetDto> SignUpAsync(UserCreateDto userDto)
    {
        var user = new User()
        {
            Login = userDto.Login!,
            Password = userDto.Password!,
            Roles = "User"
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        var userGetDto = new UserGetDto
        {
            Id = user.Id,
            Login = user.Login,
            Roles = user.Roles,
        };

        await SignInWithHttpContext(userGetDto);

        return userGetDto;
    }

    private Task SignInWithHttpContext(UserGetDto userDto)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
            new(ClaimTypes.Name, userDto.Login),
            new(ClaimTypes.Role, userDto.Roles),
        };

        var claimsIdentity = new ClaimsIdentity(claims, "cookie");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return _httpContext.SignInAsync(claimsPrincipal);
    }
}
