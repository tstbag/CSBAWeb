using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class StadiumDomainModel

       {
            #region Automatic Properties
            public int StadiumID { get; set; }
            public string StadiumName { get; set; }
            public bool Active_Flg { get; set; }
            public byte[] StadiumImage { get; set; }
            #endregion
        }

}
