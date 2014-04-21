using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using CSBA.Contracts;
using CSBA.Contracts;
using CSBA.DomainModels;
using CSBA.DataAccessLayer;

namespace CSBA.BusinessLogicLayer 
{
    public class SeasonPlayerPositionStatBusinessLogic : SeasonPlayerPositionStat_IDALBLL
    {

        private SeasonPlayerPositionStatDAL dal = new SeasonPlayerPositionStatDAL();

        public DataTable GetDynamicStats(PickAPlayerDomainModel player)
        {
            return dal.GetDynamicStats(player);
        }
        public List<v_Stat_Hitter_ViewDomainModel> GetStats(PlayerDomainModel player)
        {
            return dal.GetStats(player);

        }
        public void InsertStatValue (SeasonPlayerPositionStatDomainModel statvalue)
        {
            dal.InsertStatValue(statvalue);
        }


        public void DeleteAllStatsForPlayer(SeasonPlayerPositionStatDomainModel statvalue)
        {
            dal.DeleteAllStatsForPlayer(statvalue);
        }
    }
}
