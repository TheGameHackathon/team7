using Microsoft.AspNetCore.Mvc;
using thegame.Domain;
using thegame.Domain.Models;
using thegame.Models;
using thegame.Services;
using Mapper = thegame.Domain.Mapper;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGameRepository gameRepository;
    private readonly IGame2048Handler game2048Handler;

    public GamesController(IGame2048Handler game2048Handler, IGameRepository gameRepository)
    {
        this.game2048Handler = game2048Handler;
        this.gameRepository = gameRepository;
    }
    
    [HttpPost]
    public IActionResult Index()
    {
        var game = game2048Handler.StartGame();

        gameRepository.AddGame(game);

        var gameDto = Mapper.MapFromGameToGameDto(game);

        return Ok(gameDto);
    }
}