using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface Player_IDALBLL
    {
        #region Player
        #region Select Signatures
        List<PlayerDomainModel> ListPlayers(string strLetter);
        PlayerDomainModel PlayerDetail(Guid? PlayerGUID);
        List<v_PlayerPositionDomainModel> ListPlayerPositions();    
        #endregion

        #region Update Signatures
        //int UpdateEmployee(PlayerDomainModel Player);
        void UpdatePlayer(PlayerDomainModel player); 
        #endregion

        #region Insert Signatuers
        PlayerDomainModel InsertPlayer(PlayerDomainModel player);
        #endregion

        #region Delete Sigantures
        void DeletePlayer(PlayerDomainModel player);
        #endregion
        #endregion


    }
}
