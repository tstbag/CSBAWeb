using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class SeasonStadiumDAL : SeasonStadium_IDALBLL
    {

        public List<SeasonStadiumDomainModel> ListStadiumsBySeason(int SeasonID, int AssignFlg)
        {
            return null;

            //List<SeasonStadiumDomainModel> list = new List<SeasonStadiumDomainModel>();
            ////Create a Context object to Connect to the database
            //using (CSBAEntities context = new CSBAEntities())

            //    #region With EF
            //    list = (from result in context.GetStadiumBySeason(SeasonID, AssignFlg)
            //            select new SeasonStadiumDomainModel
            //        {
            //            StadiumID = Convert.ToInt32(result.StadiumID),
            //            SeasonID = Convert.ToInt32(result.SeasonID),
            //            SeasonName = result.SeasonName,
            //            StadiumURL = result.StadiumURL,
            //            StadiumName = result.StadiumName

            //        }).ToList();
            //    #endregion

            //return list;

        }

        public List<SeasonStadiumDomainModel> AvailableStadiumsSeason(int SeasonID)
        {
            return null;
            //List<SeasonStadiumDomainModel> list = new List<SeasonStadiumDomainModel>();
            ////Create a Context object to Connect to the database
            //using (CSBAEntities context = new CSBAEntities())

            //    #region With EF
            //    list = (from result in context.AvailableStadiums(SeasonID)
            //            select new SeasonStadiumDomainModel
            //            {
            //                StadiumID = Convert.ToInt32(result.StadiumID),
            //                SeasonID = Convert.ToInt32(result.SeasonID),
            //                SeasonName = result.SeasonName,
            //                StadiumURL = result.StadiumURL,
            //                StadiumName = result.StadiumName

            //            }).ToList();
            //    #endregion

            //return list;

        }


        public void AssignStadiumToSeason(int SeasonID, int StadiumID)
        {

            


            //using (CSBAEntities context = new CSBAEntities())
            //{
            //    context.AssignStadiumToSeason(SeasonID, StadiumID);
            //}
        }

        public void RestartStadiumDraft(int SeasonID)
        {
            //using (CSBAEntities context = new CSBAEntities())
            //{
            //    context.StartStadiumDraft(SeasonID);
            //}
        }

        public List<SeasonStadiumDomainModel> ListSelectedStadiums(int SeasonID)
        {
            List<SeasonStadiumDomainModel> list = new List<SeasonStadiumDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())

                list = (from result in context.sp_SeasonStadiumBySeason_Selected(SeasonID)
                        select new SeasonStadiumDomainModel
                        {
                             StadiumID = result.StadiumID,
                             StadiumName = result.StadiumName
                        }).ToList();

            return list;
        }

        public List<SeasonStadiumDomainModel> ListRemainingStadiums(int SeasonID)
        {
            List<SeasonStadiumDomainModel> list = new List<SeasonStadiumDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())

                list = (from result in context.sp_SeasonStadiumBySeason_Remaining(SeasonID)
                        select new SeasonStadiumDomainModel
                        {
                             StadiumID = result.StadiumID,
                             StadiumName = result.StadiumName
                        }).ToList();

            return list;
        }

        public void InsertSeasonStadium(SeasonStadiumDomainModel _SeasonStadium)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonStadium_Insert {0}, {1}", _SeasonStadium.SeasonID, _SeasonStadium.StadiumID);

            }
        }

        public void DeleteSeasonStadiumAll(SeasonStadiumDomainModel _SeasonStadium)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonStadium_DeleteAll {0}", _SeasonStadium.SeasonID);

            }
        }
    }
}
