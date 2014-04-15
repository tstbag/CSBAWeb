using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Collections;
using System.Configuration;

namespace CSBA.DataAccessLayer
{
    public class CSBA_ADO_HelperFunctions
    {
        public DataSet GetStadiumTeamDraft(int SeasonID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["CSBAConnectionString"].ConnectionString;
            DataSet dataset = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.v_SeasonTeamStadiumDraft Where StadiumID is NULL and SeasonID = " + SeasonID + " order by StadiumOrder", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dataset);
                    }
                }
            }

            return dataset;
        }

        public DataSet GetTeam(string strUserID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["CSBAConnectionString"].ConnectionString;
            DataSet dataset = new DataSet();
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.GetTeamByUserID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", strUserID);
                    conn.Open();

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dataset);
                    }
                }
            }

            return dataset;
        }

        public DataSet GetStats(int SeasonID, int PlayerID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["CSBAConnectionString"].ConnectionString;
            DataSet dataset = new DataSet();
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.GetPlayerStats", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeasonID", SeasonID);
                    cmd.Parameters.AddWithValue("@PlayerID", PlayerID);
                    conn.Open();

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dataset);
                    }
                }
            }

            return dataset;
        }
    }
}
