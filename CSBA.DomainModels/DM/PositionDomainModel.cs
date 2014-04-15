using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class PositionDomainModel
    {
        public int PositionID { get; set; }
        public Nullable<int> PositionTypeID { get; set; }
        public string PositionName { get; set; }
        public Nullable<int> MaxCount { get; set; }
        public string PositionNameLong { get; set; }
    }
}
