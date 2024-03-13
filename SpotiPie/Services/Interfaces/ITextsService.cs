using SpotiPie.Entities;

namespace SpotiPie.Services.Interfaces;

public interface ITextsService
{
    public Task<List<TextSong>> GetAllTextsAsync();
    public Task<TextSong> GetTextByIdAsync(int id);
    public Task PostTextAsync(TextSong textSong);
}
