using System;
using System.Drawing;

namespace thegame.Domain.Models;

public class Game
{
    public Guid Id { get; set; }
    
    public Size size { get; set; }
    public Cell[,] cells { get; set; }
    
    public bool IsFinished { get; set; }
    public int Score { get; set; }
    
    // public Game Copy
}