namespace SpotiPie.Infrastructure.Data.Repositories;

public class TrackRepository(AppDbContext dbContext)
    : BaseRepository<Track>(dbContext), ITrackRepository
{
    public Task<List<Track>> GetAllOfArtistAsync(int artistId)
    {
        return DbContext.Artists.AsNoTracking()
            .Where(a => a.Id == artistId)
            .SelectMany(a => a.Tracks)
            .ToListAsync();
    }

    public Task<List<Track>> GetAllOfGenreAsync(string genre)
    {
        return DbContext.Genres.AsNoTracking()
            .Where(g => g.Name == genre)
            .SelectMany(g => g.Tracks)
            .ToListAsync();
    }

    public Task<Track?> GetByIdWithGenres(int id)
    {
        return DbContext.Tracks
            .Include(t => t.Genres)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task<Track?> GetByIdWithTrackData(int id)
    {
        return DbContext.Tracks
            .Include(t => t.TrackData)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
