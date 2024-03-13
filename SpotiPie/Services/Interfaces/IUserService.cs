using SpotiPie.Contracts;
using SpotiPie.Entities;

namespace SpotiPie.Services.Interface
{
    public interface IUserService
    {
        Task<User> SignUpAsync(UserDto userDto);
    }
}
