using SpotiPie.Entities;

namespace SpotiPie.Services.Interfaces
{
    public interface ITextsService
    {
        public Task<List<TextSong>> GetAllText();
        public Task<TextSong> GetTextById(int id);
        public Task PostText(TextSong textSong);



    }
}
