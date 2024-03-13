using SpotiPie.Contracts;
using SpotiPie.Entities;

namespace SpotiPie.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> SignUpAsync(UserDto userDto);
    }
}
