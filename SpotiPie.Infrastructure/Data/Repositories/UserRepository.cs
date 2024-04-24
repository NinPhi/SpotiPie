using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class UserRepository(AppDbContext dbcontext) : BaseRepository<User>(dbcontext), IUserRepository
{
    public Task<User?> GetUserByLoginAsync(string login)
    {
        return DbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login);
    }
}