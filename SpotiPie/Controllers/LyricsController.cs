namespace SpotiPie.Controllers;

[Route("api/lyrics")]
[ApiController]
public class LyricsController(ILyricsService lyricsService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var lyricsDto = await lyricsService.GetByIdAsync(id);

        return Ok(lyricsDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var lyricsDtos = await lyricsService.GetAllAsync();

        return Ok(lyricsDtos);
    }

    [HttpPost]
    public async Task<ActionResult> Create(LyricsCreateDto lyricsDto)
    {
        await lyricsService.CreateAsync(lyricsDto);

        return NoContent();
    }
}
