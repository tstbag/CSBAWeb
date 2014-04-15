using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonTeamPlayerPositionDomainModel
    {

        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public Guid? PlayerGUID { get; set; }
        public Nullable<int> Points { get; set; }
        public string PlayerName { get; set; }
        public string PositionName { get; set; }
        public string PositionNameLong { get; set; }
        public string TeamName { get; set; }
    }
}


