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
using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using Telerik.Web.UI;

namespace CSBANet.Common.WebControls
{
    public partial class ucSeasonPlayer : System.Web.UI.UserControl
    {
        SeasonPlayerBusinessLogic SPBLL = new SeasonPlayerBusinessLogic();
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();
        PositionBusinessLogic PositionBLL = new PositionBusinessLogic();

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

            rDDPosition.DataSource = PositionBLL.ListPositions();
            rDDPosition.DataTextField = "PositionNameLong";
            rDDPosition.DataValueField = "PositionID";
            rDDPosition.DataBind();

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


            rLBPlayerRemaining.DataSource = SPBLL.ListRemainingPlayers(Convert.ToInt32(rDDSeason.SelectedValue),Convert.ToInt32(rDDPosition.SelectedValue));
            rLBPlayerRemaining.DataValueField = "PlayerGUID";
            rLBPlayerRemaining.DataTextField = "PlayerName";
            rLBPlayerRemaining.DataBind();

            rLBPlayerSelected.DataSource = SPBLL.ListSelectedPlayers(Convert.ToInt32(rDDSeason.SelectedValue), Convert.ToInt32(rDDPosition.SelectedValue));
            rLBPlayerSelected.DataValueField = "PlayerGUID";
            rLBPlayerSelected.DataTextField = "PlayerName";
            rLBPlayerSelected.DataBind();


        }


        protected void rDDSeason_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            SetupListBoxes();
        }


        protected void rBTNSaveChanges_Click(object sender, EventArgs e)
        {
            SeasonPlayerDomainModel _SeasonPlayer = new SeasonPlayerDomainModel();
            _SeasonPlayer.SeasonID = (Convert.ToInt32(rDDSeason.SelectedValue));

            PositionDomainModel _Position = new PositionDomainModel();
            _Position.PositionID = (Convert.ToInt16(rDDPosition.SelectedValue));

            SPBLL.DeleteSeasonPlayerAll(_SeasonPlayer, _Position);
            int iStOrder = 1;
            foreach (RadListBoxItem item in rLBPlayerSelected.Items)
            {
                SeasonPlayerDomainModel _SPNew = new SeasonPlayerDomainModel();

                _SPNew.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                _SPNew.PlayerGUID = new Guid(item.Value.ToString());

                iStOrder += 1;
                SPBLL.InsertSeasonPlayer(_SPNew);
            }

            SetupListBoxes();
        }

        protected void rBTNCancel_Click(object sender, EventArgs e)
        {
            SetupListBoxes();
        }
    }
}