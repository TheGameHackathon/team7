using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services
{
    public class GamesRepo
    {
        private static GameDto gameDto;

        public static GameDto GetOrCreateGameDto()
        {
            if (gameDto == null || gameDto.IsFinished)
            {
                gameDto = CreateGameDto();
            }

            return gameDto;
        }

        private static GameDto CreateGameDto()
        {
            var width = 10;
            var height = 8;
            var testCells = new CellDto[width * height];
            var random = new Random();
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var color = random.Next(1, 5);
                    testCells[i * width + j] = new CellDto($"{i * width + j}",
                        new VectorDto(j, i), $"color{color}", "", 0);
                }
            }
            
            return new GameDto(testCells, true, 
                true, width, height, Guid.Empty, 
                false, 0, 5);
        }
    }
}