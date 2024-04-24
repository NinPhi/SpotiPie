namespace SpotiPie.Domain.Repositories;

public interface IArtistRepository : IRepository<Artist>
{
    Task<bool> AddFollowerAsync(int id);
}
