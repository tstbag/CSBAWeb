using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public partial class v_PlayerPositionDomainModel
    {
        public System.Guid PlayerGUID { get; set; }
        public string PlayerName { get; set; }
        public byte[] PlayerImage { get; set; }
        public Nullable<int> PrimaryPositionID { get; set; }
        public Nullable<int> SecondaryPostiionID { get; set; }
        public string PrimPosName { get; set; }
        public string PrimPosNameLong { get; set; }
        public string SecPosName { get; set; }
        public string SecPosNameLong { get; set; }
    }
}
