using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;


namespace CSBA.Contracts
{
    public interface Season_IDALBLL
    {
        #region Season
        #region Select Signatures
        List<SeasonDomainModel> ListSeasonID_Name();
        List<SeasonDomainModel> ListSeason();
        List<SeasonDomainModel> ListSeasonView();
        #endregion

        #region Insert Signatures
        SeasonDomainModel InsertSeason(SeasonDomainModel season);
        #endregion

        #region Update Signatures
        void UpdateSeason(SeasonDomainModel season);
        #endregion

        #region Delete Signatures
        void DeleteSeason(SeasonDomainModel season);
        void ClearSeason(SeasonDomainModel season);
        #endregion
        #endregion
    }
}
