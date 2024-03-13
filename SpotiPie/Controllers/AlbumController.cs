using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[ApiController]
[Route("api/albums")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet("{albumId}")]
    public async Task<ActionResult<AlbumGetDto>> GetAlbumById(int albumId)
    {
        var album = await _albumService.GetAlbumByIdAsync(albumId);

        return Ok(album);
    }
}
