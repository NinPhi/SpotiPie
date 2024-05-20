using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;
using SpotiPie.Domain.Result;
using SpotiPie.Domain.Result.ErrorMessages;

namespace SpotiPie.Application.Services;

public class TrackService(
    ITrackRepository trackRepository,
    IGenreRepository genreRespository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ITrackService
{
    public async Task<List<TrackGetDto>> GetAllAsync()
    {
        var tracks = await trackRepository.GetAllAsync();

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
        var track = await trackRepository.GetByIdAsync(id);

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

        trackRepository.Add(track);
        await unitOfWork.SaveChangesAsync();

        var trackDto = track.Adapt<TrackGetDto>(config);

        return trackDto;
    }

    public async Task<Result<TrackGetDto>> UpdateAsync(int id, TrackCreateDto trackDto)
    {
        var track = await trackRepository.GetByIdAsync(id);

        if (track is null)
            return new Error(
                TrackErrors.IdNotFound,
                $"Attempt to update a track with non-existant ID {id}");

        track.Name = trackDto.Name!;
        track.Duration = trackDto.Duration!;
        track.ReleaseDate = trackDto.ReleaseDate;

        trackRepository.Update(track);
        await unitOfWork.SaveChangesAsync();

        var getTrackDto = track.Adapt<TrackGetDto>();

        return getTrackDto;
    }

    public async Task DeleteAsync(int id)
    {
        var track = await trackRepository.GetByIdAsync(id);

        if (track is null) return;

        trackRepository.Remove(track);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> AddGenreAsync(int id, int genreId)
    {
        var track = await trackRepository.GetByIdWithGenres(id);

        if (track is null) return false;

        var genre = await genreRespository.GetByIdAsync(genreId);
        if (genre is null) return false;

        if (track.Genres.Contains(genre)) return true;

        track.Genres.Add(genre);

        trackRepository.Update(track);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<List<TrackGetDto>> GetByArtistAsync(int artistId)
    {
        var tracks = await trackRepository.GetAllOfArtistAsync(artistId);

        var trackDtos = mapper.Map<List<TrackGetDto>>(tracks);

        //var tracks = await trackRepository.Tracks
        //    .AsNoTracking()
        //    .Select(t => new TrackGetDto
        //    {
        //        Id = t.Id,
        //        ArtistId = t.ArtistId,
        //        AlbumId = t.AlbumId,
        //        Name = t.Name,
        //        TrackDuration = t.Duration,
        //        ReleaseDate = t.ReleaseDate,
        //    })
        //    .Where(t => t.ArtistId == artistId)
        //    .ToListAsync();

        return trackDtos;
    }

    public async Task<bool> UploadDataAsync(TrackDataDto trackDataDto)
    {
        var track = await trackRepository.GetByIdWithTrackData(trackDataDto.TrackId);

        if (track is null) return false;

        var trackData = mapper.Map<TrackData>(trackDataDto);

        track.TrackData = trackData;

        trackRepository.Update(track);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<TrackDataDto?> DownloadDataAsync(int id)
    {
        var track = await trackRepository.GetByIdWithTrackData(id);

        if (track?.TrackData is null) return null;

        var trackDataDto = mapper.Map<TrackDataDto>(track.TrackData);

        return trackDataDto;
    }
}
