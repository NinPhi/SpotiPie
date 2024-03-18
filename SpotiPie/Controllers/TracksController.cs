using Microsoft.AspNetCore.Mvc;
using SpotiPie.Entities.Contracts;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers;

[Route("api/tracks")]
[ApiController]
public class TracksController : ControllerBase
{
    private readonly ITrackService _trackService;

    public TracksController(ITrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trackDtos = await _trackService.GetAllAsync();

        return Ok(trackDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var trackDto = await _trackService.GetByIdAsync(id);

        if (trackDto is null)
            return NotFound();

        return Ok(trackDto);
    }

    [HttpGet("by-artist/{artistId}")]
    public async Task<IActionResult> GetByArtist(int artistId)
    {
        var trackDtos = await _trackService.GetByArtistAsync(artistId);

        return Ok(trackDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TrackCreateDto trackDto)
    {
        var trackGetDto = await _trackService.CreateAsync(trackDto);

        return Created($"api/tracks/{trackGetDto.Id}", trackGetDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TrackCreateDto dto)
    {
        var trackGetDto = await _trackService.UpdateAsync(id, dto);

        if (trackGetDto is null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _trackService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPatch("{id}/genre/{genreId}")]
    public async Task<IActionResult> AddGenre(int id, int genreId)
    {
        var result = await _trackService.AddGenreAsync(id, genreId);

        if (result is false)
            return NotFound();

        return NoContent();
    }
}
