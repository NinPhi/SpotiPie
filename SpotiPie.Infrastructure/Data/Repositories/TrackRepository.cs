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
}
