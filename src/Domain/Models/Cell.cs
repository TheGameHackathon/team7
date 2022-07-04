using System;

namespace thegame.Domain.Models;

public class Cell
{
    public Guid Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Value { get; set; }

    public Cell WithValue(int value)
    {
        return new Cell
        {
            Id = Id,
            X = X,
            Y = Y,
            Value = value
        };
    }
}