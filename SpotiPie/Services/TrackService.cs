using Microsoft.EntityFrameworkCore;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Entities.Contracts;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Services;

public class TrackService : ITrackService
{
    private readonly AppDbContext _dbContext;

    public TrackService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TrackGetDto>> GetAllAsync()
    {
        var tracks = await _dbContext.Tracks.ToListAsync();

        var trackDtos = tracks.Select(t => new TrackGetDto
        {
            Id = t.Id,
            Name = t.Name,
            Duration = t.Duration,
            ReleaseDate = t.ReleaseDate,

        }).ToList();

        return trackDtos;
    }

    public async Task<TrackGetDto?> GetByIdAsync(int id)
    {
        var track = await _dbContext.Tracks.FindAsync(id);

        if (track is null) return null;

        var trackDto = new TrackGetDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate,
        };

        return trackDto;
    }

    public async Task<TrackGetDto> CreateAsync(TrackCreateDto dto)
    {
        var track = new Track
        {
            Name = dto.Name!,
            Duration = dto.Duration!,
            ReleaseDate = dto.ReleaseDate,
        };

        await _dbContext.AddAsync(track);
        await _dbContext.SaveChangesAsync();

        var trackDto = new TrackGetDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate
        };

        return trackDto;
    }

    public async Task<TrackGetDto?> UpdateAsync(int id, TrackCreateDto trackDto)
    {
        var track = await _dbContext.Tracks.FindAsync(id);

        if (track is null) return null;

        track.Name = trackDto.Name!;
        track.Duration = trackDto.Duration!;
        track.ReleaseDate = trackDto.ReleaseDate;

        _dbContext.Update(track);
        await _dbContext.SaveChangesAsync();

        var trackGetDto = new TrackGetDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate,
        };

        return trackGetDto;
    }

    public async Task DeleteAsync(int id)
    {
        var track = await _dbContext.Tracks.FindAsync(id);

        if (track is null) return;

        _dbContext.Remove(track);
        await _dbContext.SaveChangesAsync();
    }
}
