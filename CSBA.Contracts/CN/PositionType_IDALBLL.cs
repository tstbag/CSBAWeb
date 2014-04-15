using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;


namespace CSBA.Contracts
{
    public interface PositionType_IDALBLL
    {
        List<PositionTypeDomanModel> ListPositionType();
        PositionTypeDomanModel InsertPositionType(PositionTypeDomanModel positionType);
        void UpdatePositionType(PositionTypeDomanModel positionType);
        void DeletePositionType(PositionTypeDomanModel positionType);

    }
}
