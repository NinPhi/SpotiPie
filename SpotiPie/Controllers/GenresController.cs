using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenreCreateDto genre)
    {
        await _genreService.CreateAsync(genre);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenreCreateDto genre)
    {
        await _genreService.UpdateAsync(id, genre);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Genre>> Delete(int id)
    {
        await _genreService.DeleteAsync(id);
        return NoContent();
    }
}
