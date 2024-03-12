using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SpotiPie.DTO;
using SpotiPie.Models;
using System.Threading.Tasks;
namespace SpotiPie.Services
{
    public class ArtistService
    {
        private readonly AppDbContext _db;
        public ArtistService(AppDbContext appDbContext) 
        {
            _db = appDbContext;
        }

        public async Task<Artist> Get(int id)
        {
            var artist = await _db.Artists.FirstOrDefaultAsync(x => x.ArtistId == id);
            return artist;
        }
        public async Task<List<Artist>> GetAll()
        {
            return await _db.Artists.ToListAsync();
        }
        public async Task Add(ArtistDto artistDto)
        {
            var artist = new Artist()
            {
                ArtistId = artistDto.ArtistId,
                Pseudonym = artistDto.Pseudonym,
            };
            await _db.Artists.AddAsync(artist);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int Id)
        {
            await _db.Artists.Where(x => x.ArtistId == Id).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }
        
    }
}
