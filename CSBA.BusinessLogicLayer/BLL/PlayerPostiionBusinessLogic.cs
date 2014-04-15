using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer 
{
    public class PlayerPostiionBusinessLogic : PlayerPosition_IDALBLL
    {
        PlayerPositionDAL DAL = new PlayerPositionDAL();

        public void DeletePlayerPosition(PlayerPositionDomainModel _playerPosition)
        {
            DAL.DeletePlayerPosition(_playerPosition);   
        }

        public void InsertPlayerPosition(PlayerPositionDomainModel _playerPosition)
        {
            DAL.InsertPlayerPosition(_playerPosition);
        }

        public void UpdatePlayerPosition(PlayerPositionDomainModel _playerPosition)
        {
            DAL.UpdatePlayerPosition(_playerPosition);
        }
    }
}
