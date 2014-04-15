using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonTeamStadiumDomainModel
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int StadiumID { get; set; }
        public string StadiumURL { get; set; }
        public string StadiumName { get; set; }
        public int? Active { get; set; }
        public int? StadiumOrder { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTS { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTS { get; set; }



    }


}
