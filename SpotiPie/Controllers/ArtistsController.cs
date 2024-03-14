using Microsoft.AspNetCore.Mvc;
using SpotiPie.Services;
using SpotiPie.Contracts;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistsController : ControllerBase
{
    private readonly ArtistService _artistService;

    public ArtistsController(ArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var artists = await _artistService.GetAllAsync();
        return Ok(artists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var artist = await _artistService.GetByIdAsync(id);
        return Ok(artist);
    }

    [HttpPost]
    public async Task<ActionResult> Create(ArtistCreateDto artist)
    {
        await _artistService.CreateAsync(artist);
        return Ok(artist);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _artistService.DeleteAsync(id);
        return NoContent();
    }
}
