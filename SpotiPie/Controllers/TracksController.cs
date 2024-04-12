using SpotiPie.Entities.Contracts;

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

    [HttpPost("{id}/data")]
    public async Task<IActionResult> UploadFile(int id, IFormFile file)
    {
        var extensions = new string[]
        {
            ".mp3", ".mp4", ".wav", ".ogg",
        };

        var fileExtension = Path.GetExtension(file.FileName);

        if (!extensions.Contains(fileExtension))
            return BadRequest($"We only support these extensions: {string.Join(' ', extensions)}");

        var mimeTypes = new string[]
        {
            "audio/mpeg", "audio/mp4", "audio/ogg", "audio/vnd.wav",
        };

        if (!mimeTypes.Contains(file.ContentType))
            return BadRequest($"We only support these MIME types: {string.Join(' ', mimeTypes)}");

        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);
        byte[] data = stream.ToArray();

        if (data.Length > 1024 * 1024 * 10)
            return BadRequest("File size is too big, 10Mb is maximum.");

        var dto = new TrackDataDto()
        {
            TrackId = id,
            Data = data,
            FileName = file.FileName,
            MimeType = file.ContentType,
        };

        var result = await _trackService.UploadDataAsync(dto);

        if (result is false)
            return NotFound();

        return NoContent();
    }

    [HttpGet("{id}/data")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        var dto = await _trackService.DownloadDataAsync(id);

        if (dto is null)
            return NotFound();

        return File(dto.Data, dto.MimeType, dto.FileName);
    }
}
