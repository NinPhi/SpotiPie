using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entity;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class GenreService: IGenreInterface
{
    private readonly AppDbContext? _context;

    public GenreService(AppDbContext? context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetAll() => await _context!.Genres.ToListAsync();

    public async Task LayGenre(GenreDto genre)
    {
        var file = new Genre
        {
            ArtistId = genre.ArtistId,
            Genres = genre.GenreName,
            Country = genre.Country,
            DateRelease = genre.Date
        };

        await _context!.Genres.AddAsync(file);
        await _context.SaveChangesAsync();
    }

    public async Task Update(long id, GenreDto genre)
    {
        await _context!.Genres.Where(g => g.Id == id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(c => c.ArtistId, genre.ArtistId)
                .SetProperty(c => c.Genres, genre.GenreName)
                .SetProperty(c => c.Country, genre.Country)
                .SetProperty(c => c.DateRelease, genre.Date)
                );
    }

    public async Task Delete(int id)
    {
        await _context!.Genres.Where(g => g.Id == id)
            .ExecuteDeleteAsync();
    }

}
