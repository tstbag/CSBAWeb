using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class DraftPlayerDAL : DraftPlayerIDALBLL
    {

        public List<sp_SeasonTeamDraft_Select_ResultDomainModel> DraftTeamList(int SeasonID)
        {
            List<sp_SeasonTeamDraft_Select_ResultDomainModel> listTeams = new List<sp_SeasonTeamDraft_Select_ResultDomainModel>();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                listTeams = (from result in context.sp_SeasonTeamDraft_Select(SeasonID)
                             select new sp_SeasonTeamDraft_Select_ResultDomainModel
                                {
                                    CountHitter = result.CountHitter,
                                    CountPlayers = result.CountPlayers,
                                    MaxBid = result.MaxBid,
                                    MinBid = result.MinBid,
                                    OwnerEmail = result.OwnerEmail,
                                    OwnerName = result.OwnerName,
                                    OwnerUserID = result.OwnerUserID,
                                    PitcherCount = result.PitcherCount,
                                    SeasonID = result.SeasonID,
                                    StartPoints = result.StartPoints,
                                    SumPoints = result.SumPoints,
                                    TeamID = result.TeamID,
                                    TeamName = result.TeamName
                                }).ToList();
            } // Guaranteed to close the Connection

            return listTeams;
        }

        public List<DraftPlayerDomainModel> DraftPositionStatus(int SeasonID, int iDrafted)
        {
            List<DraftPlayerDomainModel> listPos = new List<DraftPlayerDomainModel>();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                listPos = (from result in context.DraftPositionStatus(SeasonID) where result.Drafted == iDrafted 
                             select new DraftPlayerDomainModel
                             {
                                 Drafted = result.Drafted,
                                 PosCount = (int)result.PosCount,
                                 PositionName = result.PositionName,
                                 SeasonID = result.SeasonID
                             }).ToList();
            } // Guaranteed to close the Connection

            return listPos;
        }

        public DraftStatusDomainModel DraftStatus(int SeasonID)
        {
            DraftStatusDomainModel dStatus = new DraftStatusDomainModel();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                dStatus = (from result in context.DraftPlayerStatus(SeasonID)
                           select new DraftStatusDomainModel
                             {
                                 SeaonPlayerTotal = result.SeaonPlayerTotal,
                                 SeasonPlayerDrafted = result.SeasonPlayerDrafted
                             }).FirstOrDefault();
            } // Guaranteed to close the Connection

            return dStatus;
        }

        public PickAPlayerDomainModel PickAPLayer(int SeasonID)
        {
            PickAPlayerDomainModel PickPlayer = new PickAPlayerDomainModel();

            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                PickPlayer = (from result in context.PickAPlayer(SeasonID)
                              select new PickAPlayerDomainModel
                              {
                                  PlayerGUID = result.PlayerGUID,
                                  PlayerImage = result.PlayerImage,
                                  PlayerName = result.PlayerName,
                                  PrimPositionTypeID = result.PrimPositionTypeID,
                                  PrimPositionName = result.PrimPositionName,
                                  PrimPositionTypeDescr = result.PrimPositionTypeDescr,
                                  SecPositionName = result.SecPositionName,
                                  SecPositionTypeDescr = result.SecPositionTypeDescr

                              }).FirstOrDefault();
            } // Guaranteed to close the Connection

            return PickPlayer;
        }

        public void DraftPlayer(SeasonTeamPlayerDomainModel STP)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cSTP = new SeasonTeamPlayer
                {
                    PlayerGUID = STP.PlayerGUID,
                    SeasonID = STP.SeasonID,
                    TeamID = STP.TeamID,
                    Points = STP.Points

                };
                context.SeasonTeamPlayers.Add(_cSTP);
                context.SaveChanges();
            }
        }

        #region Update
        public void TradePlayer(SeasonTeamPlayerDomainModel STP, int NewTeamID, int Points)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                context.Database.ExecuteSqlCommand("sp_Team_Roster_Update {0}, {1}, {2}, {3}, {4}", STP.SeasonID, STP.PlayerGUID, STP.TeamID, NewTeamID, Points);
            }
        }
        #endregion


    }
}
