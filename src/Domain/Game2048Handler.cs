using System;
using System.Drawing;
using System.Linq;
using thegame.Domain.Models;
using thegame.Models;

namespace thegame.Domain;

// todo IT SHOULDN'T USE DTOS
public class Game2048Handler : IGame2048Handler
{
    private const int GAME_SIZE = 4; //todo
    private const int CELLS_AT_START_COUNT = 2;
    private const int CELL_WITH_FOUR_PROBABILITY_PERCENT = 20;
    
    private Random rnd = new Random();
    
    public Game StartGame()
    {
        var cells = GenerateEmptyFieldCells(GAME_SIZE, GAME_SIZE);
        var game = new Game
        {
            Size = new Size(cells.GetLength(1), cells.GetLength(0)),
            Cells = cells
        };
        GenerateFirstCells(game);
        return game;
    }

    public Game MakeMove(Game game, UserMove move)
    {
        throw new System.NotImplementedException();
    }

    private Cell GenerateCell(int x, int y)
    {
        var cellValue = (rnd.Next(100) < CELL_WITH_FOUR_PROBABILITY_PERCENT)
            ? 4
            : 2;
        return new Cell
        {
            X = x,
            Y = y,
            Value = cellValue
        };
    }

    private static Cell[,] GenerateEmptyFieldCells(int width, int height)
    {
        var cells = new Cell[height, width];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                cells[y, x] = new Cell
                {
                    X = x,
                    Y = y,
                    Value = 0
                };
            }
        }

        return cells;
    }

    private void GenerateFirstCells(Game game)
    {
        for (var i = 0; i < CELLS_AT_START_COUNT; i++)
        {
            var cellIdx = rnd.Next(game.Cells.Length);
            var (x, y) = (
                cellIdx % game.Cells.GetLength(1),
                cellIdx / game.Cells.GetLength(0)
            );

            game.Cells[y, x] = GenerateCell(x, y);
        }
    }
}