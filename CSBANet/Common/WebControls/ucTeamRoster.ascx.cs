using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.IO;
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
    public partial class ucTeamRoster : System.Web.UI.UserControl
    {
        int totPointCount = 0;
        SeasonTeamBusinessLogic SeasonTeamBLL = new SeasonTeamBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridTeam_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                TeamBusinessLogicLayer TeamBLL = new TeamBusinessLogicLayer();
                TeamDomainModel Team = new TeamDomainModel();

                int SeasonID = Convert.ToInt32((Request.QueryString["SeasonID"]));
                int TeamID = Convert.ToInt32((Request.QueryString["TeamID"]));
                rGridTeam.DataSource = TeamBLL.ListTeamRoster(SeasonID, TeamID);

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


        protected void rGridTeam_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                //GridDataItem dataItem = e.Item as GridDataItem;
                int fieldValue = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Points").ToString());
                totPointCount += fieldValue;

                RadBinaryImage rPrimPos = (RadBinaryImage)e.Item.FindControl("imgPrimPositon");
                RadBinaryImage rSecPos = (RadBinaryImage)e.Item.FindControl("imgSecPositon");

                rPrimPos.ImageUrl = "~/Content/images/" + DataBinder.Eval(e.Item.DataItem, "PrimPos").ToString().Trim() + ".jpg";
                if (DataBinder.Eval(e.Item.DataItem, "SecPos") != null)
                {
                    rSecPos.ImageUrl = "~/Content/images/" + DataBinder.Eval(e.Item.DataItem, "SecPos").ToString().Trim() + ".jpg";
                }
                else
                {
                    rSecPos.Visible = false;
                }

            }
            if (e.Item is GridFooterItem)
            {
                GridFooterItem footerItem = e.Item as GridFooterItem;
                footerItem["Points"].Text = "total: " + totPointCount.ToString();
            }
            else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem edtItem = (GridEditableItem)e.Item;
                Label lblSeasonID = (Label)edtItem.FindControl("lblSeasonID");
                Label lblTeamID = (Label)edtItem.FindControl("lblTeamID");

                RadDropDownList rDDSeasonTeam = (RadDropDownList)edtItem.FindControl("rDDSeasonTeam");
                rDDSeasonTeam.DataSource = SeasonTeamBLL.SeasonTeamOrder(Convert.ToInt32(lblSeasonID.Text));
                rDDSeasonTeam.DataValueField = "TeamID";
                rDDSeasonTeam.DataTextField = "TeamName";
                rDDSeasonTeam.DataBind();
                rDDSeasonTeam.SelectedValue = lblTeamID.Text.ToString();
            }

        }

        protected void rGridTeam_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridTeam_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                SeasonTeamPlayerDomainModel STP = new SeasonTeamPlayerDomainModel();
                DraftPlayerBusinessLogicLayer DrBLL = new DraftPlayerBusinessLogicLayer();

                STP.SeasonID = Convert.ToInt32((eeditedItem.FindControl("lblSeasonID") as Label).Text);
                STP.PlayerGUID = new Guid((eeditedItem.FindControl("lblPlayerGUID") as Label).Text);
                STP.TeamID = Convert.ToInt32((eeditedItem.FindControl("lblTeamID") as Label).Text);
                int NewTeamID = Convert.ToInt32((eeditedItem.FindControl("rDDSeasonTeam") as RadDropDownList).SelectedValue);
                int Points = Convert.ToInt32((eeditedItem.FindControl("rNUMPoints") as RadNumericTextBox).Text);

                DrBLL.TradePlayer(STP, NewTeamID, Points);

                rGridTeam.Rebind();
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