using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class StatDomainModel
    {
        #region Automatic Properties
        public int StatID { get; set; }
        public string StatName { get; set; }
        public Nullable<int> PositionTypeID { get; set; }
        #endregion
    }
}
