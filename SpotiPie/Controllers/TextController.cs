using Microsoft.AspNetCore.Mvc;
using SpotiPie.Entities;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[Route("api/texts")]
[ApiController]
public class TextController : ControllerBase
{
    private readonly ITextsService _textsService;

    public TextController(ITextsService textsService)
    {
        _textsService = textsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var text = await _textsService.GetTextByIdAsync(id);
        return Ok(text);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllText()
    {
        var text = await _textsService.GetAllTextsAsync();
        return Ok(text);
    }

    [HttpPost]
    public async Task<ActionResult> PostText(TextSong textSong)
    {
        await _textsService.PostTextAsync(textSong);
        return Ok();
    }
}
