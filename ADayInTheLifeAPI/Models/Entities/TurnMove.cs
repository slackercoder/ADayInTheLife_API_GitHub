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
    
    public partial class TurnMove
    {
        public int TurnMoveId { get; set; }
        public int TurnId { get; set; }
        public int TurnFrom { get; set; }
        public int TurnTo { get; set; }
        public int Bought { get; set; }
        public int TimeUsed { get; set; }
    }
}