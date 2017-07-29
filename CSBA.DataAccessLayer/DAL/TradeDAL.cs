using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.Contracts;

namespace CSBA.DataAccessLayer
{
    public class TradeDAL : Trade_IDALBLL
    {
        public List<TradeDataDomainModel> ListTrades(TradeDomainModel Trade)
        {
            //Create a return type Object
            List<TradeDataDomainModel> list = new List<TradeDataDomainModel>();

            ////Create a Context object to Connect to the database
            //using (CSBAAzureEntities context = new CSBAAzureEntities())
            //{
            //    list = (from result in context.sp_TradeData_Select(Trade.SeasonID, Trade.TradeGUID)
            //            select new TradeDataDomainModel
            //            {
            //                ActionDate = result.ActionDate,
            //                ProposedDate = result.ProposedDate,
            //                SeasonID = result.SeasonID,
            //                TeamID = result.TeamID,
            //                TradeGUID = result.TradeGUID,
            //                TradeStatusID = result.TradeStatusID,
            //                TeamName = result.TeamName,
            //                TradeStatusDesc = result.TradeStatusDesc
            //            }).ToList();

            //} // Guaranteed to close the Connection

            ////return the list
            return list;
        }

        #region Insert Region
        public TradeDomainModel InsertTrade(TradeDomainModel Trade)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var _cTrade = new Trade
                {
                    ActionDate = Trade.ActionDate,
                    ProposedDate = Trade.ProposedDate,
                    SeasonID = Trade.SeasonID,
                    TeamID = Trade.TeamID,
                    TradeStatusID = Trade.TradeStatusID
                };
                context.Trades.Add(_cTrade);
                context.SaveChanges();

                // pass TeamID back to BLL
                Trade.TradeGUID = _cTrade.TradeGUID;

                return Trade;
            }
        }
        #endregion

        #region Update Region

        public void UpdateTrade(TradeDomainModel Trade)
        {
            using (CSBAAzureEntities context = new CSBAAzureEntities())
            {
                var cTrade = context.Trades.Find(Trade.TradeGUID);
                if (cTrade != null)
                {
                    cTrade.ActionDate = Trade.ActionDate;
                    cTrade.ProposedDate = Trade.ProposedDate;
                    cTrade.SeasonID = Trade.SeasonID;
                    cTrade.TeamID = Trade.TeamID;
                    cTrade.TradeGUID = Trade.TradeGUID;
                    cTrade.TradeStatusID = Trade.TradeStatusID;

                    context.SaveChanges();
                }
            }
        #endregion
        }


    }
}
