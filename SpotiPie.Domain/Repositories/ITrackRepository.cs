namespace SpotiPie.Domain.Repositories;

public interface ITrackRepository : IRepository<Track>
{
    Task<Track?> GetByIdWithGenres(int id);
    Task<Track?> GetByIdWithTrackData(int id);
    Task<List<Track>> GetAllOfGenreAsync(string genre);
    Task<List<Track>> GetAllOfArtistAsync(int artistId);
}
