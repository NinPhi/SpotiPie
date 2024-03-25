using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface IArtistService
{
    public Task<ArtistGetDto?> GetByIdAsync(int id);
    public Task<List<ArtistGetDto>> GetAllAsync();
    public Task CreateAsync(ArtistCreateDto artistDto);
    public Task DeleteAsync(int id);
    public Task<bool> AddFollowerAsync(int id);
}