//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSBA.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trade()
        {
            this.TradeTeams = new HashSet<TradeTeam>();
        }
    
        public int SeasonID { get; set; }
        public System.Guid TradeGUID { get; set; }
        public Nullable<System.DateTime> ProposedDate { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public Nullable<int> TradeStatusID { get; set; }
        public Nullable<int> TeamID { get; set; }
    
        public virtual Season Season { get; set; }
        public virtual TradeStatu TradeStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TradeTeam> TradeTeams { get; set; }
    }
}
