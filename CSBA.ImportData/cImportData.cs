using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSBA.BusinessLogicLayer;
using CSBA.DomainModels;

using Excel = Microsoft.Office.Interop.Excel;

namespace CSBA.ImportData
{
    public class cImportData
    {
        const string CWorkbook = "C:\\Users\\Dad\\Source\\Repos\\CSBAWeb\\CSBA.ImportData\\ImportData\\StatList.xls";

        static void Main(string[] args)
        {
            ImportExcelBatters();
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
                                case "RANGP1":
                                    {
                                        cHitter.Pos1 = sheet.Cells[i, j].value;
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
                                        cHitter.Agility  = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "RN":
                                    {
                                        cHitter.RN  = sheet.Cells[i, j].value;
                                        break;
                                    }
                                case "AVG":
                                    {
                                        double? dValue = sheet.Cells[i, j].value;
                                        cHitter.AVG = dValue;
                                        break;
                                    }
                                case "OBA":
                                    {
                                        double? dValue = sheet.Cells[i, j].value;
                                        cHitter.OBA = dValue;
                                        break;
                                    }
                                case "SLG":
                                    {
                                        double? dValue = sheet.Cells[i, j].value;
                                        cHitter.SLG  = dValue;
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
                                        cHitter.HP  = IValue;
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
                                        cHitter.Ks  = IValue;
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
                                        cHitter.CS  = IValue;
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
            }
        }

        public static void HandleBatter(List<clsHitter> colHitter)
        {
            PlayerBusinessLogic pBLL = new PlayerBusinessLogic();
            PlayerDomainModel player = new PlayerDomainModel();

            PlayerPostiionBusinessLogic ppBLL = new PlayerPostiionBusinessLogic();
            PlayerPositionDomainModel playerposition = new PlayerPositionDomainModel();

            foreach (clsHitter cHitter in colHitter)
            {
                player.PlayerName = cHitter.FirstName.Trim() + " " + cHitter.LastName.Trim();
                pBLL.InsertPlayer(player);

                playerposition.PlayerGUID = player.PlayerGUID;
                playerposition.PrimaryPositionID = TransformPos(cHitter.Pos1);
                playerposition.SecondaryPostiionID = TransformPos(cHitter.Pos2);
                ppBLL.DeletePlayerPosition(playerposition);
                ppBLL.InsertPlayerPosition(playerposition);

            }

        }

        private static  int TransformPos(string Position)
        {
            switch (Position)
            {
                case "P":
                    return 1;
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
