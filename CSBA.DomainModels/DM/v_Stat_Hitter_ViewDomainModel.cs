using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class v_Stat_Hitter_ViewDomainModel
    {

        public string SeasonName { get; set; }
        public string PlayerName { get; set; }
        public Nullable<System.Guid> PlayerGUID { get; set; }
        public string Rangep1 { get; set; }
        public string FLDP1 { get; set; }
        public string RangeP2 { get; set; }
        public string FLDP2 { get; set; }
        public string Agility { get; set; }
        public string RN { get; set; }
        public string AVG { get; set; }
        public string OBA { get; set; }
        public string SLG { get; set; }
        public string AB { get; set; }
        public string Hits { get; set; }
        public string Doubles { get; set; }
        public string Triples { get; set; }
        public string HR { get; set; }
        public string Runs { get; set; }
        public string RBI { get; set; }
        public string HP { get; set; }
        public string BB { get; set; }
        public string Ks { get; set; }
        public string SB { get; set; }
        public string CS { get; set; }
        public string TB { get; set; }
        public string EBH { get; set; }
    }
}
