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

        public void DeleteSeasonPlayerAll(SeasonPlayerDomainModel _SeasonPlayer)
        {
            SPDAL.DeleteSeasonPlayerAll(_SeasonPlayer);
        }


        public List<SeasonPlayerDomainModel> ListSelectedPlayers(int SeasonID)
        {
            return SPDAL.ListSelectedPlayers(SeasonID);
        }

        public List<SeasonPlayerDomainModel> ListRemainingPlayers(int SeasonID)
        {
            return SPDAL.ListRemainingPlayers(SeasonID);
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
