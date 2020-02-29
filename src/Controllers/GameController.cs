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
            thegame.Field.InitializeField(width, height, colorsCount);
            return Ok(thegame.Field.GetField());
        }

        [HttpGet("click")]
        public IActionResult Click(int x, int y)
        {
            return Ok(thegame.Field.ClickedTo(x, y));
        }
    }
}
