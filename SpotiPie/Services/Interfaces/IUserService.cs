namespace SpotiPie.Services.Interfaces;

public interface IUserService
{
    public Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto);
    public Task<UserGetDto?> GetByLoginAsync(UserCredentialsDto userDto);
}
