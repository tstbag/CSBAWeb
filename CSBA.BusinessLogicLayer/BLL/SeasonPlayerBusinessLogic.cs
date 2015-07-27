using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class SeasonPlayerBusinessLogic: SeasonPlayer_IDALBLL
    {
        SeasonPlayerDAL SPDAL = new SeasonPlayerDAL();

        public void InsertSeasonPlayer(SeasonPlayerDomainModel _SeasonPlayer)
        {
            SPDAL.InsertSeasonPlayer(_SeasonPlayer);
        }

        public void DeleteSeasonPlayerAll(SeasonPlayerDomainModel _SeasonPlayer, PositionDomainModel _Position)
        {
            SPDAL.DeleteSeasonPlayerAll(_SeasonPlayer, _Position);
        }


        public List<SeasonPlayerDomainModel> ListSelectedPlayers(int SeasonID, int PositionID)
        {
            return SPDAL.ListSelectedPlayers(SeasonID, PositionID);
        }

        public List<SeasonPlayerDomainModel> ListRemainingPlayers(int SeasonID, int PositionID)
        {
            return SPDAL.ListRemainingPlayers(SeasonID, PositionID);
        }


        public void InsertSeasonPlayerRecycle(SeasonPlayerDomainModel _SeasonPlayer)
        {
            SPDAL.InsertSeasonPlayerRecycle(_SeasonPlayer);
        }

        public void DeleteSeasonRecyclePlayerAll(SeasonPlayerDomainModel _SeasonPlayer)
        {
            SPDAL.DeleteSeasonRecyclePlayerAll(_SeasonPlayer);
        }
    }
}
