using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class SeasonBusinessLogic:Season_IDALBLL
    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private SeasonDAL dal = new SeasonDAL();
        #endregion
        
        public List<SeasonDomainModel> ListSeasonID_Name()
        {
            return dal.ListSeasonID_Name();
        }

        public List<SeasonDomainModel> ListSeason()
        {
            return dal.ListSeason();
        }
        
        public List<SeasonDomainModel> ListSeasonView()
        {
            return dal.ListSeasonView();
        }


        public SeasonDomainModel InsertSeason(SeasonDomainModel season)
        {
            return dal.InsertSeason(season);
        }


        public void UpdateSeason(SeasonDomainModel season)
        {
            dal.UpdateSeason(season);
        }


        public void DeleteSeason(SeasonDomainModel season)
        {
            dal.DeleteSeason(season);
        }


        public void ClearSeason(SeasonDomainModel season)
        {
            dal.ClearSeason(season);
        }

        public void SelectCurrentSeason(SeasonDomainModel season)
        {
            dal.SelectCurrentSeason(season);
        }
        


    }
}
