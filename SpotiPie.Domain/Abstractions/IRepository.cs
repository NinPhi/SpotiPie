namespace SpotiPie.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    void Add(TEntity genre);
    void Update(TEntity genre);
    void Remove(TEntity genre);
}
