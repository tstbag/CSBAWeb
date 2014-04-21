using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSBA.Contracts;
using CSBA.DomainModels;

namespace CSBA.DataAccessLayer
{
    public class StatDAL : Stat_IDALBLL
    {
        public StatDomainModel InsertStat(StatDomainModel stat)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var _cStat = new Stat
                {
                    StatName = stat.StatName,
                    PositionTypeID = stat.PositionTypeID
                };
                context.Stats.Add(_cStat);
                context.SaveChanges();

                // pass TeamID back to BLL
                stat.StatID = _cStat.StatID;

                return stat;
            }
        }
    }
}