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
    
    public partial class v_Team_Draft_Roster
    {
        public string SeasonName { get; set; }
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public string TeamName { get; set; }
        public Nullable<int> Points { get; set; }
        public string PlayerName { get; set; }
        public byte[] PlayerImage { get; set; }
        public string SecPos { get; set; }
        public string PrimPos { get; set; }
    }
}
