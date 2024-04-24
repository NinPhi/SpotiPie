using SpotiPie.Domain.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories.Abstractions;

public class BaseRepository<TEntity>(AppDbContext dbContext)
    : IRepository<TEntity> where TEntity : Entity
{
    protected AppDbContext DbContext => dbContext;

    public Task<List<TEntity>> GetAllAsync()
    {
        return dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public Task<TEntity?> GetByIdAsync(int id)
    {
        return dbContext.Set<TEntity>().AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Add(TEntity genre)
    {
        dbContext.Add(genre);
    }

    public void Update(TEntity genre)
    {
        dbContext.Update(genre);
    }

    public void Remove(TEntity genre)
    {
        dbContext.Remove(genre);
    }
}
