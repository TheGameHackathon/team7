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
            thegame.Field.InitializeField(height, width, colorsCount);
            return Ok(thegame.Field.GetField());
        }

        [HttpPost("click")]
        public IActionResult Click(int x, int y)
        {
            return Ok(thegame.Field.ClickedTo(y, x));
        }
    }
}
