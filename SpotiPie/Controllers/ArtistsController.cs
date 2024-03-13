using Microsoft.AspNetCore.Mvc;
using SpotiPie.Services;
using SpotiPie.Contracts;

namespace SpotiPie.Controllers
{
    [ApiController]
    [Route("api/Artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistService _artistService;

        [HttpGet("Get-All")]
        public async Task<ActionResult> GetAllArtists()
        {
            var artists =await _artistService.GetAll();
            return Ok(artists);
        }
        [HttpGet("Get-By-Id")]
        public async Task<ActionResult> Get(int Id)
        {
            var artist = await _artistService.Get(Id);
            return Ok(artist);
        }
        [HttpPost("Add")]
        public async Task<ActionResult> AddArtist(ArtistDto artist)
        {
            await _artistService.Add(artist);
            return Ok(artist);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteArtist(int Id)
        {
            await _artistService.Delete(Id);
            return NoContent();
        }
    }
}
