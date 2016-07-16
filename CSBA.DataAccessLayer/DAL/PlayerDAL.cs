using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class PlayerDAL : Player_IDALBLL
    {
        #region SelectMethods
        public List<PlayerDomainModel> ListPlayers(string strLetter)
        {
            //Create a return type Object
            List<PlayerDomainModel> list = new List<PlayerDomainModel>();
            //Create a Context object to Connect to the database

            if (strLetter != "%")
            {
                using (CSBAAzureEntities context = new CSBAAzureEntities())
                {
                    list = (from result in context.Players
                            where (result.PlayerName.StartsWith(strLetter))
                            select new PlayerDomainModel
                            {
                                PlayerGUID = result.PlayerGUID,
                                PlayerName = result.PlayerName,
                                PlayerImage = result.PlayerImage
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            else
            {
                using (CSBAAzureEntities context = new CSBAAzureEntities())
                {
                    list = (from result in context.Players
                            select new PlayerDomainModel
                            {
                                PlayerGUID = result.PlayerGUID,
                                PlayerName = result.PlayerName,
                                PlayerImage = result.PlayerImage
                            }).ToList();
                } // Guaranteed to close the Connection

            }

            //return the list
            return list;
        }

        public List<v_PlayerPositionDomainModel> ListPlayerPositionSeason(int SeasonID, int PositionID, bool bDrafted)
        {
            //Create a return type Object
            List<v_PlayerPositionDomainModel> list = new List<v_PlayerPositionDomainModel>();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.DraftPlayersStatus(SeasonID,PositionID, bDrafted)
                        select new v_PlayerPositionDomainModel
                        {
                            PlayerGUID = result.PlayerGUID,
                            PlayerImage = result.PlayerImage,
                            PlayerName = result.PlayerName,
                            PrimaryPositionID = result.PrimaryPositionID,

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;
        }


        public List<v_PlayerPositionDomainModel> ListDraftPlayers()
        {
            //Create a return type Object
            List<v_PlayerPositionDomainModel> list = new List<v_PlayerPositionDomainModel>();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                list = (from result in context.sp_PlayerPosition_Select(null)
                        select new v_PlayerPositionDomainModel
                        {
                            PlayerGUID = result.PlayerGUID,
                            PlayerImage = result.PlayerImage,
                            PlayerName = result.PlayerName,
                            PrimaryPositionID = result.PrimaryPositionID,
                            SecondaryPostiionID = result.SecondaryPostiionID,
                            PrimPosName = result.PrimPosName,
                            PrimPosNameLong = result.PrimPosNameLong,
                            SecPosName = result.SecPosName,
                            SecPosNameLong = result.SecPosNameLong                             

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;
        }
        #endregion


        public PlayerDomainModel PlayerDetail(Guid? PlayerGUID)
        {
            PlayerDomainModel player = new PlayerDomainModel();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                player = (from result in context.Players
                          where (result.PlayerGUID == PlayerGUID)
                          select new PlayerDomainModel
                          {
                              PlayerGUID = result.PlayerGUID,
                              PlayerName = result.PlayerName,
                              PlayerImage = result.PlayerImage
                          }).Single();
            } // Guaranteed to close the Connection

            return player;
        }


        public PlayerDomainModel InsertPlayer(PlayerDomainModel player)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cPlayer = new Player
                {
                    PlayerName = player.PlayerName,
                    PlayerImage = player.PlayerImage

                };
                context.Players.Add(_cPlayer);
                context.SaveChanges();

                // pass TeamID back to BLL
                player.PlayerGUID = _cPlayer.PlayerGUID;

                return player;
            }
        }


        public void UpdatePlayer(PlayerDomainModel player)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cPlayer = context.Players.Find(player.PlayerGUID);
                if (cPlayer != null)
                {
                    cPlayer.PlayerName = player.PlayerName;
                    cPlayer.PlayerImage = player.PlayerImage;
                    context.SaveChanges();
                }
            }
        }

        public void DeletePlayer(PlayerDomainModel player)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cPlayer = (from n in context.Players where n.PlayerGUID == player.PlayerGUID select n).FirstOrDefault();
                context.Players.Remove(cPlayer);
                context.SaveChanges();
            }
        }



    }
}
