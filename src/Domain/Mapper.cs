using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

public static class Mapper
{
    public static UserMove MapFromUserInputDtoToUserMove(UserInputDto userInput)
    {
        throw new NotImplementedException();
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