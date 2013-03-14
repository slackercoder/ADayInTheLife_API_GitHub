using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADayInTheLifeAPI.Models
{
    public class TurnModel
    {
        public int TurnId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int TurnInGame { get; set; }
        public int TimeLeft { get; set; }
    }
}
