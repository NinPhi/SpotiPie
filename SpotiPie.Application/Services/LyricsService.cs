using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class LyricsService(ILyricsRepository lyricsRepository, IUnitOfWork unitOfWork) : ILyricsService
{
    private readonly ILyricsRepository _lyricsRepository = lyricsRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<LyricsGetDto?> GetByIdAsync(int id)
    {
        var lyrics = await _lyricsRepository.GetByIdAsync(id);

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
        var lyrics = await _lyricsRepository.GetAllAsync();

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

        _lyricsRepository.Add(lyrics);
        await _unitOfWork.SaveChangesAsync();
    }
}
