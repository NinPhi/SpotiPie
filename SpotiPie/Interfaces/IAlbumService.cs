using SpotiPie.Dtos.Album;

namespace SpotiPie.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumGetDto> GetAlbumByIdAsync (int id);
    }
}
