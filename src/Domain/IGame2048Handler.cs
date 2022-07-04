using thegame.Models;

namespace thegame.Domain;

public interface IGame2048Handler
{
    GameDto StartGame();
    GameDto MakeMove(GameDto game, UserInputDto move);
}