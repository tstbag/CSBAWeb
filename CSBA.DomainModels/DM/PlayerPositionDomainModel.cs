using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class PlayerPositionDomainModel
    {
        public System.Guid PlayerGUID { get; set; }
        public Nullable<int> PrimaryPositionID { get; set; }
        public Nullable<int> SecondaryPostiionID { get; set; }

    }
}
