using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class SeasonTeamBusinessLogic: SeasonTeam_IDALBLL
    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private SeasonTeamDAL dal = new SeasonTeamDAL();
        #endregion


        public List<SeasonTeamDomainModel> SeasonTeamOrder(int SeasonID)
        {
            return dal.SeasonTeamOrder(SeasonID);
        }


        public void MoveSeasonTeam(int SeasonID, int TeamID, int MoveDir)
        {
            //dal.MoveSeasonTeam(SeasonID, TeamID, MoveDir);
        }


        public List<SeasonTeamDomainModel> ListSelectedTeams(int SeasonID)
        {
            return dal.ListSelectedTeams(SeasonID);
        }

        public List<SeasonTeamDomainModel> ListRemainingTeams(int SeasonID)
        {
            return dal.ListRemainingTeams(SeasonID);
        }


        public void DeleteSeasonTeamAll(int SeasonID)
        {
            dal.DeleteSeasonTeamAll(SeasonID);
        }


        public void InsertSeasonTeam(SeasonTeamDomainModel _SeasonTeam)
        {
            dal.InsertSeasonTeam(_SeasonTeam);
        }
    }
}
