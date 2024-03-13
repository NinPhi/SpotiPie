using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumGetDto> GetAlbumByIdAsync(int id);
    }
}
