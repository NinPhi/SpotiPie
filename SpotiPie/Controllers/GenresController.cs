namespace SpotiPie.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController(IGenreService genreService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genreDtos = await genreService.GetAllAsync();

        return Ok(genreDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenreCreateDto genreDto)
    {
        var genreGetDto = await genreService.CreateAsync(genreDto);

        return Created(string.Empty, genreGetDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenreCreateDto genreDto)
    {
        var genreGetDto = await genreService.UpdateAsync(id, genreDto);

        if (genreGetDto is null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await genreService.DeleteAsync(id);

        return NoContent();
    }
}
