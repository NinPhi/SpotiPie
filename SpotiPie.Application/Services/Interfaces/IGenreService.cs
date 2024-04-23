namespace SpotiPie.Application.Services.Interfaces;

public interface IGenreService
{
    public Task<List<GenreGetDto>> GetAllAsync();
    public Task<GenreGetDto> CreateAsync(GenreCreateDto genreDto);
    public Task<GenreGetDto?> UpdateAsync(int id, GenreCreateDto genreDto);
    public Task DeleteAsync(int id);
}
