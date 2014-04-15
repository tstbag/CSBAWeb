using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class PlayerDomainModel
    {
        #region Automatic Properties
        public Guid PlayerGUID {get;set;}
        public string PlayerName{get;set;}
        public byte[] PlayerImage { get; set; }
        #endregion
    }
}
