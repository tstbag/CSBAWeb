using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class SeasonTeamStadiumBusinessLogic : SeasonTeamStadium_IDALBLL
    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private SeasonTeamStadiumDAL dal = new SeasonTeamStadiumDAL();
        #endregion

        public List<SeasonTeamStadiumDomainModel> DraftStadium(int SeasonID)
        {
            return dal.DraftStadium(SeasonID);
        }


        public void AssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID)
        {
            //dal.AssignStadiumToTeam(SeasonID, StadiumID, TeamID);
        }


        public void UnAssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID)
        {
            //dal.UnAssignStadiumToTeam(SeasonID, StadiumID, TeamID);
        }
    }
}
