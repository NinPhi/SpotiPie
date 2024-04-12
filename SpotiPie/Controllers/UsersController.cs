using Microsoft.AspNetCore.Authorization;

namespace SpotiPie.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UsersController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
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

        var identity = _authService.CreateClaimsIdentity(user);
        var token = _authService.GenerateJwt(identity);

        return Ok(new
        {
            Bearer = token,
        });
    }
}
