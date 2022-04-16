using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(VectorDto movingObjectPosition)
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
                    testCells[i * height + j] = new CellDto($"{i * width + j}",
                        new VectorDto(i, j), $"color{color}", "", 0);
                }
            }
            
            return new GameDto(testCells, true, 
                true, width, height, Guid.Empty, 
                movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}