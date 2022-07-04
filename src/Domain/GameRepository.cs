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
        game.Id = id;
        db[id] = game;
        return game;
    }

    public Game GetGame(Guid id)
    {
        return db.ContainsKey(id) ? db[id] : null;
    }

    public void Update(Game game)
    {
        if(game is null) return;
        if (db.ContainsKey(game.Id))
        {
            db[game.Id] = game;
        }
    }
}