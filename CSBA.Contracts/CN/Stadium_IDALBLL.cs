using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
	public interface Stadium_IDALBLL
	{
        #region Stadium
        #region Select Signatures
        List<StadiumDomainModel> ListStadiums();
        #endregion

        #region Insert Signatures
        StadiumDomainModel InsertStadium(StadiumDomainModel stadium);
        #endregion

        #region Update Signatures
        void UpdateStadium(StadiumDomainModel stadium);
        #endregion

        #region Delete Signature
        void DeleteStadium(StadiumDomainModel stadium);
        void ClearStadium(StadiumDomainModel stadium);
        #endregion


        #endregion

    }
}
