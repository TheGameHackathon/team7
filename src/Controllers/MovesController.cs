using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Domain;
using thegame.Models;
using thegame.Services;
using thegame.Domain.Models;

namespace thegame.Controllers;

[ApiController]
[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private readonly IGameRepository gameRepository;
    private readonly IGame2048Handler game2048Handler;
        
    public MovesController(IGameRepository gameRepository, IGame2048Handler game2048Handler)
    {
        this.gameRepository = gameRepository;
        this.game2048Handler = game2048Handler;
    }
        
    [HttpPost(Name = nameof(Moves))]
    public IActionResult Moves([FromRoute]Guid gameId, [FromBody]UserInputDto userInputDto)
    {
        if (userInputDto == null || gameId == Guid.Empty)
            return BadRequest();
        
        var userMove = Mapper.MapFromUserInputDtoToUserMove(userInputDto);

        var game = gameRepository.GetGame(gameId);
        
        if (userMove is null)
        {
            return CreatedAtRoute(
                nameof(Moves),
                new { gameId },
                Mapper.MapFromGameToGameDto(game));
        }
        
        game = game2048Handler.MakeMove(game, userMove);
        gameRepository.Update(game);
        
        var gameDto = Mapper.MapFromGameToGameDto(game);
        
        return CreatedAtRoute(
            nameof(Moves),
            new { gameId },
            gameDto);
    }
}