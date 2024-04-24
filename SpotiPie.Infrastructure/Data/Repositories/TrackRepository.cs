using Microsoft.EntityFrameworkCore;
using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class TrackRepository(AppDbContext dbContext)
    : BaseRepository<Track>(dbContext), ITrackRepository
{
    public Task<List<Track>> GetAllOfGenreAsync(string genre)
    {
        return DbContext.Genres.AsNoTracking()
            .Where(g => g.Name == genre)
            .SelectMany(g => g.Tracks)
            .ToListAsync();
    }

    public Task<Track?> GetTrackDataAsync(int id)
    {
        return DbContext.Tracks
            .AsNoTracking()
            .Include(t => t.TrackData)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task<List<Track>> GetTracksByArtistAsync(int artistId)
    {
        return DbContext.Tracks
           .Where(t => t.ArtistId == artistId)
           .ToListAsync();
    }

    public Task<Track?> GetTrackWithGenre(int id)
    {
        return DbContext.Tracks
            .Include(t => t.Genres)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
