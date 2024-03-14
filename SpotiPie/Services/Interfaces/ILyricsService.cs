using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface ILyricsService
{
    public Task<LyricsGetDto?> GetByIdAsync(int id);
    public Task<List<LyricsGetDto>> GetAllAsync();
    public Task CreateAsync(LyricsCreateDto textSong);
}
