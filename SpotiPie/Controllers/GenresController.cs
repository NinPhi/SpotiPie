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
        var genreDtos = await _genreService.GetAllAsync();

        return Ok(genreDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenreCreateDto genreDto)
    {
        var genreGetDto = await _genreService.CreateAsync(genreDto);

        return Created(string.Empty, genreGetDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenreCreateDto genreDto)
    {
        var genreGetDto = await _genreService.UpdateAsync(id, genreDto);

        if (genreGetDto is null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Genre>> Delete(int id)
    {
        await _genreService.DeleteAsync(id);

        return NoContent();
    }
}
