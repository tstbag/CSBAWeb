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
        public string StatFullName { get; set; }
        public int? PositionTypeID { get; set; }
        public string PositionType { get; set; }
        #endregion
    }
}
