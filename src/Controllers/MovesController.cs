using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Domain;
using thegame.Models;
using thegame.Services;
using AutoMapper;
using thegame.Domain.Models;

namespace thegame.Controllers;

[ApiController]
[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private readonly IGameRepository gameRepository;
    private readonly IMapper mapper;
    private readonly IGame2048Handler game2048Handler;
        
    public MovesController(IGameRepository gameRepository, IMapper mapper, IGame2048Handler game2048Handler)
    {
        this.gameRepository = gameRepository;
        this.mapper = mapper;
        this.game2048Handler = game2048Handler;
    }
        
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInputDto)
    {
        if (userInputDto == null || gameId == Guid.Empty)
            return BadRequest();

        var userMove = mapper.Map<UserMove>(userInputDto);
        var game = gameRepository.GetGame(gameId);
        game = game2048Handler.MakeMove(game, userMove);
        gameRepository.Update(game);

        var gameDto = mapper.Map<GameDto>(game);
        
        return CreatedAtRoute(
            nameof(Moves),
            new { gameId },
            gameDto);
    }
}