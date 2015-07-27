using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web.Security;
using System.Security.Principal;
using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using Telerik.Web.UI;

namespace CSBANet.Common.WebControls
{
    public partial class ucSeasonTeamOrder : System.Web.UI.UserControl
    {
        SeasonTeamBusinessLogic STBLL = new SeasonTeamBusinessLogic();
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();


        protected void Page_Load(object sender, EventArgs e)
        {

            List<SeasonDomainModel> Seasons = new List<SeasonDomainModel>();

            Seasons = SeasonBLL.ListSeason();
            var CurrentSeasonID = from Season in Seasons where Season.CurrentSeason select Season.SeasonID;

            rDDSeason.DataSource = Seasons;
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();

            rDDSeason.SelectedValue = CurrentSeasonID.FirstOrDefault().ToString();

            if (!IsPostBack)
            {
                SetupListBoxes();
            }

            if (!Roles.IsUserInRole(Page.User.Identity.Name, "CSBA_Admin"))
            {
                rBTNSaveChanges.Enabled = false;
                rBTNCancel.Enabled = false;
            }
        }

        protected void SetupListBoxes()
        {

            rLBTeamRemaining.DataSource = STBLL.ListRemainingTeams(Convert.ToInt32(rDDSeason.SelectedValue));
            rLBTeamRemaining.DataValueField = "TeamID";
            rLBTeamRemaining.DataTextField = "TeamName";
            rLBTeamRemaining.DataBind();

            rLBTeamSelected.DataSource = STBLL.ListSelectedTeams(Convert.ToInt32(rDDSeason.SelectedValue));
            rLBTeamSelected.DataValueField = "TeamID";
            rLBTeamSelected.DataTextField = "TeamName";
            rLBTeamSelected.DataBind();

        }


        protected void rDDSeason_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            SetupListBoxes();
        }

        protected void rBTNSaveChanges_Click(object sender, EventArgs e)
        {
            STBLL.DeleteSeasonTeamAll(Convert.ToInt32(rDDSeason.SelectedValue));
            int iStOrder = 1;
            foreach (RadListBoxItem item in rLBTeamSelected.Items)
            {
                SeasonTeamDomainModel _SeasonTeam = new SeasonTeamDomainModel();
                _SeasonTeam.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                _SeasonTeam.TeamID = Convert.ToInt32(item.Value);
                _SeasonTeam.ActiveFlg = true;
                _SeasonTeam.StadiumOrder = iStOrder;
                iStOrder += 1;
                STBLL.InsertSeasonTeam(_SeasonTeam);
            }

            SetupListBoxes();
        }

        protected void rBTNCancel_Click(object sender, EventArgs e)
        {
            SetupListBoxes();
        }
    }
}