using SpotiPie.Application.Services.Interfaces.UnitOfWork;

namespace SpotiPie.Infrastructure.Data;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}
