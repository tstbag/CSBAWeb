using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class SeasonTeamDAL : SeasonTeam_IDALBLL
    {
        public List<SeasonTeamDomainModel> SeasonTeamOrder(int SeasonID)
        {
            List<SeasonTeamDomainModel> list = new List<SeasonTeamDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())

                list = (from result in context.GetSeasonTeamOrder(SeasonID)
                        select new SeasonTeamDomainModel
                        {
                            ActiveFlg = result.ActiveFlg,
                            SeasonID = result.SeasonID,
                            SeasonName = result.SeasonName,
                            StadiumOrder = result.StadiumOrder,
                            TeamID = result.TeamID,
                            TeamName = result.TeamName,
                            MaxBid = result.MaxBid

                        }).ToList();

            return list;
        }

        public List<SeasonTeamDomainModel> ListSelectedTeams(int SeasonID)
        {
            List<SeasonTeamDomainModel> list = new List<SeasonTeamDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())

                list = (from result in context.sp_SeasonTeamBySeason_Selected(SeasonID)
                        orderby result.TeamName
                        select new SeasonTeamDomainModel
                        {
                            ActiveFlg = result.ActiveFlg,
                            SeasonID = result.SeasonID,
                            StadiumOrder = result.StadiumOrder,
                            TeamID = result.TeamID,
                            TeamName = result.TeamName
                        }).ToList();

            return list;
        }

        public List<SeasonTeamDomainModel> ListRemainingTeams(int SeasonID)
        {
            List<SeasonTeamDomainModel> list = new List<SeasonTeamDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAAzureEntities context = new CSBAAzureEntities())

                list = (from result in context.sp_SeasonTeamBySeason_Remaining(SeasonID)
                        select new SeasonTeamDomainModel
                        {
                            TeamID = result.TeamID,
                            TeamName = result.TeamName
                        }).ToList();

            return list;
        }

        public void InsertSeasonTeam(SeasonTeamDomainModel _SeasonTeam)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cSeasonTeam = new SeasonTeam
                {
                    SeasonID = _SeasonTeam.SeasonID,
                    TeamID = _SeasonTeam.TeamID,
                    ActiveFlg = _SeasonTeam.ActiveFlg,
                    StadiumOrder = _SeasonTeam.StadiumOrder

                };
                context.SeasonTeams.Add(cSeasonTeam);
                context.SaveChanges();

            }
        }


        public void DeleteSeasonTeamAll(int SeasonID)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonTeam_DeleteAll {0}", SeasonID);

            }
        }


    }
}
