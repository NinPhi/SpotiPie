using Microsoft.AspNetCore.Mvc;
using SpotiPie.Contracts;
using SpotiPie.Services.Interfaces;

namespace SpotiPie.Controllers
{
    [ApiController]
    [Route("Albums")]
    public class AlbumController:ControllerBase 
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<ActionResult<AlbumGetDto>> GetAlbumByIdAsync(int albumId)
        {
            var album = await _albumService.GetAlbumByIdAsync(albumId);

            return Ok(album);
        }
    }
}
