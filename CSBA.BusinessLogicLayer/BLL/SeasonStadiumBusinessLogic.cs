using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;


namespace CSBA.BusinessLogicLayer
{
    public class SeasonStadiumBusinessLogic: SeasonStadium_IDALBLL
    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private SeasonStadiumDAL dal = new SeasonStadiumDAL();
        #endregion

        public List<SeasonStadiumDomainModel> ListStadiumsBySeason(int SeasonID, int AssignFlg)
        {
            return dal.ListStadiumsBySeason(SeasonID, AssignFlg);

        }


        public void AssignStadiumToSeason(int SeasonID, int StadiumID)
        {
            dal.AssignStadiumToSeason(SeasonID, StadiumID);
        }


        public List<SeasonStadiumDomainModel> AvailableStadiumsSeason(int SeasonID)
        {
            return dal.AvailableStadiumsSeason(SeasonID);
        }


        public void RestartStadiumDraft(int SeasonID)
        {
            dal.RestartStadiumDraft(SeasonID);
        }


        public List<SeasonStadiumDomainModel> ListSelectedStadiums(int SeasonID)
        {
            return dal.ListSelectedStadiums(SeasonID);
        }

        public List<SeasonStadiumDomainModel> ListRemainingStadiums(int SeasonID)
        {
            return dal.ListRemainingStadiums(SeasonID);
        }


        public void InsertSeasonStadium(SeasonStadiumDomainModel _SeasonStadium)
        {
            dal.InsertSeasonStadium(_SeasonStadium);
        }

        public void DeleteSeasonStadiumAll(SeasonStadiumDomainModel _SeasonStadium)
        {
            dal.DeleteSeasonStadiumAll(_SeasonStadium);
        }
    }
}
