using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface SeasonTeam_IDALBLL
    {
        List<SeasonTeamDomainModel> SeasonTeamOrder(int SeasonID);
        List<SeasonTeamDomainModel> ListSelectedTeams(int SeasonID);
        List<SeasonTeamDomainModel> ListRemainingTeams(int SeasonID);
        void DeleteSeasonTeamAll(int SeasonID);
        void InsertSeasonTeam(SeasonTeamDomainModel _SeasonTeam);
        //void MoveSeasonTeam(int SeasonID, int TeamID, int MoveDir);
    }
}
