using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Domain;
using thegame.Domain.Models;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGameRepository gameRepository;
    private readonly IGame2048Handler game2048Handler;
    private readonly IMapper mapper;

    public GamesController(IGame2048Handler game2048Handler, IGameRepository gameRepository, IMapper mapper)
    {
        this.game2048Handler = game2048Handler;
        this.gameRepository = gameRepository;
        this.mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult Index()
    {
        var game = game2048Handler.StartGame();

        gameRepository.AddGame(game);

        var gameDto = mapper.Map<GameDto>(game);

        return Ok(gameDto);
    }
}