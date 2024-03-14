using Microsoft.AspNetCore.Mvc;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

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
    public async Task<ActionResult> Get(int id)
    {
        var text = await _lyricsService.GetByIdAsync(id);
        return Ok(text);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var text = await _lyricsService.GetAllAsync();
        return Ok(text);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Lyrics textSong)
    {
        await _lyricsService.CreateAsync(textSong);
        return Ok();
    }
}
