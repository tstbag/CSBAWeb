using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class SeasonStadiumDomainModel
    {
        #region Automatic Properties
        public int SeasonID { get; set; }
        public int StadiumID { get; set; }
        public string SeasonName { get; set; }
        public string StadiumName { get; set; }
        public string StadiumURL { get; set; }
        #endregion

    }
}

