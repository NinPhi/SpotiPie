namespace SpotiPie.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;

    public UserService(AppDbContext dbContext, IPasswordManager passwordManager)
    {
        _dbContext = dbContext;
        _passwordManager = passwordManager;
    }

    public async Task<UserGetDto> SignUpAsync(UserCredentialsDto userDto)
    {
        var user = new User()
        {
            Login = userDto.Login!,
            PasswordHash = _passwordManager.HashPassword(userDto.Password!),
            Role = "User"
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

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
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == userCredentialsDto.Login);

        if (user is null) return null;

        if (!_passwordManager.VerifyPassword(userCredentialsDto.Password!, user.PasswordHash))
            return null;

        var userDto = user.Adapt<UserGetDto>();

        return userDto;
    }
}
