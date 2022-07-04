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
        game.Id = id;
        db[id] = game;
        return game;
    }

    public GameDto GetGame(Guid id)
    {
        return db.ContainsKey(id) ? db[id] : null;
    }

    public void Update(GameDto game)
    {
        if(game is null) return;
        if (db.ContainsKey(game.Id))
        {
            db[game.Id] = game;
        }
    }
}