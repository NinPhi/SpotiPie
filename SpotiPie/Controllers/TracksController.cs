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
}
