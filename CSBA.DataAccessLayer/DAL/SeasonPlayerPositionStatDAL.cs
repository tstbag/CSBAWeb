using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CSBA.Contracts;
using CSBA.DomainModels;


namespace CSBA.DataAccessLayer
{
    public class SeasonPlayerPositionStatDAL : SeasonPlayerPositionStat_IDALBLL
    {

        public DataTable GetDynamicStats(PickAPlayerDomainModel player)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CSBAConn"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();


            cmd.CommandText = "dbo.sp_Stat_Dynamic_Select";
            cmd.Parameters.Add("@PlayerGUID", SqlDbType.UniqueIdentifier).Value = player.PlayerGUID;
            cmd.Parameters.Add("@PositionTypeID", SqlDbType.Int).Value = player.PrimPositionTypeID;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            adp.Fill(ds);
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();

            return ds.Tables[0];
        }

        public List<v_Stat_Hitter_ViewDomainModel> GetStats(PlayerDomainModel player)
        {
            //Create a return type Object
            List<v_Stat_Hitter_ViewDomainModel> list = new List<v_Stat_Hitter_ViewDomainModel>();

            //Create a Context object to Connect to the database
            using (CSBAEntities context = new CSBAEntities())
            {
                list = (from result in context.v_Stat_Hitter_View
                        select new v_Stat_Hitter_ViewDomainModel
                        {
                            AB = result.AB,
                            Agility = result.Agility,
                            AVG = result.AVG,
                            BB = result.BB,
                            CS = result.CS,
                            Doubles = result.Doubles,
                            EBH = result.EBH,
                            FLDP1 = result.FLDP1,
                            FLDP2 = result.FLDP2,
                            Hits = result.Hits,
                            HP = result.HP,
                            HR = result.HR,
                            Ks = result.Ks,
                            OBA = result.OBA,
                            PlayerGUID = result.PlayerGUID,
                            PlayerName = result.PlayerName,
                            Rangep1 = result.Rangep1,
                            RangeP2 = result.RangeP2,
                            RBI = result.RBI,
                            RN = result.RN,
                            Runs = result.Runs,
                            SB = result.SB,
                            SeasonName = result.SeasonName,
                            SLG = result.SLG,
                            TB = result.TB,
                            Triples = result.Triples
                        }).ToList();
            } // Guaranteed to close the Connection
            //return the list
            return list;
        }


        public void DeleteAllStatsForPlayer(SeasonPlayerPositionStatDomainModel statvalue)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                context.Database.ExecuteSqlCommand("sp_SeasonPlayerPositionStat_DeleteAll {0}, {1}", statvalue.SeasonID, statvalue.PlayerGUID);
            }
        }

        public void InsertStatValue(SeasonPlayerPositionStatDomainModel statvalue)
        {
            using (CSBAEntities context = new CSBAEntities())
            {
                var _cStatVal = new SeasonPlayerPositionStat
                {
                    SeasonID = statvalue.SeasonID,
                    PlayerGUID = statvalue.PlayerGUID,
                    PositionID = statvalue.PositionID,
                    StatID = statvalue.StatID,
                    StatValue = statvalue.StatValue
                };
                context.SeasonPlayerPositionStats.Add(_cStatVal);
                context.SaveChanges();
            }
        }
    }
}
