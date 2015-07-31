using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface DraftPlayerIDALBLL
    {
        List<sp_SeasonTeamDraft_Select_ResultDomainModel> DraftTeamList(int SeasonID);
        PickAPlayerDomainModel PickAPLayer(int SeasonID);
        void DraftPlayer(SeasonTeamPlayerDomainModel STP);
        void TradePlayer(SeasonTeamPlayerDomainModel STP, int NewTeamID, int Points);
        DraftStatusDomainModel DraftStatus(int SeasonID);

        List<DraftPlayerDomainModel> DraftPositionStatus(int SeasonID, int iDrafted);
    }
}
