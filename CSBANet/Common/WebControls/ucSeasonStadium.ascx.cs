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
    public partial class ucSeasonStadium : System.Web.UI.UserControl
    {
        SeasonStadiumBusinessLogic SSBLL = new SeasonStadiumBusinessLogic();
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

            rLBStadiumRemaining.DataSource = SSBLL.ListRemainingStadiums(Convert.ToInt32(rDDSeason.SelectedValue));
            rLBStadiumRemaining.DataValueField = "StadiumID";
            rLBStadiumRemaining.DataTextField = "StadiumName";
            rLBStadiumRemaining.DataBind();

            rLBStadiumSelected.DataSource = SSBLL.ListSelectedStadiums(Convert.ToInt32(rDDSeason.SelectedValue));
            rLBStadiumSelected.DataValueField = "StadiumID";
            rLBStadiumSelected.DataTextField = "StadiumName";
            rLBStadiumSelected.DataBind();

        }

        protected void rDDSeason_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            SetupListBoxes();
        }


        protected void rBTNSaveChanges_Click(object sender, EventArgs e)
        {
            SeasonStadiumDomainModel _SeasonStadium = new SeasonStadiumDomainModel();
            _SeasonStadium.SeasonID = (Convert.ToInt32(rDDSeason.SelectedValue));

            SSBLL.DeleteSeasonStadiumAll(_SeasonStadium);
            int iStOrder = 1;
            foreach (RadListBoxItem item in rLBStadiumSelected.Items)
            {
                SeasonStadiumDomainModel _SSNew = new SeasonStadiumDomainModel();

                _SSNew.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                _SSNew.StadiumID  = Convert.ToInt32((item.Value.ToString()));

                iStOrder += 1;
                SSBLL.InsertSeasonStadium(_SSNew);
            }

            SetupListBoxes();
        }

        protected void rBTNCancel_Click(object sender, EventArgs e)
        {
            SetupListBoxes();
        }
    }
}