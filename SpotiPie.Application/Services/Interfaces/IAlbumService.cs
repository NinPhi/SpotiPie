namespace SpotiPie.Application.Services.Interfaces;

public interface IAlbumService
{
    public Task<AlbumGetDto?> GetByIdAsync(int id);
    public Task<AlbumGetDto> CreateAsync(AlbumCreateDto albumDto);
}
