//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data.Objects;
//using CSBA.Contracts;
//using CSBA.DomainModels;
//namespace CSBA.DataAccessLayer
//{
//    public class StatDAL: Stat_IDALBLL
//    {
//        public List<StatDomainModel> ListStats(string strLetter)
//        {
//            //Create a return type Object
//            List<StatDomainModel> list = new List<StatDomainModel>();

//            //Create a Context object to Connect to the database
//            if (strLetter != "%")
//            {

//                using (CSBAEntities context = new CSBAEntities())
//                {
//                    list = (from result in context.Stats
//                            where (result.StatFullName.StartsWith(strLetter))
//                            select new StatDomainModel
//                            {
//                                StatFullName = result.StatFullName,
//                                StatID = result.StatID,
//                                StatName = result.StatName,
//                                PositionTypeID = result.PositionTypeID
//                            }).ToList();

//                } // Guaranteed to close the Connection

//            }
//            else
//            {
//                using (CSBAEntities context = new CSBAEntities())
//                {
//                    list = (from result in context.Stats
//                            select new StatDomainModel
//                            {
//                                StatFullName = result.StatFullName,
//                                StatID = result.StatID,
//                                StatName = result.StatName,
//                                PositionTypeID = result.PositionTypeID
//                            }).ToList();

//                } // Guaranteed to close the Connection
//            }


//            //return the list
//            return list;
//        }

//        public List<StatDomainModel> ListStatsPosition(string strLetter, int PositionTypeID)
//        {
//            //Create a return type Object
//            List<StatDomainModel> list = new List<StatDomainModel>();

//            //Create a Context object to Connect to the database
//            if (strLetter != "%")
//            {

//                using (CSBAEntities context = new CSBAEntities())
//                {
//                    list = (from result in context.Stat_List(PositionTypeID)
//                            where (result.StatFullName.StartsWith(strLetter))
//                            select new StatDomainModel
//                            {
//                                StatFullName = result.StatFullName,
//                                StatID = result.StatID,
//                                StatName = result.StatName,
//                                PositionTypeID = result.PositionTypeID,
//                                PositionType = result.PositionType

//                            }).ToList();

//                } // Guaranteed to close the Connection

//            }
//            else
//            {
//                using (CSBAEntities context = new CSBAEntities())
//                {
//                    list = (from result in context.Stat_List(PositionTypeID)
//                            select new StatDomainModel
//                            {
//                                StatFullName = result.StatFullName,
//                                StatID = result.StatID,
//                                StatName = result.StatName,
//                                PositionTypeID = result.PositionTypeID,
//                                PositionType = result.PositionType
//                            }).ToList();

//                } // Guaranteed to close the Connection
//            }
//            //return the list
//            return list;
//        }

//        public int InsertStat(StatDomainModel stat)
//        {
//            int rowsAffected = 0;

//            ObjectParameter oStatID = new ObjectParameter("StatID", typeof(Int32));

//            using (CSBAEntities context = new CSBAEntities())
//            {
//                context.Stat_Create(oStatID, stat.StatName,stat.StatFullName, stat.PositionTypeID);
//            }
//            return rowsAffected;

//        }

//        public int UpdatePlayer(StatDomainModel stat)
//        {
//            int rowsAffected = 0;
//            using (CSBAEntities context = new CSBAEntities())
//            {
//                rowsAffected = context.Stat_Update(stat.StatID,stat.StatName,stat.StatFullName, stat.PositionTypeID);
//            }
//            return rowsAffected;
//        }
//    }
//}
