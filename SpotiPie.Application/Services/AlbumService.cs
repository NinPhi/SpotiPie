using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class AlbumService(
    IAlbumRepository albumRepository,
    IUnitOfWork unitOfWork) : IAlbumService
{
    public async Task<AlbumGetDto?> GetByIdAsync(int id)
    {
        var album = await albumRepository.GetByIdAsync(id);

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

    public async Task<AlbumGetDto> CreateAsync(AlbumCreateDto albumDto)
    {
        var album = new Album
        {
            ArtistId = albumDto.ArtistId,
            Name = albumDto.Name!,
            Description = albumDto.Description,
            ReleaseYear = albumDto.ReleaseYear,
        };

        albumRepository.Add(album);
        await unitOfWork.SaveChangesAsync();

        var albumGetDto = new AlbumGetDto
        {
            Id = album.Id,
            ArtistId = album.ArtistId,
            Description = album.Description,
            Name = album.Name,
            ReleaseYear = album.ReleaseYear,
        };

        return albumGetDto;
    }
}
