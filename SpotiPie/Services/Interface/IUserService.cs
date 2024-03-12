using SpotiPie.Entity;

namespace SpotiPie.Services.Interface
{
    public interface IUserService
    {
        Task<User> SignUpAsync(UserDto userDto);
    }
}
