using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace SpotiPie.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;
    private readonly HttpContext _httpContext;

    public UserService(AppDbContext dbContext, IPasswordManager passwordManager, IHttpContextAccessor accessor)
    {
        _dbContext = dbContext;

        _passwordManager = passwordManager;

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
            PasswordHash = _passwordManager.HashPassword(userDto.Password!),
            Role = "User"
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        var userGetDto = new UserGetDto
        {
            Id = user.Id,
            Login = user.Login,
            Roles = user.Role,
        };

        await SignInWithHttpContext(userGetDto);

        return userGetDto;
    }

    public Task SignInAsync(UserGetDto userGetDto)
    {
        return SignInWithHttpContext(userGetDto);
    }

    public async Task<UserGetDto?> GetByLoginAsync(UserCredentialsDto userCredentialsDto)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == userCredentialsDto.Login);

        if (user is null) return null;

        if (!_passwordManager.VerifyPassword(userCredentialsDto.Password!, user.PasswordHash))
            return null;

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
