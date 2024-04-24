namespace SpotiPie.Controllers;

[ApiController]
[Route("api/albums")]
public class AlbumsController(IAlbumService albumService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var albumDto = await albumService.GetByIdAsync(id);

        return Ok(albumDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AlbumCreateDto albumDto)
    {
        var albumGetDto = await albumService.CreateAsync(albumDto);

        return Created($"api/albums/{albumGetDto.Id}", albumGetDto);
    }
}
