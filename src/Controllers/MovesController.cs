using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private HashSet<CellDto> catchedCells = new();

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
        {
            var game = GamesRepo.GetOrCreateGameDto();
            if (userInput.ClickedPos != null)
            {
                game.MovesCount++;
                var cell = game.Cells.First(c => 
                    c.Pos.X == userInput.ClickedPos.X 
                    && c.Pos.Y == userInput.ClickedPos.Y);
                
                var upLeftCell = game.Cells.First(c => 
                    c.Pos.X == 0 && c.Pos.Y == 0);

                catchedCells.Clear();
                FindAllCells(game.Cells, upLeftCell);

                foreach (var cellDto in catchedCells)
                {
                    cellDto.Type = cell.Type;
                }

                if (catchedCells.Count == game.Cells.Length || game.MovesCount == game.MovesCountAllowed)
                {
                    game.IsFinished = true;
                }
            }
            
            return Ok(game);
        }

        private void FindAllCells(CellDto[] field, CellDto cellDto)
        {
            catchedCells.Add(cellDto);

            for (var dx = -1; dx <= 1; dx++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0 || Math.Abs(dx) + Math.Abs(dy) == 2)
                        continue;

                    var newX = cellDto.Pos.X + dx;
                    var newY = cellDto.Pos.Y + dy;
                    var newCell = field.FirstOrDefault(c => c.Pos.X == newX && c.Pos.Y == newY);
                    if (newCell == null)
                    {
                        continue;
                    }
                    if (catchedCells.Contains(newCell))
                    {
                        continue;
                    }
                    
                    if (newCell.Type == cellDto.Type)
                    {
                        FindAllCells(field, newCell);
                    }
                }
            }
        }
    }
}