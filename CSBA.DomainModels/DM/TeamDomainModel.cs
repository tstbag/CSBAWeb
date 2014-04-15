using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class TeamDomainModel
    {
        #region Automatic Properties
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string UserName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public Guid? OwnerUserID { get; set; }
        public byte[] TeamImage { get; set; }
        #endregion
    }
}
