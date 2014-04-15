using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using System.Text;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            rDDSeason.DataSource = SeasonBLL.ListSeason();
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();

            if (!IsPostBack)
            {
                SetupListBoxes();
            }
        }

        protected void SetupListBoxes()
        {

            rLBPlayerRemaining.DataSource = SPBLL.ListRemainingPlayers(Convert.ToInt32(rDDSeason.SelectedValue));
            rLBPlayerRemaining.DataValueField = "PlayerGUID";
            rLBPlayerRemaining.DataTextField = "PlayerName";
            rLBPlayerRemaining.DataBind();

            rLBPlayerSelected.DataSource = SPBLL.ListSelectedPlayers(Convert.ToInt32(rDDSeason.SelectedValue));
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

            SPBLL.DeleteSeasonPlayerAll(_SeasonPlayer);
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