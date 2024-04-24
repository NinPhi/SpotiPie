using SpotiPie.Domain.Abstractions;
using SpotiPie.Domain.Entities;

namespace SpotiPie.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByLoginAsync(string login);
}