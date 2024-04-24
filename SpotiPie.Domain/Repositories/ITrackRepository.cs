using SpotiPie.Domain.Abstractions;
using SpotiPie.Domain.Entities;

namespace SpotiPie.Domain.Repositories;

public interface ITrackRepository : IRepository<Track>
{
    Task<List<Track>> GetAllOfGenreAsync(string genre);
    Task<Track?> GetTrackWithGenre(int id);
    Task<List<Track>> GetTracksByArtistAsync(int artistId);
    Task<Track?> GetTrackDataAsync(int id);
}
