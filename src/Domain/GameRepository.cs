using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Domain;

public class GameRepository : IGameRepository
{
    private Dictionary<Guid, GameDto> db;

    public GameDto AddGame(GameDto game)
    {
        if (game.Id != Guid.Empty)
        {
            throw new InvalidOperationException("Guid already set!");
        }

        var id = Guid.NewGuid();
        return null;
    }

    public GameDto GetGame(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(GameDto game)
    {
        throw new NotImplementedException();
    }
}