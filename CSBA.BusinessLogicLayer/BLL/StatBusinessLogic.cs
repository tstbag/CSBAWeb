using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;


namespace CSBA.BusinessLogicLayer
{
    public class StatBusinessLogic : Stat_IDALBLL
    {
        private StatDAL dal = new StatDAL();

        public StatDomainModel InsertStat(StatDomainModel stat)
        {
            return dal.InsertStat(stat);
        }

    }
}
