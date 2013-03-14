using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADayInTheLifeAPI.Models
{
    public class GameModel
    {
        public int GameId { get; set; }
        public int Players { get; set; }
        public List<String> PlayerNames { get; set; }
        public int WinCondition1 { get; set; }
        public int WinCondition2 { get; set; }
        public int WinCondition3 { get; set; }
        public int WinCondition4 { get; set; }
        public int CurrentTurn { get; set; }
    }
}