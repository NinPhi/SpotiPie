using SpotiPie.Domain.Abstractions;
using SpotiPie.Domain.Entities;

namespace SpotiPie.Domain.Repositories;

public interface ITrackRepository : IRepository<Track>
{
    Task<List<Track>> GetAllOfGenreAsync(string genre);
}
