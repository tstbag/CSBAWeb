//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSBA.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PositionType
    {
        public PositionType()
        {
            this.Positions = new HashSet<Position>();
            this.Stats = new HashSet<Stat>();
        }
    
        public int PositionTypeID { get; set; }
        public string PositionTypeDescr { get; set; }
    
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Stat> Stats { get; set; }
    }
}
