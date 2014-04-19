using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;


namespace CSBA.BusinessLogicLayer
{
    public class DraftStadiumBLL : DraftStadiumIDALBLL
    {
        DraftStadiumDAL DAL = new DraftStadiumDAL();

        public List<sp_StadiumDraft_Select_Result_DomainModel> DraftStadiumList(int SeasonID, Guid? OwnerUserID)
        {
            return DAL.DraftStadiumList(SeasonID, OwnerUserID);
        }
    }
}
