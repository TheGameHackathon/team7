using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return Ok(GamesRepo.GetOrCreateGameDto(new VectorDto(1, 1)));
        }
    }
}
