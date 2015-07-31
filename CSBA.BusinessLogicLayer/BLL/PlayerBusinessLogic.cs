using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer 
{
 
    public class PlayerBusinessLogic : Player_IDALBLL

    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private PlayerDAL dal = new PlayerDAL();
        #endregion

        #region Select Methods
        public List<PlayerDomainModel> ListPlayers(string strLetter)
        {
            return dal.ListPlayers(strLetter);

        }

        public List<v_PlayerPositionDomainModel> ListPlayerPositionSeason(int SeasonID, int PositionID, bool bDrafted)
        {
            return dal.ListPlayerPositionSeason(SeasonID, PositionID, bDrafted);

        }

        public PlayerDomainModel PlayerDetail(Guid? PlayerGUID)
        {
            return dal.PlayerDetail(PlayerGUID);
        }

        public List<v_PlayerPositionDomainModel> ListDraftPlayers()
        {
            return dal.ListDraftPlayers();
        }
        #endregion

        public void UpdatePlayer(PlayerDomainModel player)
        {
            dal.UpdatePlayer(player);
        }

        public PlayerDomainModel InsertPlayer(PlayerDomainModel player)
        {
            return dal.InsertPlayer(player);
        }


        public void DeletePlayer(PlayerDomainModel player)
        {
            dal.DeletePlayer(player);
        }
    }
}
