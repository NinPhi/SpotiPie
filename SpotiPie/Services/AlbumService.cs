using Mapster;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
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

        var albumDto = album.Adapt<AlbumGetDto>();

        return albumDto;
    }

    public async Task<AlbumGetDto> CreateAsync(AlbumCreateDto albumDto)
    {
        var album = albumDto.Adapt<Album>();

        await _dbContext.Albums.AddAsync(album);
        await _dbContext.SaveChangesAsync();

        var albumGetDto = album.Adapt<AlbumGetDto>();

        return albumGetDto;
    }
}
