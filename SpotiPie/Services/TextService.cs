using Microsoft.EntityFrameworkCore;
using SpotiPie.Data;
using SpotiPie.Text;

namespace SpotiPie.Services
{
    public class TextService : ITextsService

    {

        private readonly AppDbContext _db;

        public TextService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TextSong>> GetAllText()
        {
            
            return await _db.Texts.ToListAsync();
        }

        public async Task<TextSong> GetTextById(int id)
        {
            var text = await _db.Texts.FirstOrDefaultAsync(x => x.Id == id);

            return text;
        }

        public async Task PostText(TextSong textSong)
        {
            await _db.Texts.AddAsync(textSong);
            await _db.SaveChangesAsync();

        }

        
    }
}
