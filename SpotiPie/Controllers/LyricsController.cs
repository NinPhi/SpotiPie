namespace SpotiPie.Controllers;

[Route("api/lyrics")]
[ApiController]
public class LyricsController : ControllerBase
{
    private readonly ILyricsService _lyricsService;

    public LyricsController(ILyricsService lyricsService)
    {
        _lyricsService = lyricsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var lyricsDto = await _lyricsService.GetByIdAsync(id);

        return Ok(lyricsDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var lyricsDtos = await _lyricsService.GetAllAsync();

        return Ok(lyricsDtos);
    }

    [HttpPost]
    public async Task<ActionResult> Create(LyricsCreateDto lyricsDto)
    {
        await _lyricsService.CreateAsync(lyricsDto);

        return NoContent();
    }
}
