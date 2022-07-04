using System;
using System.Drawing;

namespace thegame.Domain.Models;

public class Game
{
    public Guid Id { get; set; }
    
    public Size Size { get; set; }
    public Cell[,] Cells { get; set; }
    
    public bool IsFinished { get; set; }
    public int Score { get; set; }
    
    // public Game Copy
}