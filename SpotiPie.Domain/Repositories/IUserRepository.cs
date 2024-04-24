namespace SpotiPie.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByLoginAsync(string login);
    void Add(User user);
}
