using System;
using thegame.Domain.Models;

namespace thegame.Domain;

public class Random2048Ai : IGame2048AI
{
    private Random rnd = new Random();
    
    public UserMove ComputeMove(Game game)
    {
        var direction = rnd.Next(4) switch
        {
            0 => Direction.Up,
            1 => Direction.Right,
            2 => Direction.Down,
            3 => Direction.Left
        };
        return new UserMove { MoveDirection = direction };
    }
}