using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public static class Mapper
{
    public static UserMove MapFromUserInputDtoToUserMove(UserInputDto userInputDto)
    {
        var keyPressed = userInputDto.KeyPressed;
        var userMove = new UserMove();

        userMove.MoveDirection = keyPressed switch
        {
            (char) 40 => Direction.Down,
            (char) 38 => Direction.Up,
            (char) 39 => Direction.Right,
            (char) 37 => Direction.Left,
            _ => userMove.MoveDirection
        };

        return userMove;
    }

    public static GameDto MapFromGameToGameDto(Game game)
    {
        // var cellsDto = new List<CellDto>();
        // foreach (var cell in game.Cells)
        // {
        //     cellsDto.Add();
        // }
        
        throw new NotImplementedException();
    }

    public static CellDto MapFromCellToCellDto(Cell cell)
    {
        throw new NotImplementedException();
    }
}