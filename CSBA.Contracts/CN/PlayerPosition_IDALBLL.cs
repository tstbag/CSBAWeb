using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBA.Contracts
{
    public interface PlayerPosition_IDALBLL
    {
        void DeletePlayerPosition(CSBA.DomainModels.PlayerPositionDomainModel _playerPosition);
        void InsertPlayerPosition(CSBA.DomainModels.PlayerPositionDomainModel _playerPosition);
        void UpdatePlayerPosition(CSBA.DomainModels.PlayerPositionDomainModel _playerPosition);
    }
}
