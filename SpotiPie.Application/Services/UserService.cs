using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class UserService(IUserRepository userRepository, IPasswordManager passwordManager, IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordManager _passwordManager = passwordManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto)
    {
        var user = new User()
        {
            Login = userDto.Login!,
            PasswordHash = _passwordManager.HashPassword(userDto.Password!),
            Role = "User"
        };

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

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
        var user = await _userRepository.GetUserByLoginAsync(userCredentialsDto.Login!);

        if (user is null) return null;

        if (!_passwordManager.VerifyPassword(userCredentialsDto.Password!, user.PasswordHash))
            return null;

        var userDto = user.Adapt<UserGetDto>();

        return userDto;
    }
}
