using System;

namespace thegame.Models;

public class GameDto
{
    public GameDto(
        CellDto[] cells, 
        bool monitorKeyboard, 
        bool monitorMouseClicks, 
        int width, 
        int height, 
        Guid id, 
        bool isFinished, 
        int score,
        int size
        )
    {
        Cells = cells;
        MonitorKeyboard = monitorKeyboard;
        MonitorMouseClicks = monitorMouseClicks;
        Width = width;
        Height = height;
        Id = id;
        IsFinished = isFinished;
        Score = score;
        Size = size;
    }

    public CellDto[] Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool MonitorKeyboard { get; set; }
    public bool MonitorMouseClicks { get; set; }
    public Guid Id { get; set; }
    public bool IsFinished { get; set; }
    public int Score { get; set; }
    
    public int Size { get; set; }
}