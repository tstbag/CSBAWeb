using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using System.Web.Security;

namespace CSBANet.Trade
{
    public partial class Trading : System.Web.UI.Page
    {
        aspnet_UsersBusinessLogic aspUserBLL = new aspnet_UsersBusinessLogic();
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();
        SeasonTeamBusinessLogic SeasonTeamBLL = new SeasonTeamBusinessLogic();
        PositionBusinessLogic PositionBLL = new PositionBusinessLogic();
        PositionTypeBusinessLogic PositionTypeBLL = new PositionTypeBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetFormsAuthCookie();


            if (!Page.IsPostBack)
            {
                LoadSeason();
                LoadPositions();
                LoadMyTeam();
                LoadOtherTeam();                
            }
        }

        private void GetFormsAuthCookie()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            if (ticket != null)
            {
                string strUserName = ticket.Name;
                aspnet_UsersDomainModel aspUser = aspUserBLL.ListAspUser(strUserName.Trim());
                Session["UserID_GUID"] = aspUser.UserId;
            }
        }
        private void LoadSeason()
        {
            rDDSeason.DataSource = SeasonBLL.ListSeason();
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();
        }

        private void LoadMyTeam()
        {
            TeamBusinessLogicLayer TeamBLL = new TeamBusinessLogicLayer();
            TeamDomainModel Team = new TeamDomainModel();

            Guid OwnerUserID = new Guid(Session["UserID_GUID"].ToString());
            Team = TeamBLL.ListTeam(OwnerUserID);

            int SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
            getTeamRoster(rDLMyTeam, rDZMyTeam, SeasonID, Team.TeamID, rDDMyPositionType);
        }

        private void LoadOtherTeam()
        {
            LoadSeasonTeamCombo();
            int SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
            int TeamID = Convert.ToInt32(rDDSeasonTeam.SelectedValue);
            getTeamRoster(rDLOtherTeam, rDZOtherTeam, SeasonID, TeamID, rDDOtherPositionType);
        }

        private void LoadPositions()
        {
            rDDMyPositionType.DataSource = PositionTypeBLL.ListPositionType();
            rDDMyPositionType.DataTextField = "PositionTypeDescr";
            rDDMyPositionType.DataValueField = "PositionTypeID";
            rDDMyPositionType.DataBind();
            rDDMyPositionType.SelectedValue = PositionTypeBLL.ListPositionType().FirstOrDefault().PositionTypeID.ToString();

            rDDOtherPositionType.DataSource = PositionTypeBLL.ListPositionType();
            rDDOtherPositionType.DataTextField = "PositionTypeDescr";
            rDDOtherPositionType.DataValueField = "PositionTypeID";
            rDDOtherPositionType.DataBind();
            rDDOtherPositionType.SelectedValue = PositionTypeBLL.ListPositionType().FirstOrDefault().PositionTypeID.ToString();
        }

        private void LoadSeasonTeamCombo()
        {
            var ds = SeasonTeamBLL.SeasonTeamOrder(Convert.ToInt32(rDDSeason.SelectedValue));
            rDDSeasonTeam.Items.Clear();
            rDDSeasonTeam.DataSource = ds;
            rDDSeasonTeam.DataValueField = "TeamID";
            rDDSeasonTeam.DataTextField = "TeamName";
            rDDSeasonTeam.DataBind();

            rDDMyPositionType.SelectedValue = ds.FirstOrDefault().TeamID.ToString();

        }

        private void getTeamRoster(RadDockLayout rDL, RadDockZone rDZ, int SeasonID, int TeamID, RadDropDownList rDDPosition)
        {
            TeamBusinessLogicLayer TeamBLL = new TeamBusinessLogicLayer();
            TeamDomainModel Team = new TeamDomainModel();
            List<v_Team_Draft_RosterDomainModel> lstTeamDeal = TeamBLL.ListTeamRoster(SeasonID, TeamID);

            foreach (v_Team_Draft_RosterDomainModel item in lstTeamDeal)
            {
                if (rDDPosition.SelectedValue != string.Empty)
                {
                    if (item.PositionTypeID  == Convert.ToInt32(rDDPosition.SelectedValue))
                    {
                        RadDock dock = CreateRadDock(item);
                        dock.DockHandle = DockHandle.TitleBar;
                        RadAjaxManager1.AjaxSettings.AddAjaxSetting(rDZ, dock, RadAjaxLoadingPanel1);
                        rDL.Controls.Add(dock);
                        dock.Dock(rDZ);
                    }
                }
            }
        }

        private RadDock CreateRadDock(v_Team_Draft_RosterDomainModel item)
        {
            RadDock dock = new RadDock();
            dock.DockMode = DockMode.Docked;
           // dock.ID = item.PlayerGuid.ToString();
            dock.UniqueName = item.PlayerGuid.ToString();
            dock.Title = item.PlayerName;
            dock.Width = Unit.Pixel(125);

            RadBinaryImage rBIPlayer = GetPlayerImage(item);
            dock.Controls.Add(rBIPlayer);
            dock.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;

            RadLabel rLBL = new RadLabel();
            rLBL.Text = "Trading from Team: " + item.TeamName.Trim();
            dock.Controls.Add(rLBL);

            dock.ForbiddenZones = "rDZMyTeam".Split('|');
            return dock;
        }

        private RadBinaryImage GetPlayerImage(v_Team_Draft_RosterDomainModel item)
        {
            RadBinaryImage rBIPlayer = new RadBinaryImage();
            rBIPlayer.DataValue = item.PlayerImage;
            rBIPlayer.AutoAdjustImageControlSize = false;
            rBIPlayer.Width = 120;
            rBIPlayer.Height = 158;
            return rBIPlayer;
        }
        protected void rDDSeason_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            LoadOtherTeam();
        }

        protected void rDDOtherTeamPosition_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            LoadOtherTeam();
        }

        protected void rDDOtherPositionType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            LoadOtherTeam();
        }

        protected void rDDMyPositionType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            LoadMyTeam();
        }

        protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {

        }

        protected void RadAjaxPanel2_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {

        }
    }
}