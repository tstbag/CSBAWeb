using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CSBANet.Common.WebControls
{
    public partial class ucDraftStadium : System.Web.UI.UserControl
    {
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            rDDSeason.DataSource = SeasonBLL.ListSeason();
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();
        }

        protected void rDDSeason_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            GetGridDataSource();
            rGridStadium.DataBind();
        }

        protected void rGridStadium_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
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

        protected void GetGridDataSource()
        {
            try
            {
                MembershipUser currentUser = Membership.GetUser();
                Guid? UserID = new Guid(currentUser.ProviderUserKey.ToString());
                DraftStadiumBLL DraftStadium = new DraftStadiumBLL();
                rGridStadium.DataSource = DraftStadium.DraftStadiumList(Convert.ToInt32(rDDSeason.SelectedValue), UserID);
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


        protected void rGridStadium_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rGridStadium_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }


    }
}