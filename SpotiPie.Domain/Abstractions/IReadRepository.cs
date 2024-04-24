namespace SpotiPie.Domain.Abstractions;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync();
}
