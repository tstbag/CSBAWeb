using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonDomainModel
    {
        #region Automatic Properties
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public DateTime DraftDate { get; set; }
        public int StartPoints { get; set; }
        public int MinBid { get; set; }
        public int? PlayersDrafted { get; set; }

        public bool CurrentSeason { get; set; }
        public Nullable<bool> Active { get; set; }
        #endregion
    }
}
