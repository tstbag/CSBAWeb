using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class PickAPlayerDomainModel
    {
        public System.Guid PlayerGUID { get; set; }
        public string PlayerName { get; set; }
        public byte[] PlayerImage { get; set; }
        public int? PrimPositionTypeID { get; set; }
        public string PrimPositionName { get; set; }
        public string PrimPositionTypeDescr { get; set; }
        public string SecPositionName { get; set; }
        public string SecPositionTypeDescr { get; set; }
    }
}
