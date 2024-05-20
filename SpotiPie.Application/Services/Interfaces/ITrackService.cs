using SpotiPie.Domain.Result;

namespace SpotiPie.Application.Services.Interfaces;

public interface ITrackService
{
    public Task<TrackGetDto?> GetByIdAsync(int id);
    public Task<List<TrackGetDto>> GetAllAsync();
    public Task<List<TrackGetDto>> GetByArtistAsync(int artistId);
    public Task<TrackGetDto> CreateAsync(TrackCreateDto trackDto);
    public Task<Result<TrackGetDto>> UpdateAsync(int id, TrackCreateDto trackDto);
    public Task DeleteAsync(int id);
    public Task<bool> AddGenreAsync(int id, int genreId);
    public Task<bool> UploadDataAsync(TrackDataDto trackDataDto);
    public Task<TrackDataDto?> DownloadDataAsync(int id);
}