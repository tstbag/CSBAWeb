using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DataAccessLayer;
using CSBA.DomainModels;

namespace CSBA.BusinessLogicLayer
{
    public class PositionTypeBusinessLogic: PositionType_IDALBLL
    {
        private PositionTypeDAL dal = new PositionTypeDAL();
        public List<DomainModels.PositionTypeDomanModel> ListPositionType()
        {
            return dal.ListPositionType();
        }

        public PositionTypeDomanModel InsertPositionType(PositionTypeDomanModel positionType)
        {
            return dal.InsertPositionType(positionType);
        }

        public void UpdatePositionType(PositionTypeDomanModel positionType)
        {
            dal.UpdatePositionType(positionType);
        }

        public void DeletePositionType(PositionTypeDomanModel positionType)
        {
            dal.DeletePositionType(positionType);
        }
    }
}
