using SpotiPie.Application.Contracts;

namespace SpotiPie.Application.Services;

public class TrackService : ITrackService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public TrackService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TrackGetDto>> GetAllAsync()
    {
        var tracks = await _dbContext.Tracks.ToListAsync();

        var trackDtos = tracks.Select(t => new TrackGetDto
        {
            Id = t.Id,
            ArtistId = t.ArtistId,
            AlbumId = t.AlbumId,
            Name = t.Name,
            TrackDuration = t.Duration,
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
            ArtistId = track.ArtistId,
            AlbumId = track.AlbumId,
            Name = track.Name,
            TrackDuration = track.Duration,
            ReleaseDate = track.ReleaseDate,
        };

        return trackDto;
    }

    public async Task<TrackGetDto> CreateAsync(TrackCreateDto dto)
    {
        var config = TypeAdapterConfig<Track, TrackGetDto>
            .NewConfig()
            .Map(dest => dest.TrackDuration, src => src.Duration)
            .Config;

        var track = dto.Adapt<Track>();

        await _dbContext.AddAsync(track);
        await _dbContext.SaveChangesAsync();

        var trackDto = track.Adapt<TrackGetDto>(config);

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
            ArtistId = track.ArtistId,
            AlbumId = track.AlbumId,
            Name = track.Name,
            TrackDuration = track.Duration,
            ReleaseDate = track.ReleaseDate,
        };

        return trackGetDto;
    }

    public async Task DeleteAsync(int id)
    {
        var track = await _dbContext.Tracks.FindAsync(id);

        if (track is null) return;

        _dbContext.Tracks.Remove(track);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> AddGenreAsync(int id, int genreId)
    {
        var track = await _dbContext.Tracks
            .Include(t => t.Genres)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (track is null) return false;

        var genre = await _dbContext.Genres.FindAsync(genreId);
        if (genre is null) return false;

        if (track.Genres.Contains(genre)) return true;

        track.Genres.Add(genre);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<TrackGetDto>> GetByArtistAsync(int artistId)
    {
        var tracks = await _dbContext.Tracks
            .AsNoTracking()
            .Select(t => new TrackGetDto
            {
                Id = t.Id,
                ArtistId = t.ArtistId,
                AlbumId = t.AlbumId,
                Name = t.Name,
                TrackDuration = t.Duration,
                ReleaseDate = t.ReleaseDate,
            })
            .Where(t => t.ArtistId == artistId)
            .ToListAsync();

        return tracks;
    }

    public async Task<bool> UploadDataAsync(TrackDataDto trackDataDto)
    {
        var track = await _dbContext.Tracks
            .Include(t => t.TrackData)
            .FirstOrDefaultAsync(t => t.Id == trackDataDto.TrackId);

        if (track is null) return false;

        var trackData = _mapper.Map<TrackData>(trackDataDto);

        track.TrackData = trackData;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TrackDataDto?> DownloadDataAsync(int id)
    {
        var track = await _dbContext.Tracks
            .AsNoTracking()
            .Include(t => t.TrackData)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (track?.TrackData is null) return null;

        var trackDataDto = _mapper.Map<TrackDataDto>(track.TrackData);

        return trackDataDto;
    }
}
