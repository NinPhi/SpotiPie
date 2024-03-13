using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class GenreService : IGenreService
{
    private readonly AppDbContext _context;

    public GenreService(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Genre>> GetAllAsync() => 
        _context.Genres.ToListAsync();

    public async Task CreateAsync(GenreDto genre)
    {
        var file = new Genre
        {
            Name = genre.Name!
        };

        await _context.Genres.AddAsync(file);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, GenreDto genre)
    {
        var entity = await _context.Genres.FindAsync(id);

        if (entity is null) throw new Exception("Genre not found.");

        entity.Name = genre.Name!;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Genres.Where(g => g.Id == id)
            .ExecuteDeleteAsync();
    }
}
