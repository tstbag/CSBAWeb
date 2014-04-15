using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;


namespace CSBA.Contracts
{
    public interface Position_IDALBLL
    {
        List<PositionDomainModel> ListPositions();
        PositionDomainModel InsertPosition(PositionDomainModel position);
        void UpdatePosition(PositionDomainModel position);
        void DeletePosition(PositionDomainModel position);
    }
}
