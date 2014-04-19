using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonTeamPlayerDomainModel
    {
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public System.Guid PlayerGUID { get; set; }
        public Nullable<int> Points { get; set; }
    }
}
