using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface SeasonPlayerPositionStat_IDALBLL
    {
        void DeleteAllStatsForPlayer(SeasonPlayerPositionStatDomainModel statvalue);
        void InsertStatValue(SeasonPlayerPositionStatDomainModel statvalue);

    }
}
