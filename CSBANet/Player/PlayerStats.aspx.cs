using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using Telerik.Web.UI;
using Telerik.Web.UI.ImageEditor;

namespace CSBANet.Player
{
    public partial class PlayerStats : System.Web.UI.Page
    {
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rDDSeason.DataSource = SeasonBLL.ListSeason();
                rDDSeason.DataValueField = "SeasonID";
                rDDSeason.DataTextField = "SeasonName";
                rDDSeason.DataBind();
                rDDSeason.SelectedIndex = 0;

                var itemBatter = new DropDownListItem("Hitters", "1");
                rDDPositionType.Items.Add(itemBatter);

                var itemPitchers = new DropDownListItem("Pitchers", "2");
                rDDPositionType.Items.Add(itemPitchers);

                rDDPositionType.SelectedIndex = 0;

                var grid = (RadGrid)ucPlayerStats.FindControl("rGridStats");
                grid.MasterTableView.EnableGroupsExpandAll = false;

            }
            ucPlayerStats.BindChildStatsGrid();
        }

        protected void RebindChildGrid()
        {
            ucPlayerStats.BindChildStatsGrid();
        }


        protected void rDDSeason_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            hddSeasonID.Value = rDDSeason.SelectedValue;
            ucPlayerStats.BindChildStatsGrid();
        }

        protected void rDDPositionType_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            hddPrimPosID.Value = rDDPositionType.SelectedValue;
            ucPlayerStats.BindChildStatsGrid();
        }
    }
}