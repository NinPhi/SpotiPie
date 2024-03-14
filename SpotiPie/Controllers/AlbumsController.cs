using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
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

    [HttpPost]
    public async Task<IActionResult> Create(AlbumCreateDto albumDto)
    {
        var albumGetDto = await _albumService.CreateAsync(albumDto);

        return Created($"api/albums/{albumGetDto.Id}", albumGetDto);
    }
}
