using System;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

// todo IT SHOULDN'T USE DTOS
public class Game2048Handler : IGame2048Handler
{
    private const int GAME_SIZE = 4; //todo
    private const int CELL_WITH_FOUR_PROBABILITY_PERCENT = 20;
    
    private Random rnd = new Random();
    
    public Game StartGame()
    {
        // var
        return null;
    }

    public Game MakeMove(Game game, UserMove move)
    {
        throw new System.NotImplementedException();
    }

    private Cell GenerateCell(VectorDto pos)
    {
        var cellValue = (rnd.Next(100) < CELL_WITH_FOUR_PROBABILITY_PERCENT)
            ? 4
            : 2;
        return null;
        // return new CellDto(null, pos)
    }
}