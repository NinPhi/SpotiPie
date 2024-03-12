using SpotiPie.Text;

namespace SpotiPie.Services
{
    public interface ITextsService
    {
        public Task<List<TextSong>> GetAllText();
        public Task<TextSong> GetTextById(int id);
        public Task PostText(TextSong textSong);



    }
}
