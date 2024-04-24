namespace SpotiPie.Domain.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity genre);
    void Update(TEntity genre);
    void Remove(TEntity genre);
}
