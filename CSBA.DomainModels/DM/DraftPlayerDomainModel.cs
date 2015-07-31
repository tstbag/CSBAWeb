using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class DraftPlayerDomainModel
    {
        public int SeasonID { get; set; }
        public string PositionName { get; set; }
        public int PosCount { get; set; }
        public int Drafted { get; set; }

    }
}
