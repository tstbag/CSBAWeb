using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.DomainModels
{
    public class sp_StadiumDraft_Select_Result_DomainModel
    {
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
        public Nullable<int> StadiumOrder { get; set; }
        public Nullable<int> StadiumID { get; set; }
        public Nullable<int> Points { get; set; }
        public string TeamName { get; set; }
        public Nullable<System.Guid> OwnerUserID { get; set; }
        public string IsOwner { get; set; }
        public string StadiumName { get; set; }
        public byte[] StadiumImage { get; set; }
    }
}
