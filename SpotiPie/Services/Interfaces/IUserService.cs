using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface IUserService
{
    public Task<UserGetDto> SignUpAsync(UserCreateDto userDto);
}
