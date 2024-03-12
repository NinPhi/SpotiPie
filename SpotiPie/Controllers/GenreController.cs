using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Entity;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController: ControllerBase
{
    private readonly IGenreInterface _genreContext;

    public GenreController(IGenreInterface genrContext)
    {
        _genreContext = genrContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetGenres()
    {
        return Ok(await _genreContext.GetAll());
    }
    
    [HttpPost]

    public async Task<IActionResult> PostGenre(GenreDto genre)
    {
        await _genreContext.LayGenre(genre);
        return NoContent();
    }

    [HttpPut]  
    
    public async Task<IActionResult> UpdateGenre(int id, GenreDto genre)
    {
        await _genreContext.Update(id, genre);
        return Ok();
    }

    [HttpDelete]

    public async Task<ActionResult<Genre>> DeleteGenre(int id)
    {
        await _genreContext.Delete(id);
        return Ok();
    }
}
