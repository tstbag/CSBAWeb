using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels 
{
    public class sp_SeasonTeamDraft_Select_ResultDomainModel
    {
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string OwnerName { get; set; }
        public Nullable<System.Guid> OwnerUserID { get; set; }
        public string OwnerEmail { get; set; }
        public int SumPoints { get; set; }
        public int CountPlayers { get; set; }
        public int StartPoints { get; set; }
        public Nullable<int> MinBid { get; set; }
        public Nullable<int> MaxBid { get; set; }
        public int CountHitter { get; set; }
        public int PitcherCount { get; set; }
    }
}
