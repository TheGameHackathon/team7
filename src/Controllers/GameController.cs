using Microsoft.AspNetCore.Mvc;
using thegame;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("field")]
        public IActionResult Field(int width, int height, int colorsCount)
        {
            return Ok(new thegame.Field(width, height, colorsCount).GetField());
        }
    }
}
