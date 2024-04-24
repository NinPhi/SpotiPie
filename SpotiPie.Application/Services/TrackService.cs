using SpotiPie.Application.Contracts;
using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;
using SpotiPie.Entities.Contracts;

namespace SpotiPie.Application.Services;

public class TrackService(ITrackRepository trackRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenreRespository genreRepository) : ITrackService
{
    private readonly ITrackRepository _trackRepository = trackRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IGenreRespository _genreRepository = genreRepository;

    public async Task<List<TrackGetDto>> GetAllAsync()
    {
        var tracks = await _trackRepository.GetAllAsync();

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
        var track = await _trackRepository.GetByIdAsync(id);

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

        _trackRepository.Add(track);   
        await _unitOfWork.SaveChangesAsync();

        var trackDto = track.Adapt<TrackGetDto>(config);

        return trackDto;
    }

    public async Task<TrackGetDto?> UpdateAsync(int id, TrackCreateDto trackDto)
    {
        var track = await _trackRepository.GetByIdAsync(id);

        if (track is null) return null;

        track.Name = trackDto.Name!;
        track.Duration = trackDto.Duration!;
        track.ReleaseDate = trackDto.ReleaseDate;

        _trackRepository.Update(track);
        await _unitOfWork.SaveChangesAsync();

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
        var track = await _trackRepository.GetByIdAsync(id);

        if (track is null) return;

        _trackRepository.Remove(track);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> AddGenreAsync(int id, int genreId)
    {
        var track = await _trackRepository.GetTrackWithGenre(id);

        if (track is null) return false;

        var genre = await _genreRepository.GetByIdAsync(genreId);
        if (genre is null) return false;

        if (track.Genres.Contains(genre)) return true;

        track.Genres.Add(genre);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<List<TrackGetDto>> GetByArtistAsync(int artistId)
    {
        var tracks = await _trackRepository.GetTracksByArtistAsync(artistId);

        return _mapper.Map<List<TrackGetDto>>(tracks);
    }

    public async Task<bool> UploadDataAsync(TrackDataDto trackDataDto)
    {
        var track = await _trackRepository.GetByIdAsync(trackDataDto.TrackId);

        if (track is null) return false;

        var trackData = _mapper.Map<TrackData>(trackDataDto);

        track.TrackData = trackData;

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<TrackDataDto?> DownloadDataAsync(int id)
    {
        var track = await _trackRepository.GetTrackDataAsync(id);

        if (track?.TrackData is null) return null;

        var trackDataDto = _mapper.Map<TrackDataDto>(track.TrackData);

        return trackDataDto;
    }
}
