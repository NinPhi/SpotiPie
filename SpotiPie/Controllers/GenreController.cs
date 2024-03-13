using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController: ControllerBase
{
    private readonly IGenreService _genreContext;

    public GenreController(IGenreService genrContext)
    {
        _genreContext = genrContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetGenres()
    {
        return Ok(await _genreContext.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<IActionResult> PostGenre(GenreDto genre)
    {
        await _genreContext.CreateAsync(genre);
        return NoContent();
    }

    [HttpPut("{id}")]  
    public async Task<IActionResult> UpdateGenre(int id, GenreDto genre)
    {
        await _genreContext.UpdateAsync(id, genre);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Genre>> DeleteGenre(int id)
    {
        await _genreContext.DeleteAsync(id);
        return Ok();
    }
}
