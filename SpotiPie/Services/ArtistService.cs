using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class ArtistService : IArtistService
{
    private readonly AppDbContext _dbContext;

    public ArtistService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ArtistGetDto?> GetByIdAsync(int id)
    {
        var artist = await _dbContext.Artists.FindAsync(id);

        if (artist is null) return null;

        var artistDto = new ArtistGetDto
        {
            Id = artist.Id,
            Pseudonym = artist.Pseudonym,
            MonthlyListeners = artist.MonthlyListeners,
            Followers = artist.Followers,
        };

        return artistDto;
    }

    public async Task<List<ArtistGetDto>> GetAllAsync()
    {
        var artists = await _dbContext.Artists.ToListAsync();

        var artistDtos = artists.Select(a => new ArtistGetDto
        {
            Id = a.Id,
            Pseudonym = a.Pseudonym,
            MonthlyListeners = a.MonthlyListeners,
            Followers = a.Followers,

        }).ToList();

        return artistDtos;
    }

    public async Task CreateAsync(ArtistCreateDto artistDto)
    {
        var artist = new Artist()
        {
            Pseudonym = artistDto.Pseudonym!,
        };

        await _dbContext.Artists.AddAsync(artist);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var artist = await _dbContext.Artists.FindAsync(id);

        if (artist is null) return;

        _dbContext.Artists.Remove(artist);
        await _dbContext.SaveChangesAsync();
    }
}
