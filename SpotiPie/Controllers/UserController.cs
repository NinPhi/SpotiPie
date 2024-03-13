using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiPie.Data;
using SpotiPie.Entity;
using SpotiPie.Services.Interface;
using System.Reflection.Metadata;

namespace SpotiPie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(UserDto userDto)
        {
            var user = await _userService.SignUpAsync(userDto);
            return Ok(user);
        }

    }
}
