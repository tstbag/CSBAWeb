using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;
using CSBA.Contracts;
using CSBA.DataAccessLayer;


namespace CSBA.BusinessLogicLayer
{
    public class PositionBusinessLogic : Position_IDALBLL
    {
        PositionDAL DAL = new PositionDAL();
        
        public PositionDomainModel InsertPosition(PositionDomainModel position)
        {
            return DAL.InsertPosition(position); 
        }

        public void UpdatePosition(PositionDomainModel position)
        {
            DAL.UpdatePosition(position);
        }

        public void DeletePosition(PositionDomainModel position)
        {
            DAL.DeletePosition(position);
        }

        public List<PositionDomainModel> ListPositions()
        {
            return DAL.ListPositions();
        }
    }
}
