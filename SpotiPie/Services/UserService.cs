using Microsoft.AspNetCore.Authentication;
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

    public async Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto)
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

    public async Task<UserGetDto?> GetByLoginAsync(UserCredentialsDto userCredentialsDto)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == userCredentialsDto.Login);

        if (user is null) return null;

        var userDto = user.Adapt<UserGetDto>();

        return userDto;
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
