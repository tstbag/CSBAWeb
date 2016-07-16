using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class SeasonTeamStadiumDAL: SeasonTeamStadium_IDALBLL
    {
        public List<SeasonTeamStadiumDomainModel> DraftStadium(int SeasonID)
        {
            return null;
            //List<SeasonTeamStadiumDomainModel> list = new List<SeasonTeamStadiumDomainModel>();
            ////Create a Context object to Connect to the database
            //using (CSBAAzureEntities context = new CSBAAzureEntities())

            //    #region With EF
            //    list = (from result in context.GetSeasonTeamStadiumDraft(SeasonID)
            //            select new SeasonTeamStadiumDomainModel
            //            {
            //                StadiumID = Convert.ToInt32(result.StadiumID),
            //                SeasonID = Convert.ToInt32(result.SeasonID),
            //                StadiumURL = result.StadiumURL,
            //                StadiumName = result.StadiumName,
            //                StadiumOrder = result.StadiumOrder,
            //                TeamID = result.TeamID,
            //                TeamName = result.TeamName,
            //                Active = result.Active,
            //                CreateTS = result.CreateTS,
            //                CreateUser = result.CreateUser,
            //                UpdateTS = result.UpdateTS,
            //                UpdateUser = result.UpdateUser

            //            }).ToList();
            //    #endregion

            //return list;

        }

        //public void AssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID)
        //{

        //    #region Insert With Linked to Entity


        //    using (CSBAAzureEntities context = new CSBAAzureEntities())
        //    {
        //        context.AssignStadiumToTeam(SeasonID, StadiumID, TeamID);
        //    }


        //    #endregion
        //}
        //public void UnAssignStadiumToTeam(int SeasonID, int StadiumID, int TeamID)
        //{

        //    #region Insert With Linked to Entity
        //    using (CSBAAzureEntities context = new CSBAAzureEntities())
        //    {
        //        context.UnAssignStadiumToTeam(SeasonID, StadiumID, TeamID);
        //    }


        //    #endregion
        //}
    }
}
