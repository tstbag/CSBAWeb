using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonPlayerPositionStatDomainModel
    {
        public int SeasonID { get; set; }
        public Nullable<System.Guid> PlayerGUID { get; set; }
        public int PositionID { get; set; }
        public int StatID { get; set; }
        public string StatValue { get; set; }

    }
}
