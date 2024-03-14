using SpotiPie.Contracts;

namespace SpotiPie.Services.Interfaces;

public interface IGenreService
{
    public Task<List<GenreGetDto>> GetAllAsync();
    public Task CreateAsync(GenreCreateDto genre);
    public Task UpdateAsync(int id, GenreCreateDto genre);
    public Task DeleteAsync(int id);
}
