using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class ArtistService : IArtistService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public ArtistService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ArtistGetDto?> GetByIdAsync(int id)
    {
        var artist = await _dbContext
            .Artists
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (artist is null) return null;

        var artistDto = _mapper.Map<ArtistGetDto>(artist);

        return artistDto;
    }

    public async Task<List<ArtistGetDto>> GetAllAsync()
    {
        var artists = await _dbContext
            .Artists
            .AsNoTracking()
            .ToListAsync();

        //var artistDtos = artists.Select(a => new ArtistGetDto
        //{
        //    Id = a.Id,
        //    Pseudonym = a.Pseudonym,
        //    MonthlyListeners = a.MonthlyListeners,
        //    Followers = a.Followers,

        //}).ToList();

        var artistDtos = _mapper.Map<List<ArtistGetDto>>(artists);

        return artistDtos;
    }

    public async Task CreateAsync(ArtistCreateDto artistDto)
    {
        var artist = _mapper.Map<Artist>(artistDto);

        await _dbContext.Artists.AddAsync(artist);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var artist = await _dbContext.Artists.FindAsync(id);

        if (artist is null) return;

        _dbContext.Artists.Remove(artist);

        //EntityEntry artistEntry = _dbContext.Entry(artist);
        //artistEntry.State = EntityState.Deleted;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> AddFollowerAsync(int id)
    {
        var artist = await _dbContext.Artists.FindAsync(id);

        if (artist is null) return false;

        artist.Followers++;

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
