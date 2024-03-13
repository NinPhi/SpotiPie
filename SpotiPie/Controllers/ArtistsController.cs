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
    public async Task<ActionResult> GetAllArtists()
    {
        var artists = await _artistService.GetAll();
        return Ok(artists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var artist = await _artistService.Get(id);
        return Ok(artist);
    }

    [HttpPost]
    public async Task<ActionResult> AddArtist(ArtistDto artist)
    {
        await _artistService.Add(artist);
        return Ok(artist);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArtist(int id)
    {
        await _artistService.Delete(id);
        return NoContent();
    }
}
