using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSBA.BusinessLogicLayer;
using CSBA.DomainModels;
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;

namespace CSBA.ImportData
{
    public class cImportData
    {
        const string CWorkbook = "C:\\Users\\Dad\\Source\\Repos\\CSBAWeb\\CSBA.ImportData\\ImportData\\StatList.xls";

        static void Main(string[] args)
        {
            //GetStatView();
            ImportExcelPitchers();
            //ImportExcelBatters();        }
        }
        protected static void GetStatView()
        {

            SeasonPlayerPositionStatBusinessLogic sppsBLL = new SeasonPlayerPositionStatBusinessLogic();
            PickAPlayerDomainModel player = new PickAPlayerDomainModel();
            player.PlayerGUID = new Guid("427D3393-3232-4E29-BAF2-18650072C736");

            DataTable dt = sppsBLL.GetDynamicStats(player);
           
        }

        public static void ImportExcelBatters()
        {
            {
                List<clsHitter> colHitters = new List<clsHitter>();

                Excel.Application myApp = new Excel.Application();

                Excel.Workbook workbook = myApp.Workbooks.Open(CWorkbook,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing);

                Excel.Worksheet sheet = workbook.Sheets["Batters"];
                Excel.Range range = sheet.UsedRange;
                int rows_count = range.Rows.Count;
                int cols_count = range.Columns.Count;

                rows_count = 113;

                //string output = null;

                for (int i = 2; i <= rows_count; i++)
                {
                    var cHitter = new clsHitter();

                    for (int j = 1; j <= cols_count; j++)
                    {
                        if (sheet.Cells[1, j].value != null)
                        {
                            string ColumnName = sheet.Cells[1, j].value;
                            switch (ColumnName.ToUpper())
                            {
                                case "FIRSTNAME":
                                    {
                                        cHitter.FirstName = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "LASTNAME":
                                    {
                                        cHitter.LastName = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "PT":
                                    {
                                        cHitter.Points = Convert.ToInt16(sheet.Cells[i, j].value);
                                        break;
                                    }
                                case "B":
                                    {
                                        cHitter.Bats = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "P1":
                                    {
                                        cHitter.Pos1 = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "RANGEP1":
                                    {
                                        cHitter.Rangep1 = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "FLDP1":
                                    {
                                        double? dValue = sheet.Cells[i, j].value;
                                        cHitter.FLDP1 = dValue;
                                        break;
                                    }

                                case "P2":
                                    {
                                        cHitter.Pos2 = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "RANGEP2":
                                    {
                                        cHitter.RangeP2 = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "FLDP2":
                                    {
                                        double? dValue = sheet.Cells[i, j].value;
                                        cHitter.FLDP2 = dValue;
                                        break;
                                    }
                                case "A":
                                    {
                                        cHitter.Agility = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "RN":
                                    {
                                        cHitter.RN = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "AVG":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 3, MidpointRounding.AwayFromZero);
                                        cHitter.AVG = dValue;
                                        break;
                                    }
                                case "OBA":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value,3, MidpointRounding.AwayFromZero);
                                        cHitter.OBA = dValue;
                                        break;
                                    }
                                case "SLG":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 3, MidpointRounding.AwayFromZero);
                                        cHitter.SLG = dValue;
                                        break;
                                    }
                                case "AB":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.AB = IValue;
                                        break;
                                    }
                                case "H":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.Hits = IValue;
                                        break;
                                    }
                                case "2B":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.Doubles = IValue;
                                        break;
                                    }
                                case "3B":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.Triples = IValue;
                                        break;
                                    }
                                case "HR":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.HR = IValue;
                                        break;
                                    }
                                case "R":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.Runs = IValue;
                                        break;
                                    }
                                case "RBI":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.RBI = IValue;
                                        break;
                                    }
                                case "HP":
                                    {
                                        int? IValue = Convert.ToInt32((sheet.Cells[i, j].value));
                                        cHitter.HP = IValue;
                                        break;
                                    }
                                case "BB":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.BB = IValue;
                                        break;
                                    }
                                case "K":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.Ks = IValue;
                                        break;
                                    }
                                case "SB":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.SB = IValue;
                                        break;
                                    }
                                case "CS":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.CS = IValue;
                                        break;
                                    }
                                case "TB":
                                    {
                                        int? IValue = Convert.ToInt32(Math.Round(sheet.Cells[i, j].value, 0, MidpointRounding.AwayFromZero));
                                        cHitter.TB = IValue;
                                        break;
                                    }
                                case "EBH":
                                    {
                                        int? IValue = Convert.ToInt32(sheet.Cells[i, j].value);
                                        cHitter.EBH = IValue;
                                        break;
                                    }
                            }
                        }


                    }
                    //  Batter object is set up
                    //HandleBatter(cHitter);
                    colHitters.Add(cHitter);

                }

                //workbook.Save();
                HandleBatter(colHitters);
                workbook.Close();
            }
        }



        public static void HandleBatter(List<clsHitter> colHitter)
        {
            PlayerBusinessLogic pBLL = new PlayerBusinessLogic();
            PlayerDomainModel player = new PlayerDomainModel();

            PlayerPostiionBusinessLogic ppBLL = new PlayerPostiionBusinessLogic();
            PlayerPositionDomainModel playerposition = new PlayerPositionDomainModel();

            StatBusinessLogic sBLL = new StatBusinessLogic();
            StatDomainModel stat = new StatDomainModel();

            SeasonPlayerPositionStatBusinessLogic sppsBLL = new SeasonPlayerPositionStatBusinessLogic();
            SeasonPlayerPositionStatDomainModel statValue = new SeasonPlayerPositionStatDomainModel();

            statValue.SeasonID = 23;
            statValue.PlayerGUID = player.PlayerGUID;
            sppsBLL.DeleteAllStatsForPlayer(statValue);

            foreach (clsHitter cHitter in colHitter)
            {
                player.PlayerName = cHitter.FirstName.Trim() + " " + cHitter.LastName.Trim();
                pBLL.InsertPlayer(player);

                playerposition.PlayerGUID = player.PlayerGUID;
                playerposition.PrimaryPositionID = TransformPos(cHitter.Pos1);
                playerposition.SecondaryPostiionID = TransformPos(cHitter.Pos2);
                ppBLL.DeletePlayerPosition(playerposition);
                ppBLL.InsertPlayerPosition(playerposition);


                BindingFlags flags = BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.NonPublic;


                foreach (FieldInfo f in cHitter.GetType().GetFields(flags))
                {
                    Console.WriteLine("{0} = {1}", f.Name, f.GetValue(cHitter));
                    System.Diagnostics.Debug.WriteLine("{0} = {1}", f.Name, f.GetValue(cHitter));
                    string fieldName = _getBackingFieldName(f.Name.ToUpper());


                    if (fieldName != "FIRSTNAME" &&
                        fieldName != "LASTNAME" &&
                        fieldName != "POINTS" &&
                        fieldName != "BATS" &&
                        fieldName != "POS1" &&
                        fieldName != "POS2")
                    {
                        stat.StatName = fieldName;
                        stat.PositionTypeID = 1;    // 1 = hitter
                        stat = sBLL.InsertStat(stat);
                        
                        statValue.SeasonID = 23;
                        statValue.PlayerGUID = player.PlayerGUID;
                        statValue.PositionID = TransformPos(cHitter.Pos1);
                        statValue.StatID = stat.StatID;
                        if (f.GetValue(cHitter) == null)
                        {
                            statValue.StatValue = null;
                        }
                        else
                        {
                            statValue.StatValue = f.GetValue(cHitter).ToString();
                        }

                        sppsBLL.InsertStatValue(statValue);
                    }
                }
            }
        }

        public static void ImportExcelPitchers()
        {
            {
                List<clsPitcher> colPitchers = new List<clsPitcher>();

                Excel.Application myApp = new Excel.Application();

                Excel.Workbook workbook = myApp.Workbooks.Open(CWorkbook,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing);

                Excel.Worksheet sheet = workbook.Sheets["Pitchers"];
                Excel.Range range = sheet.UsedRange;
                int rows_count = range.Rows.Count;
                int cols_count = range.Columns.Count;

                rows_count = 105;

                for (int i = 2; i <= rows_count; i++)
                {
                    var cPitcher = new clsPitcher();

                    for (int j = 1; j <= cols_count; j++)
                    {
                        if (sheet.Cells[1, j].value != null)
                        {
                            string ColumnName = sheet.Cells[1, j].value;
                            switch (ColumnName.ToUpper())
                            {
                                case "FIRSTNAME":
                                    {
                                        cPitcher.FirstName = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "LASTNAME":
                                    {
                                        cPitcher.LastName = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "PT":
                                    {
                                        cPitcher.PT = Convert.ToInt16(sheet.Cells[i, j].value);
                                        break;
                                    }
                                case "T":
                                    {
                                        cPitcher.T = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "P":
                                    {
                                        cPitcher.Pos = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "D":
                                    {
                                        cPitcher.D = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "ERA":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 3, MidpointRounding.AwayFromZero);
                                        cPitcher.ERA = dValue;
                                        break;
                                    }

                                case "W":
                                    {
                                        cPitcher.W = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "L":
                                    {
                                        cPitcher.L = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "S":
                                    {
                                        cPitcher.S = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "G":
                                    {
                                        cPitcher.G = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "GS":
                                    {
                                        cPitcher.GS = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "CG":
                                    {
                                        cPitcher.CG = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "SH":
                                    {
                                        cPitcher.SH = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "IP":
                                    {
                                        cPitcher.IP = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "H":
                                    {
                                        cPitcher.H = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "R":
                                    {
                                        cPitcher.R = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "ER":
                                    {
                                        cPitcher.ER = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "BB":
                                    {
                                        cPitcher.BB = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "K":
                                    {
                                        cPitcher.K = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "HR":
                                    {
                                        cPitcher.HR = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "DP":
                                    {
                                        cPitcher.DP = (int)sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "IP/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.IP_9 = dValue;
                                        break;
                                    }
                                case "H/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.H_9 = dValue;
                                        break;
                                    }
                                case "W/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.W_9 = dValue;
                                        break;
                                    }
                                case "HR/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.HR_9 = dValue;
                                        break;
                                    }
                                case "K/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.K_9 = dValue;
                                        break;
                                    }
                                case "HW/9":
                                    {
                                        double? dValue = Math.Round(sheet.Cells[i, j].value, 2, MidpointRounding.AwayFromZero);
                                        cPitcher.HW_9 = dValue;
                                        break;
                                    }

                            }
                        }


                    }
                    //  Batter object is set up
                    colPitchers.Add(cPitcher);

                }

                HandlePitcher(colPitchers);
                workbook.Close();

            }
            
        }

        public static void HandlePitcher(List<clsPitcher> colPitchers)
        {
            PlayerBusinessLogic pBLL = new PlayerBusinessLogic();
            PlayerDomainModel player = new PlayerDomainModel();

            PlayerPostiionBusinessLogic ppBLL = new PlayerPostiionBusinessLogic();
            PlayerPositionDomainModel playerposition = new PlayerPositionDomainModel();

            StatBusinessLogic sBLL = new StatBusinessLogic();
            StatDomainModel stat = new StatDomainModel();

            SeasonPlayerPositionStatBusinessLogic sppsBLL = new SeasonPlayerPositionStatBusinessLogic();
            SeasonPlayerPositionStatDomainModel statValue = new SeasonPlayerPositionStatDomainModel();

            statValue.SeasonID = 23;
            statValue.PlayerGUID = player.PlayerGUID;
            sppsBLL.DeleteAllStatsForPlayer(statValue);

            foreach (clsPitcher cPitcher in colPitchers)
            {
                player.PlayerName = cPitcher.FirstName.Trim() + " " + cPitcher.LastName.Trim();
                pBLL.InsertPlayer(player);

                playerposition.PlayerGUID = player.PlayerGUID;
                playerposition.PrimaryPositionID = TransformPos(cPitcher.Pos);
                playerposition.SecondaryPostiionID = null;
                ppBLL.DeletePlayerPosition(playerposition);
                ppBLL.InsertPlayerPosition(playerposition);


                BindingFlags flags = BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.NonPublic;


                foreach (FieldInfo f in cPitcher.GetType().GetFields(flags))
                {
                    Console.WriteLine("{0} = {1}", f.Name, f.GetValue(cPitcher));
                    System.Diagnostics.Debug.WriteLine("{0} = {1}", f.Name, f.GetValue(cPitcher));
                    string fieldName = _getBackingFieldName(f.Name.ToUpper());


                    if (fieldName != "FIRSTNAME" &&
                        fieldName != "LASTNAME" &&
                        fieldName != "PT" &&
                        fieldName != "POS")
                    {
                        stat.StatName = fieldName;
                        stat.PositionTypeID = 2;    // 1 = hitter
                        stat = sBLL.InsertStat(stat);

                        statValue.SeasonID = 23;
                        statValue.PlayerGUID = player.PlayerGUID;
                        statValue.PositionID = TransformPos(cPitcher.Pos);
                        statValue.StatID = stat.StatID;
                        if (f.GetValue(cPitcher) == null)
                        {
                            statValue.StatValue = null;
                        }
                        else
                        {
                            statValue.StatValue = f.GetValue(cPitcher).ToString();
                        }

                        sppsBLL.InsertStatValue(statValue);
                    }
                }
            }
        }

        private static string _getBackingFieldName(string propertyName)
        {

            return propertyName.Substring(propertyName.IndexOf("<") + 1, propertyName.IndexOf(">") - 1);
        }

        private static int TransformPos(string Position)
        {
            switch (Position)
            {
                case "S":
                    return 10;
                case "R":
                    return 11;
                case "C":
                    return 2;
                case "1B":
                    return 3;
                case "2B":
                    return 4;
                case "SS":
                    return 5;
                case "3B":
                    return 6;
                case "RF":
                    return 7;
                case "CF":
                    return 8;
                case "LF":
                    return 9;
            }

            return 0;
        }


    }

}
