using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface SeasonTeamStadium_IDALBLL
    {
        #region SeasonStadium
        #region Select Signatures
        List<SeasonTeamStadiumDomainModel> DraftStadium(int SeasonID);
        #endregion

        #region Assign
        //void AssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID);
        //void UnAssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID);
        #endregion
        #endregion

    }
}
