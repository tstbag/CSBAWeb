using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface SeasonPlayer_IDALBLL
    {
        void InsertSeasonPlayer(SeasonPlayerDomainModel _SeasonPlayer);
        void DeleteSeasonPlayerAll(SeasonPlayerDomainModel _SeasonPlayer, PositionDomainModel _Position);
        List<SeasonPlayerDomainModel> ListSelectedPlayers(int SeasonID, int PositionID);
        List<SeasonPlayerDomainModel> ListRemainingPlayers(int SeasonID, int PositionID);
        void InsertSeasonPlayerRecycle(SeasonPlayerDomainModel _SeasonPlayer);
        void DeleteSeasonRecyclePlayerAll(SeasonPlayerDomainModel _SeasonPlayer);
    }
}
