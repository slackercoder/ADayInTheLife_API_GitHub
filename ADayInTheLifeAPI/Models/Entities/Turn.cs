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
    
    public partial class Turn
    {
        public int TurnId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int TurnInGame { get; set; }
        public int TimeLeft { get; set; }
    }
}
