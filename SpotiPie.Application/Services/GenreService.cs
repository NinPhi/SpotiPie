using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class GenreService(
    IGenreRespository genreRespository,
    IUnitOfWork unitOfWork)
    : IGenreService
{
    public async Task<List<GenreGetDto>> GetAllAsync()
    {
        var genres = await genreRespository.GetAllAsync();

        var genreDtos = genres.Select(g => new GenreGetDto
        {
            Id = g.Id,
            Name = g.Name,

        }).ToList();

        return genreDtos;
    }

    public async Task<GenreGetDto> CreateAsync(GenreCreateDto genreDto)
    {
        var genre = new Genre
        {
            Name = genreDto.Name!
        };

        genreRespository.Add(genre);
        await unitOfWork.SaveChangesAsync();

        var genreGetDto = new GenreGetDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };

        return genreGetDto;
    }

    public async Task<GenreGetDto?> UpdateAsync(int id, GenreCreateDto genreDto)
    {
        var genre = await genreRespository.GetByIdAsync(id);

        if (genre is null) return null;

        genre.Name = genreDto.Name!;

        genreRespository.Update(genre);

        await unitOfWork.SaveChangesAsync();

        var genreGetDto = new GenreGetDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };

        return genreGetDto;
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await genreRespository.GetByIdAsync(id);

        if (genre is null) return;

        genreRespository.Remove(genre);
        await unitOfWork.SaveChangesAsync();
    }
}
