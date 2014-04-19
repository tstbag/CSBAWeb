using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonTeamDomainModel
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int? StadiumOrder { get; set; }
        public bool? ActiveFlg { get; set; }
        public Nullable<int> MaxBid { get; set; }
    }
}
