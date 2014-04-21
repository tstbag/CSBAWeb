using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class DraftPlayerBusinessLogicLayer
    {
        DraftPlayerDAL DAL = new DraftPlayerDAL();
        public List<sp_SeasonTeamDraft_Select_ResultDomainModel> DraftTeamList(int SeasonID)
        {
            return DAL.DraftTeamList(SeasonID);
        }

        public PickAPlayerDomainModel PickAPLayer(int SeasonID)
        {
            return DAL.PickAPLayer(SeasonID);
        }

        public void DraftPlayer(SeasonTeamPlayerDomainModel STP)
        {
            DAL.DraftPlayer(STP);
        }
    }
}
