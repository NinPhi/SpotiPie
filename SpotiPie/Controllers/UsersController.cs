using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace SpotiPie.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult> Register(UserCredentialsDto userDto)
    {
        var userGetDto = await _userService.SignUpAsync(userDto);

        return Ok(userGetDto);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> Login(UserCredentialsDto userDto)
    {
        var user = await _userService.GetByLoginAsync(userDto);

        if (user == null)
            return Unauthorized();

        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Login),
            new(ClaimTypes.Role, user.Roles),
        };

        var identity = new ClaimsIdentity(claims, "cookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(principal);

        return NoContent();
    }

    [HttpPost("sign-out")]
    public async Task<ActionResult> Logout()
    {
        if (HttpContext.User.Identity == null)
            return NoContent();

        await HttpContext.SignOutAsync();

        return NoContent();
    }
}
