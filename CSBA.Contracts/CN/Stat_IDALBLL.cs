using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.DomainModels;

namespace CSBA.Contracts
{
    public interface Stat_IDALBLL
    {
        StatDomainModel InsertStat(StatDomainModel stat);
        
    }
}
