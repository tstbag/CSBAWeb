using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonPlayerDomainModel
    {
        public int SeasonID { get; set; }
        public Guid PlayerGUID { get; set; }
        public string PlayerName { get; set; }

    }
}
