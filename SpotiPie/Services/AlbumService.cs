using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class AlbumService : IAlbumService
{
    private readonly AppDbContext _dbContext;

    public AlbumService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AlbumGetDto?> GetByIdAsync(int id)
    {
        var album = await _dbContext.Albums.FindAsync(id);

        if (album is null) return null;

        var albumDto = new AlbumGetDto
        {
            Id = album.Id,
            ArtistId = album.ArtistId,
            Description = album.Description,
            Name = album.Name,
            ReleaseYear = album.ReleaseYear,
        };

        return albumDto;
    }
}
