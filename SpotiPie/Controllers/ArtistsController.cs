using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var artistDtos = await _artistService.GetAllAsync();

        return Ok(artistDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var artistDto = await _artistService.GetByIdAsync(id);

        if (artistDto is null)
            return NotFound();

        return Ok(artistDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArtistCreateDto artistDto)
    {
        await _artistService.CreateAsync(artistDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _artistService.DeleteAsync(id);

        return NoContent();
    }
}
