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
    
    public partial class SeasonPlayerPositionStat
    {
        public int SeasonID { get; set; }
        public Nullable<System.Guid> PlayerGUID { get; set; }
        public int PositionID { get; set; }
        public int StatID { get; set; }
        public string StatValue { get; set; }
    
        public virtual Stat Stat { get; set; }
        public virtual Player Player { get; set; }
    }
}
