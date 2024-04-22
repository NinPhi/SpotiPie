namespace SpotiPie.Application.Services.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
