using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class SeasonPlayerDAL : SeasonPlayer_IDALBLL
    {


        public List<SeasonPlayerDomainModel> ListSelectedPlayers(int SeasonID)
        {
            List<SeasonPlayerDomainModel> list = new List<SeasonPlayerDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())

                list = (from result in context.sp_SeasonPlayerBySeason_Selected(SeasonID)
                        select new SeasonPlayerDomainModel
                        {
                            SeasonID = result.SeasonID,
                            PlayerGUID = result.PlayerGUID,
                            PlayerName = result.PlayerName

                        }).ToList();

            return list;
        }

        public List<SeasonPlayerDomainModel> ListRemainingPlayers(int SeasonID)
        {
            List<SeasonPlayerDomainModel> list = new List<SeasonPlayerDomainModel>();
            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())

                list = (from result in context.sp_SeasonPlayerBySeason_Remaining(SeasonID)
                        select new SeasonPlayerDomainModel
                        {
                            SeasonID = SeasonID,
                            PlayerGUID = result.PlayerGUID,
                            PlayerName = result.PlayerName

                        }).ToList();

            return list;
        }

        public void InsertSeasonPlayerRecycle(SeasonPlayerDomainModel _SeasonPlayer)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonPlayerRecycle_Insert {0}, {1}", _SeasonPlayer.SeasonID, _SeasonPlayer.PlayerGUID);

            }
        }        

        public void InsertSeasonPlayer(SeasonPlayerDomainModel _SeasonPlayer)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonPlayer_Insert {0}, {1}", _SeasonPlayer.SeasonID, _SeasonPlayer.PlayerGUID);

            }
        }

        public void DeleteSeasonPlayerAll(SeasonPlayerDomainModel _SeasonPlayer)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonPlayer_deleteAll {0}", _SeasonPlayer.SeasonID);

            }
        }

        public void DeleteSeasonRecyclePlayerAll(SeasonPlayerDomainModel _SeasonPlayer)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonPlayerRecycle_deleteAll {0}", _SeasonPlayer.SeasonID);

            }
        }        
    }
}
