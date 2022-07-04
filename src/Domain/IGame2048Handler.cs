using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public interface IGame2048Handler
{
    Game StartGame(int fieldSize);
    Game MakeMove(Game game, UserMove move);
}