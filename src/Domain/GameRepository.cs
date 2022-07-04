using System;
using System.Collections.Generic;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public class GameRepository : IGameRepository
{
    private Dictionary<Guid, Game> db;

    public Game AddGame(Game game)
    {
        if (game.Id != Guid.Empty)
        {
            throw new InvalidOperationException("Guid already set!");
        }

        var id = Guid.NewGuid();
        return null;
    }

    public Game GetGame(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Game game)
    {
        throw new NotImplementedException();
    }
}