using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class v_Team_Draft_RosterDomainModel

    {
        public string SeasonName { get; set; }
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public string TeamName { get; set; }
        public Nullable<int> Points { get; set; }
        public Guid? PlayerGuid { get; set; }
        public string PlayerName { get; set; }
        public byte[] PlayerImage { get; set; }
        public string SecPos { get; set; }
        public string PrimPos { get; set; }
    }
}
