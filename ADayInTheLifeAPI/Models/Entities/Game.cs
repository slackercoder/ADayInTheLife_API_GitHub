//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADayInTheLifeAPI.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public int GameId { get; set; }
        public int Players { get; set; }
        public int WinCondition1 { get; set; }
        public int WinCondition2 { get; set; }
        public int WinCondition3 { get; set; }
        public int WinCondition4 { get; set; }
        public Nullable<int> CurrentTurn { get; set; }
    }
}
