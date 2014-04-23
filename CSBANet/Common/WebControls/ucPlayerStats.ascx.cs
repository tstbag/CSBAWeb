using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using CSBA.BusinessLogicLayer;
using CSBA.DomainModels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSBANet.Common.WebControls
{

    public partial class ucPlayerStats : System.Web.UI.UserControl
    {
        public Guid sPlayerGUID;
        SeasonPlayerPositionStatBusinessLogic sppsBLL = new SeasonPlayerPositionStatBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridStats_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                HiddenField hSeasonID = (HiddenField)Parent.FindControl("hddSeasonID");
                HiddenField hPlayerGUID = (HiddenField)Parent.FindControl("hddPlayerGUID");
                HiddenField hddPrimPosID = (HiddenField)Parent.FindControl("hddPrimPosID");

                PickAPlayerDomainModel PlayerDrafted = new PickAPlayerDomainModel();
                PlayerDrafted.PlayerGUID = new Guid(hPlayerGUID.Value.ToString());
                PlayerDrafted.SeasonID = Convert.ToInt32(hSeasonID.Value);
                PlayerDrafted.PrimPositionTypeID = Convert.ToInt32(hddPrimPosID.Value);

                DataTable dt = sppsBLL.GetDynamicStats(PlayerDrafted);
                rGridStats.DataSource = dt;
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

        public void BindChildStatsGrid()
        {
            HiddenField hSeasonID = (HiddenField)Parent.FindControl("hddSeasonID");
            HiddenField hPlayerGUID = (HiddenField)Parent.FindControl("hddPlayerGUID");
            HiddenField hddPrimPosID = (HiddenField)Parent.FindControl("hddPrimPosID");

            PickAPlayerDomainModel PlayerDrafted = new PickAPlayerDomainModel();
            PlayerDrafted.PlayerGUID = new Guid(hPlayerGUID.Value.ToString());
            PlayerDrafted.SeasonID = Convert.ToInt32(hSeasonID.Value);
            PlayerDrafted.PrimPositionTypeID = Convert.ToInt32(hddPrimPosID.Value);

            rGridStats.DataSource = null;
            rGridStats.DataBind();

            DataTable dt = sppsBLL.GetDynamicStats(PlayerDrafted);
            rGridStats.DataSource = dt;
            rGridStats.DataBind();
        }

    }
}