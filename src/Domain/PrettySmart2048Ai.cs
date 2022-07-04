using System;
using System.Collections.Concurrent;
using thegame.Domain.Models;

namespace thegame.Domain;

// INTERNET SAYS ALG IS QUITE GOOD!!11
public class PrettySmart2048Ai : IGame2048AI
{
    private static readonly Direction[] MOVES = {
        Direction.Right, Direction.Down,
        Direction.Left, Direction.Down,
        Direction.Right, Direction.Down,
        Direction.Left
    };

    private ConcurrentDictionary<Guid, int> turnCounts = new();
    public UserMove ComputeMove(Game game)
    {
        if (!turnCounts.TryGetValue(game.Id, out var currentTurn))
        {
            currentTurn = 0;
            turnCounts[game.Id] = currentTurn;
        }

        var move = new UserMove
        {
            MoveDirection = MOVES[currentTurn % MOVES.Length]
        };

        turnCounts[game.Id]++;
        return move;
    }
}