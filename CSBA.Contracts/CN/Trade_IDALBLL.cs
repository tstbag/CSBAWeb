using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;


namespace CSBA.Contracts
{
    public interface Trade_IDALBLL
    {
        List<TradeDataDomainModel> ListTrades(TradeDomainModel Trade);
        TradeDomainModel InsertTrade(TradeDomainModel Trade);
        void UpdateTrade(TradeDomainModel Trade);
    }
}
