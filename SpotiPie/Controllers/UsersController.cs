using Microsoft.AspNetCore.Authorization;

namespace SpotiPie.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/users")]
public class UsersController(IUserService userService, IAuthService authService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<ActionResult> Register(UserCredentialsDto userDto)
    {
        var userGetDto = await userService.SignUpAsync(userDto);

        return Ok(userGetDto);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> Login(UserCredentialsDto userDto)
    {
        var user = await userService.GetByLoginAsync(userDto);

        if (user == null)
            return Unauthorized();

        var identity = authService.CreateClaimsIdentity(user);
        var token = authService.GenerateJwt(identity);

        return Ok(new
        {
            Bearer = token,
        });
    }
}
