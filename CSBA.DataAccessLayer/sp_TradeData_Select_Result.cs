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
    
    public partial class sp_TradeData_Select_Result
    {
        public int SeasonID { get; set; }
        public System.Guid TradeGUID { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string TeamName { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public Nullable<System.DateTime> ProposedDate { get; set; }
        public Nullable<int> TradeStatusID { get; set; }
        public string TradeStatusDesc { get; set; }
    }
}
