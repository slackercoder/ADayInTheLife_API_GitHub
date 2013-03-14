using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADayInTheLifeAPI.Models
{
    public class TurnMoveModel
    {
        public int TurnMoveId { get; set; }
        public int TurnId { get; set; }
        public int TurnFrom { get; set; }
        public int TurnTo { get; set; }
        public int Bought { get; set; }
        public int TimeUsed { get; set; }
    }
}
