using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpotiPie.Data;
using SpotiPie.Services;
using SpotiPie.Text;

namespace SpotiPie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITextsService _textsService;

        public TextController(AppDbContext appDbContext, ITextsService textsService)
        {
            _appDbContext = appDbContext;
            _textsService = textsService;
        }

        [HttpGet("GetByIdText")]
        public async Task<ActionResult> Get(int id)
        {
            var text = await _textsService.GetTextById(id);
            return Ok(text);
        }

        [HttpGet("GetAllText")]
        public async Task<ActionResult> GetAllText()
        {
            var text = await _textsService.GetAllText();
            return Ok(text);
        }

        [HttpPost]
        public async Task<ActionResult> PostText(TextSong textSong)
        {
            await _textsService.PostText(textSong);
            return Ok();
        }
    }
}
