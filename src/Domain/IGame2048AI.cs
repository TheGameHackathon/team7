using thegame.Domain.Models;

namespace thegame.Domain;

public interface IGame2048AI
{
    UserMove ComputeMove(Game game);
}