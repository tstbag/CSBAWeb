using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface Stat_IDALBLL
    {
        List<StatDomainModel> ListStats(string strLetter);
        List<StatDomainModel> ListStatsPosition(string strLetter, int PositionTypeID);
        int InsertStat(StatDomainModel stat);
        int UpdatePlayer(StatDomainModel stat);
        
    }
}
