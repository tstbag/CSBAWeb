using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;


namespace CSBA.Contracts
{
    public interface DraftStadiumIDALBLL
    {
        List<sp_StadiumDraft_Select_Result_DomainModel> DraftStadiumList(int SeasonID, Guid? OwnerUserID);
    }
}
