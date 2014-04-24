using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class TradeDataDomainModel
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
