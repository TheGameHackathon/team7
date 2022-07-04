using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public static class Mapper
{
    private static HashSet<int> possibleKeyCodes = new(new[] {37, 38, 39, 40});
    public static UserMove MapFromUserInputDtoToUserMove(UserInputDto userInputDto)
    {
        var keyPressed = userInputDto.KeyPressed;
        var userMove = new UserMove();
        if (!possibleKeyCodes.Contains(keyPressed))
            return null;

        userMove.MoveDirection = keyPressed switch
        {
            (char) 40 => Direction.Down,
            (char) 38 => Direction.Up,
            (char) 39 => Direction.Right,
            (char) 37 => Direction.Left
        };

        return userMove;
    }

    public static GameDto MapFromGameToGameDto(Game game)
    {
        var cellsDto = (from Cell cell in game.Cells select MapFromCellToCellDto(cell)).ToArray();

        var gameDto = new GameDto(
            cellsDto,
            true,
            false,
            game.Size.Width,
            game.Size.Height,
            game.Id,
            game.IsFinished,
            game.Score);

        return gameDto;
    }

    public static CellDto MapFromCellToCellDto(Cell cell)
    {
        var position = new VectorDto {X = cell.X, Y = cell.Y};
        var cellDto = new CellDto(
            $"td_{cell.X}_{cell.Y}",
            position,
            "game2048",
            cell.Value.ToString(),
            1);

        return cellDto;
    }
}