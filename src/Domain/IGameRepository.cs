using System;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public interface IGameRepository
{
    // Need empty Guid, returns with new Guid
    Game AddGame(Game game);

    Game GetGame(Guid id);

    // Update by Guid
    void Update(Game game);
}