using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class TeamDAL : Team_IDALBLL
    {
        public List<TeamDomainModel> ListTeams()
        {
            //Create a return type Object
            List<TeamDomainModel> list = new List<TeamDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.sp_Team_Select(null)
                        select new TeamDomainModel
                        {
                            TeamID = result.TeamID,
                            TeamName = result.TeamName,
                            OwnerName = result.OwnerName,
                            OwnerEmail = result.OwnerEmail,
                            OwnerUserID = result.OwnerUserID,
                            TeamImage = result.TeamImage,
                            UserName = result.UserName
                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }
        #region Insert Region
        public TeamDomainModel InsertTeam(TeamDomainModel team)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cTeam = new Team
                {
                    TeamName = team.TeamName,
                    OwnerEmail = team.OwnerEmail,
                    OwnerUserID = team.OwnerUserID,
                    OwnerName = team.OwnerName,
                    TeamImage = team.TeamImage
                };
                context.Teams.Add(_cTeam);
                context.SaveChanges();

                // pass TeamID back to BLL
                team.TeamID = _cTeam.TeamID;

                return team;
            }

        }


        public List<v_Team_Draft_RosterDomainModel> ListTeamRoster(int SeasonID, int TeamID)
        {
            //Create a return type Object
            List<v_Team_Draft_RosterDomainModel> list = new List<v_Team_Draft_RosterDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.sp_Team_Roster_Select(SeasonID, TeamID)
                        select new v_Team_Draft_RosterDomainModel
                        {
                            ActiveFlg = result.ActiveFlg,
                            PlayerImage = result.PlayerImage,
                            PlayerName = result.PlayerName,
                            Points = result.Points,
                            PlayerGuid = result.PlayerGUID,
                            PrimPos = result.PrimPos,
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            SecPos = result.SecPos,
                            TeamID = result.TeamID,
                            TeamName = result.TeamName,
                            PrimaryPositionID = result.PrimaryPositionID,
                            PositionTypeDescr = result.PositionTypeDescr,
                            PositionTypeID = result.PositionTypeID
                        }).ToList();

            } // Guaranteed to close the Connection

            //return the list
            return list;
        }

        #endregion

        #region Update
        public void UpdateTeam(TeamDomainModel team)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cTeam = context.Teams.Find(team.TeamID);
                if (cTeam != null)
                {
                    cTeam.OwnerEmail = team.OwnerEmail;
                    cTeam.OwnerName = team.OwnerName;
                    cTeam.OwnerUserID = team.OwnerUserID;
                    cTeam.TeamName = team.TeamName;
                    cTeam.TeamImage = team.TeamImage;
                    context.SaveChanges();
                }
            }
        }
        #endregion

    }
}
