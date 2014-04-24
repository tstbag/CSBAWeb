using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer

{
    public class TradeBusinessLogic : Trade_IDALBLL
    {
        TradeDAL DAL = new TradeDAL();
        
        public List<TradeDataDomainModel> ListTrades(TradeDomainModel Trade)
        {
            return DAL.ListTrades(Trade);
        }

        public TradeDomainModel InsertTrade(TradeDomainModel Trade)
        {
            return DAL.InsertTrade(Trade);
        }

        public void UpdateTrade(TradeDomainModel Trade)
        {
            DAL.UpdateTrade(Trade);
        }
    }
}
