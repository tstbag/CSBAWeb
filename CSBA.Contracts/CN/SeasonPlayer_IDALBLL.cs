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
        void DeleteSeasonPlayerAll(SeasonPlayerDomainModel _SeasonPlayer);
        List<SeasonPlayerDomainModel> ListSelectedPlayers(int SeasonID);
        List<SeasonPlayerDomainModel> ListRemainingPlayers(int SeasonID);
    }
}
