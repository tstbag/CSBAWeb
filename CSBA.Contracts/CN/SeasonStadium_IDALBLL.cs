using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface SeasonStadium_IDALBLL
    {
        #region SeasonStadium
        #region Select Signatures
        List<SeasonStadiumDomainModel> ListStadiumsBySeason(int SeasonID, int AssignFlg);
        List<SeasonStadiumDomainModel> AvailableStadiumsSeason(int SeasonID);
        #endregion

        #region Assign
        void AssignStadiumToSeason(int SeasonID, int StadiumID);
        void RestartStadiumDraft(int SeasonID);
        #endregion

        List<SeasonStadiumDomainModel> ListSelectedStadiums(int SeasonID);
        List<SeasonStadiumDomainModel> ListRemainingStadiums(int SeasonID);
        void InsertSeasonStadium(SeasonStadiumDomainModel _SeasonStadium);
        void DeleteSeasonStadiumAll(SeasonStadiumDomainModel _SeasonStadium);
        #endregion
    }
}
