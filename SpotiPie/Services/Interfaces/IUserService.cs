namespace SpotiPie.Services.Interfaces;

public interface IUserService
{
    public Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto);
    public Task SignInAsync(UserGetDto userGetDto);
    public Task<UserGetDto?> GetByLoginAsync(UserCredentialsDto userDto);
}
