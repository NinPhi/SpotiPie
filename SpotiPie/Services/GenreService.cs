using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class GenreService : IGenreService
{
    private readonly AppDbContext _dbContext;

    public GenreService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GenreGetDto>> GetAllAsync()
    {
        var genres = await _dbContext.Genres.ToListAsync();

        var genreDtos = genres.Select(g => new GenreGetDto
        {
            Id = g.Id,
            Name = g.Name,

        }).ToList();

        return genreDtos;
    }

    public async Task CreateAsync(GenreCreateDto genreDto)
    {
        var genre = new Genre
        {
            Name = genreDto.Name!
        };

        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, GenreCreateDto genreDto)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null) throw new Exception("Genre not found.");

        genre.Name = genreDto.Name!;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null) return;

        _dbContext.Genres.Remove(genre);
        await _dbContext.SaveChangesAsync();
    }
}
