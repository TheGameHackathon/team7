using System;
using System.Collections.Generic;
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
    
    private Random rnd = new();
    
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
        var fieldAfterCellMerge = ComputeFieldAfterMerge(game.Cells, move);
        var newGame = new Game
        {
            Id = game.Id,
            Cells = fieldAfterCellMerge,
            IsFinished = game.IsFinished,
            Score = 0, // сетнуть
            Size = game.Size
        };

        GenerateNewCell(newGame);
        newGame.IsFinished = IsGameFinished(newGame);
        newGame.Score = ComputeScore(newGame);
        return newGame;
    }

    private Cell GenerateCell(int x, int y)
    {
        var cellValue = (rnd.Next(100) < CELL_WITH_FOUR_PROBABILITY_PERCENT)
            ? 4
            : 2;
        return new Cell
        {
            Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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

    private IEnumerable<Cell> IterateToLeft(Cell[,] field, int y)
    {
        for (var x = field.GetLength(1) - 1; x >= 0; x--)
        {
            yield return field[y, x];
        }
    }

    private IEnumerable<Cell> IterateToRight(Cell[,] field, int y)
    {
        for (var x = 0; x < field.GetLength(1); x++)
        {
            yield return field[y, x];
        }
    }
    
    private IEnumerable<Cell> IterateToDown(Cell[,] field, int x)
    {
        for (var y = 0; y < field.GetLength(0); y++)
        {
            yield return field[y, x];
        }
    }
    
    private IEnumerable<Cell> IterateToUp(Cell[,] field, int x)
    {
        for (var y = field.GetLength(0) - 1; y >= 0; y--)
        {
            yield return field[y, x];
        }
    }

    private Cell[,] MakeFieldOnMoveLeft(Cell[,] oldField)
    {
        var newField = new Cell[oldField.GetLength(0), oldField.GetLength(1)];
        for (var y = 0; y < oldField.GetLength(0); y++)
        {
            var cells = IterateToRight(oldField, y);
            var x = 0;
            foreach (var newCell in GenerateNewLineValues(cells))
            {
                newField[y, x] = newCell;
                newCell.X = x;
                newCell.Y = y;
                x++;
            }
        }

        return newField;
    }

    private Cell[,] MakeFieldOnMoveRight(Cell[,] oldField)
    {
        var newField = new Cell[oldField.GetLength(0), oldField.GetLength(1)];
        for (var y = oldField.GetLength(0) - 1; y >= 0; y--)
        {
            var cells = IterateToLeft(oldField, y);
            var x = 0;
            foreach (var newCell in GenerateNewLineValues(cells).Reverse())
            {
                newField[y, x] = newCell;
                newCell.X = x;
                newCell.Y = y;
                x++;
            }
        }

        return newField;
    }

    private Cell[,] MakeFieldOnMoveUp(Cell[,] oldField)
    {
        var newField = new Cell[oldField.GetLength(0), oldField.GetLength(1)];
        for (var x = 0; x < oldField.GetLength(1); x++)
        {
            var cells = IterateToDown(oldField, x);
            var y = 0;
            foreach (var newCell in GenerateNewLineValues(cells))
            {
                newField[y, x] = newCell;
                newCell.X = x;
                newCell.Y = y;
                
                y++;
            }
        }

        return newField;
    }

    private Cell[,] MakeFieldOnMoveDown(Cell[,] oldField)
    {
        var newField = new Cell[oldField.GetLength(0), oldField.GetLength(1)];
        for (var x = 0; x < oldField.GetLength(1); x++)
        {
            var cells = IterateToUp(oldField, x);
            var y = 0;
            foreach (var newCell in GenerateNewLineValues(cells).Reverse())
            {
                newField[y, x] = newCell;
                newCell.X = x;
                newCell.Y = y;

                y++;
            }
        }

        return newField;
    }

    private Cell[,] ComputeFieldAfterMerge(Cell[,] oldField, UserMove move)
    {
        switch (move.MoveDirection)
        {
            case Direction.Left:
                return MakeFieldOnMoveLeft(oldField);
            case Direction.Right:
                return MakeFieldOnMoveRight(oldField);
            case Direction.Up:
                return MakeFieldOnMoveUp(oldField);
            case Direction.Down:
                return MakeFieldOnMoveDown(oldField);
            default:
                throw new ArgumentException("Unknown direction");
        }
    }

    private IEnumerable<Cell> GenerateNewLineValues(IEnumerable<Cell> line)
    {
        var lineList = line.ToList();

        var cellToMergeWith = (Cell)null;
        var newValuesCount = 0;
        foreach (var cell in lineList.Where(cell => cell.Value != 0))
        {
            if (cellToMergeWith is null)
            {
                cellToMergeWith = cell;
                continue;
            }

            newValuesCount++;
            if (cellToMergeWith.Value == cell.Value)
            {
                yield return cellToMergeWith.WithValue(cellToMergeWith.Value * 2);
                cellToMergeWith = null;
            }
            else
            {
                yield return cellToMergeWith;
                cellToMergeWith = cell;
            }
        }

        if (cellToMergeWith != null)
        {
            newValuesCount++;
            yield return cellToMergeWith;
        }

        for (var i = newValuesCount; i < lineList.Count; i++)
        {
            yield return new Cell
            {
                Id = Guid.NewGuid(),
                Value = 0
            };
        }
    }

    private bool IsGameFinished(Game game)
    {
        if (game.IsFinished)
        {
            return true;
        }

        for (var x = 0; x < game.Cells.GetLength(1); x++)
        {
            for (var y = 0; y < game.Cells.GetLength(0); y++)
            {
                var cell = game.Cells[y, x];
                if (cell.Value == 0)
                {
                    return false;
                }

                if (GetNeighbours(game.Cells, x, y)
                    .Any(cellNeighbour => cellNeighbour.Value == cell.Value))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void GenerateNewCell(Game game)
    {
        if (IsGameFinished(game)) // todo такое себе
        {
            return;
        }
        
        while (true)
        {
            var cellIdx = rnd.Next(game.Cells.Length);
            var (x, y) = (
                cellIdx % game.Cells.GetLength(1),
                cellIdx / game.Cells.GetLength(0)
            );

            if (game.Cells[y, x].Value > 0)
            {
                continue;
            }

            game.Cells[y, x] = GenerateCell(x, y);
            break;
        }
    }

    private int ComputeScore(Game game)
    {
        return Enumerable.Range(0, game.Cells.GetLength(0))
            .SelectMany(y => Enumerable
                .Range(0, game.Cells.GetLength(1))
                .Select(x => (x, y))
            ).Sum(coords => game.Cells[coords.y, coords.x].Value);
    }

    private IEnumerable<Cell> GetNeighbours(Cell[,] field, int x, int y)
    {
        if (x > 0)
        {
            yield return field[y, x - 1];
        }

        if (x < field.GetLength(1) - 1)
        {
            yield return field[y, x + 1];
        }

        if (y > 0)
        {
            yield return field[y - 1, x];
        }

        if (y < field.GetLength(0) - 1)
        {
            yield return field[y + 1, x];
        }
    }
}