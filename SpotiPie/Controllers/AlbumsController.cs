using Microsoft.AspNetCore.Mvc;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/albums")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumsController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var albumDto = await _albumService.GetByIdAsync(id);

        return Ok(albumDto);
    }
}
