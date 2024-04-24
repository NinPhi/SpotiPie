
namespace SpotiPie.Infrastructure.Data.Repositories;

public class ArtistRepository(AppDbContext dbContext)
    : BaseRepository<Artist>(dbContext), IArtistRepository
{
    public async Task<bool> AddFollowerAsync(int id)
    {
        var artist = await DbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

        if (artist == null) return false;

        artist.Followers++;

        return true;
    }
}
