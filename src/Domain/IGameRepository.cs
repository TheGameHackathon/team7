using System;
using thegame.Models;

namespace thegame.Domain;

public interface IGameRepository
{
    // Need empty Guid, returns with new Guid
    GameDto AddGame(GameDto game);

    GameDto GetGame(Guid id);

    // Update by Guid
    void Update(GameDto game);
}