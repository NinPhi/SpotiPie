using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Services.Interfaces;

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
    public async Task<ActionResult> SignUp(UserCreateDto userDto)
    {
        var user = await _userService.SignUpAsync(userDto);
        return Ok(user);
    }
}
