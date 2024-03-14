using Microsoft.AspNetCore.Mvc;
using SpotiPie.Entities.Contracts;
using SpotiPie.Services;

namespace SpotiPie.Controllers;

[Route("api/tracks")]
[ApiController]
public class TracksController : ControllerBase
{
    private readonly TrackService _trackService;

    public TracksController(TrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var tracks = await _trackService.GetAllAsync();
            return Ok(tracks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var track = await _trackService.GetByIdAsync(id);
            return Ok(track);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(TrackCreateDto dto)
    {
        try
        {
            var createdTrack = await _trackService.CreateAsync(dto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TrackCreateDto dto)
    {
        try
        {
            await _trackService.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _trackService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
