using SpotiPie.Middleware;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistsController(IArtistService artistService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var artistDtos = await artistService.GetAllAsync();

        return Ok(artistDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var artistDto = await artistService.GetByIdAsync(id);

        if (artistDto is null)
            return NotFound();

        return Ok(artistDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArtistCreateDto artistDto)
    {
        await artistService.CreateAsync(artistDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await artistService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPut("{id}/new-follower")]
    public async Task<IActionResult> AddFollower(int id)
    {
        var artistDto = await artistService.GetByIdAsync(id);

        if (artistDto is null)
            return NotFound();

        var result = await artistService.AddFollowerAsync(id);

        if (result is false)
            return NotFound();

        return NoContent();
    }
}
