using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.Security;
using System.Text;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using Telerik.Web.UI;
using Telerik.Web.UI.ImageEditor;
using CSBA.App_Code;
using System.Net.Mail;

using Excel = Microsoft.Office.Interop.Excel;

namespace CSBANet.Common.WebControls
{
    public partial class ucDraftPlayer : System.Web.UI.UserControl
    {
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();
        SeasonTeamBusinessLogic SeasonTeamBLL = new SeasonTeamBusinessLogic();
        DraftPlayerBusinessLogicLayer DraftPlayerBLL = new DraftPlayerBusinessLogicLayer();
        PlayerDomainModel PagePlayer = new PlayerDomainModel();
        PickAPlayerDomainModel PlayerDrafted = new PickAPlayerDomainModel();
        PositionBusinessLogic PosBLL = new PositionBusinessLogic();

        String strPageState = "Pick";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(Page.User.Identity.Name, "CSBA_Admin"))
            {
                rBTNAssign.Enabled = false;
                rBTNPickPlayer.Enabled = false;
                rDDSeasonTeam.Enabled = false;
                rBTNEmptyRecycleBin.Enabled = false;
                rBTNEmptyRecycleBin.Visible = false;
            }

            Session["time"] = DateTime.Now.AddSeconds(40);


            if (!IsPostBack)
            {
                List<SeasonDomainModel> Seasons = new List<SeasonDomainModel>();

                Seasons = SeasonBLL.ListSeason();
                var CurrentSeasonID = from Season in Seasons where Season.CurrentSeason select Season.SeasonID;


                rDDSeason.DataSource = Seasons;
                rDDSeason.DataValueField = "SeasonID";
                rDDSeason.DataTextField = "SeasonName";
                rDDSeason.DataBind();

                rDDSeason.SelectedValue = CurrentSeasonID.FirstOrDefault().ToString();

                rDDPrimPos.DataSource = PosBLL.ListPositions();
                rDDPrimPos.DataValueField = "PositionID";
                rDDPrimPos.DataTextField = "PositionNameLong";
                rDDPrimPos.DataBind();
            }

            DraftStatusDomainModel DraftStatus = new DraftStatusDomainModel();

            DraftStatus = DraftPlayerBLL.DraftStatus(Convert.ToInt32(rDDSeason.SelectedValue));
            rLGStatus.Scale.Max = (decimal)DraftStatus.SeaonPlayerTotal;
            rLGStatus.Pointer.Value = (decimal)DraftStatus.SeasonPlayerDrafted;
            rLGStatus.ToolTip = string.Format("Players Drafted: {0}, Players Total: {1}", rLGStatus.Pointer.Value, rLGStatus.Scale.Max);




        }

        protected void ManageButtons()
        {
            if (strPageState == "Pick")
            {
                rBTNPickPlayer.Enabled = true;
                rBTNAssign.Enabled = false;
            }
            else if (strPageState == "Picked")
            {
                rBTNPickPlayer.Enabled = false;
                rBTNAssign.Enabled = true;
            }


        }

        protected void LoadrDDSeasonTeam()
        {
            //  Manually load dropdown list
            try
            {
                var ds = SeasonTeamBLL.SeasonTeamOrder(Convert.ToInt32(rDDSeason.SelectedValue));
                rDDSeasonTeam.Items.Clear();

                var itemRecycle = new DropDownListItem("Recycle Bin", "0");
                rDDSeasonTeam.Items.Add(itemRecycle);
                foreach (var element in ds)
                {
                    var item = new DropDownListItem(element.TeamName.ToString(), element.TeamID.ToString());
                    if (CanTeamBid(element.SeasonID, element.TeamID, element.MaxBid))
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.BackColor = System.Drawing.Color.LightBlue;
                    }
                    rDDSeasonTeam.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }

        protected void rDDSeasonTeam_ItemDataBound(object sender, DropDownListItemEventArgs e)
        {
            e.Item.Enabled = false;
        }
        protected void rDDSeason_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            RepaintScreen();
        }

        protected void RepaintScreen()
        {
            GetGridDataSource();
            GetGridDraftedPosDataSource();
            LoadrDDSeasonTeam();
            rGridDraftPlayer.DataBind();
            rGridDraftPositionStatus.DataBind();
            RadRotator1.DataBind();

        }

        protected void rGridDraftPlayer_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                GetGridDataSource();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }



        public void BindStatsGrid(PickAPlayerDomainModel PickPlayer)
        {
            try
            {
                ucPlayerStats.BindChildStatsGrid();

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }

        protected void GetGridDataSource()
        {
            try
            {
                //MembershipUser currentUser = Membership.GetUser();
                //Guid? UserID = new Guid(currentUser.ProviderUserKey.ToString());

                rGridDraftPlayer.DataSource = DraftPlayerBLL.DraftTeamList(Convert.ToInt32(rDDSeason.SelectedValue));
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }

        protected void rGridDraftPlayer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                int SeasonID = Convert.ToInt32((item.FindControl("lblSeasonID") as Label).Text);
                int TeamID = Convert.ToInt32((item.FindControl("lblTeamID") as Label).Text);
                int MaxBid = Convert.ToInt32((item.FindControl("lblMaxBid") as Label).Text);

                if (CanTeamBid(SeasonID, TeamID, MaxBid))
                {
                }
                else
                {
                    item.Enabled = false;
                    item.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }

        protected bool CanTeamBid(int SeasonID, int TeamID, int? MaxBid)
        {
            bool ReturnVal = true;

            //  Check for violation of Max Bid
            if (MaxBid < Convert.ToInt32(rNTBCurrBid.Value))
            {
                ReturnVal = false;
            }

            return ReturnVal;
        }

        protected void rGridDraftPlayer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "TestEmail")
            {
                try
                {
                    string strFileName = CSBA.BusinessLogicLayer.Logic.cExcel.CreateSpreadsheet();
                    Attachment att = new Attachment(strFileName);
                    cMail.SendMessage("tstbag@verizon.net", "tstbag@verizon.net", "CSBA Test Email", "Test Body", att);
                }
                catch (Exception ex)
                {
                    StackTrace st = new StackTrace();
                    StackFrame sf = st.GetFrame(0);
                    string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                    string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                    Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                    string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                    Response.Redirect(url);                             // Go to the error page.
                }
            }

            if (e.CommandName == "CreateSpreadsheets")
            {
                Excel.Application myApp = new Excel.Application();

                const string CWorkbook = "C:\\Users\\Dad\\Google Drive\\CSBAweb\\CSBAWeb\\Stats\\StatList.xls";

                Excel.Workbook workbook = myApp.Workbooks.Open(CWorkbook,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing);

                Excel.Worksheet sheet = workbook.Sheets["Batters"];
            }


            if (e.CommandName == "EmailRosters")
            {
                foreach (GridDataItem item in rGridDraftPlayer.Items)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        TeamBusinessLogicLayer TeamBLL = new TeamBusinessLogicLayer();
                        RadButton rBTNTeamName = (RadButton)item.FindControl("rBTNTeamName");
                        Label lblOwnerEmail = (Label)item.FindControl("lblOwnerEmail");
                        Label lblTeamID = (Label)item.FindControl("lblTeamID");
                        List<v_Team_Draft_RosterDomainModel> TeamDraft = TeamBLL.ListTeamRoster(Convert.ToInt32(rDDSeason.SelectedValue), Convert.ToInt32(lblTeamID.Text));

                        sb.Append("<table><p class=border>");
                        sb.Append("<tr>");
                        sb.Append("<td><b><p class=border>");
                        sb.Append("Player Name");
                        sb.Append("</b></td>");
                        sb.Append("<td><b><p class=border>");
                        sb.Append("Primary Position  ");
                        sb.Append("</b></td>");
                        sb.Append("<td><b><p class=border>");
                        sb.Append("Secondary Position  ");
                        sb.Append("</b></td>");
                        sb.Append("<td><b><p class=border>");
                        sb.Append("Points   ");
                        sb.Append("</b></td>");

                        foreach (v_Team_Draft_RosterDomainModel TeamPlayer in TeamDraft)
                        {
                            sb.Append("<tr>");
                            sb.Append("<td>");
                            sb.Append("<div align=left><p class=border>");
                            sb.Append(TeamPlayer.PlayerName.Trim());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append("<div align=left><p class=border>");
                            sb.Append(TeamPlayer.PrimPos.Trim());
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append("<div align=left><p class=border>");
                            if (TeamPlayer.SecPos == null)
                            {
                                sb.Append("n/a");
                            }
                            else
                            {
                                sb.Append(TeamPlayer.SecPos.Trim());
                            }
                            sb.Append("</td>");
                            sb.Append("<td>");
                            sb.Append("<div align=right><p class=border>");
                            sb.Append(TeamPlayer.Points.ToString().Trim());
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }

                        sb.Append("</table>");

                        string[,] MergeValues = new string[,] { { "{TeamName}", rBTNTeamName.Text.Trim() }, { "{TeamRoster}", sb.ToString() } };

                        string strFileName = CSBA.BusinessLogicLayer.Logic.cExcel.CreateSpreadsheet();
                        Attachment att = new Attachment(strFileName);

                        cMail.SendMessage("tstbag@verizon.net", lblOwnerEmail.Text.ToString().Trim(), "CSBA Roster", cMail.PopulateBody("~/Content/EmailTemplates/DraftRoster.html", MergeValues),att);
                    }
                    catch (Exception ex)
                    {
                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                        string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                        Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                        string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                        Response.Redirect(url);                             // Go to the error page.
                    }
                }
            }
        }

        protected void rBTNPickPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                PickAPlayerDomainModel PickPlayer = new PickAPlayerDomainModel();
                PlayerDrafted = DraftPlayerBLL.PickAPLayer(Convert.ToInt32(rDDSeason.SelectedValue));

                if (PlayerDrafted != null)
                {
                    hddSeasonID.Value = "0"; // I want all seasons
                    hddPlayerGUID.Value = PlayerDrafted.PlayerGUID.ToString();
                    hddPrimPosID.Value = PlayerDrafted.PrimPositionTypeID.ToString();
                    imgPlayer.DataValue = PlayerDrafted.PlayerImage;
                    imgPositon.ImageUrl = "~/Content/images/" + PlayerDrafted.PrimPositionName.Trim() + ".jpg";

                    lblCurrPlayer.Text = PlayerDrafted.PlayerName;

                    imgPlayer.Visible = true;
                    imgPositon.Visible = true;
                    lblCurrPlayer.Visible = true;
                    rBTNAssign.Enabled = true;

                    BindStatsGrid(PlayerDrafted);
                    LoadrDDSeasonTeam();

                    Application.Add("CurrentPlayer", PlayerDrafted);
                    rNTBCurrBid.Value = 2;
                    strPageState = "Picked";
                    ManageButtons();
                }
                else
                {
                    lblMessage.Text = "Draft Completed";
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.
            }
        }



        protected void rNTBCurrBid_TextChanged(object sender, EventArgs e)
        {
            RepaintScreen();

            //GetGridDataSource();
            //rGridDraftPlayer.DataBind();
            //LoadrDDSeasonTeam();
        }

        protected void rBTNAssign_Click(object sender, EventArgs e)
        {

            if (rDDSeasonTeam.SelectedValue == "0")     // Put player in recycle bin
            {
                SeasonPlayerDomainModel SP = new SeasonPlayerDomainModel();
                SeasonPlayerBusinessLogic SPBLL = new SeasonPlayerBusinessLogic();
                SP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                SP.PlayerGUID = new Guid(hddPlayerGUID.Value);
                SPBLL.InsertSeasonPlayerRecycle(SP);
            }
            else
            {
                SeasonTeamPlayerDomainModel STP = new SeasonTeamPlayerDomainModel();
                STP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                STP.TeamID = Convert.ToInt32(rDDSeasonTeam.SelectedValue);
                STP.PlayerGUID = new Guid(hddPlayerGUID.Value);
                STP.Points = Convert.ToInt32(rNTBCurrBid.Value);

                DraftPlayerBLL.DraftPlayer(STP);
            }
            strPageState = "Pick";
            ManageButtons();
            RepaintScreen();

        }

        protected void rBTNEmptyRecycleBin_Click(object sender, EventArgs e)
        {
            SeasonPlayerDomainModel SP = new SeasonPlayerDomainModel();
            SeasonPlayerBusinessLogic SPBLL = new SeasonPlayerBusinessLogic();
            SP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
            SPBLL.DeleteSeasonRecyclePlayerAll(SP);
        }


        protected void rBTNTeamName_Click(object sender, EventArgs e)
        {
            RadButton rb = (RadButton)sender;

            int iTeamID = Convert.ToInt32(rb.CommandArgument);
            int iSeasonID = Convert.ToInt32(rDDSeason.SelectedValue);

            Response.Redirect(string.Format("~/Team/TeamRoster.aspx?SeasonID={0}&TeamID={1}", iSeasonID, iTeamID));


        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            //rGridDraftPlayer.Rebind();
            //int icnt = Convert.ToInt32(iCountDown.Text);
            //icnt = icnt - 1;
            //iCountDown.Text = icnt.ToString();

        }

        protected void rGridDraftPositionStatus_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetGridDraftedPosDataSource();

        }


        protected void GetGridDraftedPosDataSource()
        {
            int iDrafted = 0;
            if (chkDrafted.Checked == true)
                iDrafted = 1;
            else
                iDrafted = 0;
            try
            {
                rGridDraftPositionStatus.DataSource = DraftPlayerBLL.DraftPositionStatus(Convert.ToInt32(rDDSeason.SelectedValue), iDrafted);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }



        protected void chkDrafted_CheckedChanged(object sender, EventArgs e)
        {
            GetGridDraftedPosDataSource();
            rGridDraftPositionStatus.DataBind();
        }

        protected void chkDraftedPlayers_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}