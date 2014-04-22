using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class TeamBusinessLogicLayer: Team_IDALBLL
    {
        private TeamDAL dal = new TeamDAL();

        public List<TeamDomainModel> ListTeams()
        {
            return dal.ListTeams();
        }


        public TeamDomainModel InsertTeam(TeamDomainModel team)
        {
            return dal.InsertTeam(team);
        }


        public void  UpdateTeam(TeamDomainModel team)
        {
            dal.UpdateTeam(team);
        }

        public List<v_Team_Draft_RosterDomainModel> ListTeamRoster(int SeasonID, int TeamID)
        {
            return dal.ListTeamRoster(SeasonID, TeamID);
        }

    }
}
