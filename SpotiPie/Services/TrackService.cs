using Microsoft.EntityFrameworkCore;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Entities.Contracts;

namespace SpotiPie.Services;

public class TrackService
{
    private readonly AppDbContext _appDbContext;

    public TrackService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task<List<TrackDto>> GetAllTracksAsync()
    {
        var tracks = await _appDbContext.Tracks.ToListAsync();
        var trackDtos = tracks.Select(t => new TrackDto
        {
            Id = t.Id,
            Name = t.Name,
            Duration = t.Duration,
            ReleaseDate = t.ReleaseDate
        }).ToList();
        return trackDtos;
    }

    public async Task<TrackDto> GetTrackByIdAsync(int id)
    {
        var track = await _appDbContext.Tracks.FirstOrDefaultAsync(t => t.Id == id);
        if (track == null)
        {
            throw new ArgumentException("Track not found.");
        }

        var trackDto = new TrackDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate
        };

        return trackDto;
    }

    public async Task<TrackDto> CreateTrackAsync(CreateTrackDto dto)
    {
        if (dto.Name == null || dto.Name.Length > 100)
        {
            throw new ArgumentException("Track name is required and should be less than 100 characters.");
        }

        if (dto.Duration == null)
        {
            throw new ArgumentException("Track duration is required.");
        }

        var track = new Track
        {
            Name = dto.Name,
            Duration = dto.Duration,
            ReleaseDate = dto.ReleaseDate,
        };

        _appDbContext.Add(track);
        await _appDbContext.SaveChangesAsync();

        return new TrackDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate
        };
    }

    public async Task<TrackDto> UpdateTrackAsync(int id, CreateTrackDto dto)
    {
        var track = await _appDbContext.Tracks.FirstOrDefaultAsync(t => t.Id == id);
        if (track == null)
        {
            throw new ArgumentException("Track not found.");
        }

        if (dto.Name == null || dto.Name.Length > 100)
        {
            throw new ArgumentException("Track name is required and should be less than 100 characters.");
        }

        track.Name = dto.Name;
        track.Duration = dto.Duration;
        track.ReleaseDate = dto.ReleaseDate;

        _appDbContext.Update(track);
        await _appDbContext.SaveChangesAsync();

        return new TrackDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate
        };
    }

    public async Task<TrackDto> DeleteTrackAsync(int id)
    {
        var track = await _appDbContext.Tracks.FindAsync(id);
        if (track == null)
        {
            throw new ArgumentException("Track not found.");
        }

        _appDbContext.Remove(track);
        await _appDbContext.SaveChangesAsync();

        return new TrackDto
        {
            Id = track.Id,
            Name = track.Name,
            Duration = track.Duration,
            ReleaseDate = track.ReleaseDate
        };
    }
}
