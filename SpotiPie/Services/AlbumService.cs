using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class AlbumService : IAlbumService
{
    private readonly AppDbContext _appDbContext;
    public AlbumService(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }

    public async Task<AlbumGetDto> GetAlbumByIdAsync(int id)
    {
        var album = await _appDbContext.Albums.Where(a => a.Id == id).FirstOrDefaultAsync();

        if (album is null)
        {
            throw new ArgumentNullException($"Album with id: {id} is not found");
        }

        var mappedAlbum = new AlbumGetDto
        {
            Id = album.Id,
            Description = album.Description,
            Name = album.Name,
            ReleaseYear = album.ReleaseYear,
            ArtistId = album.ArtistId,
        };

        return mappedAlbum;
    }
}
