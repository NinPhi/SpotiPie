using SpotiPie.Contracts;
using SpotiPie.Entities;

namespace SpotiPie.Services.Interfaces;

public interface IGenreService
{
    public Task<List<Genre>> GetAllAsync();
    public Task CreateAsync(GenreDto genre);
    public Task UpdateAsync(int id, GenreDto genre);
    public Task DeleteAsync(int id);
}
