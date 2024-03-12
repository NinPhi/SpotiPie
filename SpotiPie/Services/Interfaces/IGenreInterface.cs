using SpotiPie.Contracts;
using SpotiPie.Entity;

namespace SpotiPie.Services.Interfaces;

public interface IGenreInterface
{
    public Task<List<Genre>> GetAll();
    public Task LayGenre(GenreDto genre);
    public Task Update(long id, GenreDto genre);
    public Task Delete(int id);
}
