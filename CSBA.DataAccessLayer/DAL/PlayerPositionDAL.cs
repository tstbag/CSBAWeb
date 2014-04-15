using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class PlayerPositionDAL : PlayerPosition_IDALBLL
    {

        public void InsertPlayerPosition(PlayerPositionDomainModel _playerPosition)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var _cPlayerPosition = new PlayerPosition
                {
                    PlayerGUID = _playerPosition.PlayerGUID,
                    PrimaryPositionID = Convert.ToInt32(_playerPosition.PrimaryPositionID),
                    SecondaryPostiionID = _playerPosition.SecondaryPostiionID
                };
                context.PlayerPositions.Add(_cPlayerPosition);
                context.SaveChanges();
            }
        }


        public void UpdatePlayerPosition(PlayerPositionDomainModel _playerPosition)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var cplayerPosition = context.PlayerPositions.Find(_playerPosition.PlayerGUID);
                if (cplayerPosition != null)
                {
                    cplayerPosition.PlayerGUID = _playerPosition.PlayerGUID;
                    cplayerPosition.PrimaryPositionID = Convert.ToInt32(_playerPosition.PrimaryPositionID);
                    cplayerPosition.SecondaryPostiionID = _playerPosition.SecondaryPostiionID;
                    context.SaveChanges();
                }
                else
                {
                    InsertPlayerPosition(_playerPosition);
                }

            }
        }

        public void DeletePlayerPosition(PlayerPositionDomainModel _playerPosition)
        {

            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_PlayerPosition_Delete {0}", _playerPosition.PlayerGUID);

            }
        }

    }
}
