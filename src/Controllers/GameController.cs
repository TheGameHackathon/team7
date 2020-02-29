using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Field()
        {
            return Ok(thegame.Field.GenerateField(5, 5, 5));
        }
    }
}
