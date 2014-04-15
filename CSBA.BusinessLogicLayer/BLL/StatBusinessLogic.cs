//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CSBA.Contracts;
//using CSBA.DomainModels;
//using CSBA.DataAccessLayer;


//namespace CSBA.BusinessLogicLayer
//{
//    public class StatBusinessLogic: Stat_IDALBLL
//    {
//        private StatDAL dal = new StatDAL();
//        public List<StatDomainModel> ListStats(string strLetter)
//        {
//            return dal.ListStats(strLetter); 
//        }


//        public int InsertStat(StatDomainModel stat)
//        {
//            return dal.InsertStat(stat);
//        }

//        public int UpdatePlayer(StatDomainModel stat)
//        {
//            return dal.UpdatePlayer(stat);
//        }


//        public List<StatDomainModel> ListStatsPosition(string strLetter, int PositionTypeID)
//        {
//            return dal.ListStatsPosition(strLetter, PositionTypeID);
//        }
//    }
//}
