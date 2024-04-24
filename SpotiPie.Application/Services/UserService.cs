using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IPasswordManager passwordManager) : IUserService
{
    public async Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto)
    {
        var user = new User()
        {
            Login = userDto.Login!,
            PasswordHash = passwordManager.HashPassword(userDto.Password!),
            Role = "User"
        };

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync();

        var userGetDto = new UserGetDto
        {
            Id = user.Id,
            Login = user.Login,
            Role = user.Role,
        };

        return userGetDto;
    }

    public async Task<UserGetDto?> GetByLoginAsync(UserCredentialsDto userCredentialsDto)
    {
        var user = await userRepository.GetByLoginAsync(userCredentialsDto.Login!);

        if (user is null) return null;

        if (!passwordManager.VerifyPassword(userCredentialsDto.Password!, user.PasswordHash))
            return null;

        var userDto = user.Adapt<UserGetDto>();

        return userDto;
    }
}
