
namespace SpotiPie.Infrastructure.Data.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public Task<User?> GetByLoginAsync(string login)
    {
        return dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login);
    }
}
