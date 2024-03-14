using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class LyricsService : ILyricsService
{
    private readonly AppDbContext _dbContext;

    public LyricsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LyricsGetDto?> GetByIdAsync(int id)
    {
        var lyrics = await _dbContext.Texts.FindAsync(id);

        if (lyrics is null) return null;

        var lyricsDto = new LyricsGetDto
        {
            Id = lyrics.Id,
            TrackId = lyrics.TrackId,
            Text = lyrics.Text,
            Translation = lyrics.Translation,
        };

        return lyricsDto;
    }

    public async Task<List<LyricsGetDto>> GetAllAsync()
    {
        var lyrics = await _dbContext.Texts.AsNoTracking().ToListAsync();

        var lyricsDtos = lyrics.Select(l => new LyricsGetDto
        {
            Id = l.Id,
            TrackId = l.TrackId,
            Text = l.Text,
            Translation = l.Translation,

        }).ToList();

        return lyricsDtos;
    }

    public async Task CreateAsync(LyricsCreateDto lyricsDto)
    {
        var lyrics = new Lyrics
        {
            TrackId = lyricsDto.TrackId,
            Text = lyricsDto.Text!,
            Translation = lyricsDto.Translation,
        };

        await _dbContext.Texts.AddAsync(lyrics);
        await _dbContext.SaveChangesAsync();
    }
}
