using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer
{
    public class StadiumBusinessLogic: Stadium_IDALBLL
    {
        #region Private Fields
        //Create a DataAccess Object to call the Methods of the DAL
        private StadiumDAL dal = new StadiumDAL();
        #endregion

        public List<StadiumDomainModel> ListStadiums()
        {
            return dal.ListStadiums();
        }

        public StadiumDomainModel InsertStadium(StadiumDomainModel stadium)
        {
            return dal.InsertStadium(stadium);
        }


        public void UpdateStadium(StadiumDomainModel stadium)
        {
            dal.UpdateStadium(stadium);
        }

        public void DeleteStadium(StadiumDomainModel stadium)
        {
            dal.DeleteStadium(stadium);
        }


        public void ClearStadium(StadiumDomainModel stadium)
        {
            dal.ClearStadium(stadium);
        }
    }
}
