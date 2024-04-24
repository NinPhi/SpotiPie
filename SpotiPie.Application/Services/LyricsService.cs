using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class LyricsService(
    ILyricsRepository lyricsRepository, IUnitOfWork unitOfWork) : ILyricsService
{
    public async Task<LyricsGetDto?> GetByIdAsync(int id)
    {
        var lyrics = await lyricsRepository.GetByIdAsync(id);

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
        var lyrics = await lyricsRepository.GetAllAsync();

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

        lyricsRepository.Add(lyrics);
        await unitOfWork.SaveChangesAsync();
    }
}
