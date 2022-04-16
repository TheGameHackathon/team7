using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{hardness}")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index(int hardness)
        {
            return Ok(GamesRepo.CreateGameDto(hardness));
        }
    }
}
