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
using System.Text;
using CSBA.BusinessLogicLayer;
using CSBA.Contracts;
using CSBA.DomainModels;
using Telerik.Web.UI;
using Telerik.Web.UI.ImageEditor;


namespace CSBANet.Common.WebControls
{
    public partial class ucPosition : System.Web.UI.UserControl
    {
        PositionBusinessLogic PosBLL = new PositionBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rGridPosition.DataSource = PosBLL.ListPositions();
                rGridPosition.DataBind();
            }
        }

        protected void rGridPosition_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rGridPosition.DataSource = PosBLL.ListPositions();
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

        protected void rGridPosition_PreRender(object sender, EventArgs e)
        {
            //if (rGridPosition.EditItems.Count > 0)
            //{
            //    foreach (GridDataItem item in rGridPosition.MasterTableView.Items)
            //    {
            //        if (item != rGridPosition.EditItems[0])
            //        {
            //            item.Visible = false;
            //        }
            //    }
            //}

            //foreach (GridItem item in rGridPosition.MasterTableView.Items)
            //{
            //    if (item is GridDataItem && item.Edit)
            //    {
            //        item.Visible = false;
            //    }
            //}
        }

        protected void rGridPosition_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem dataItem = e.Item as GridDataItem;
            //    if (!Roles.IsUserInRole(Page.User.Identity.Name, "CSBA_Admin"))
            //    {
            //        ImageButton EditButton = (ImageButton)dataItem["EditCommandColumn"].Controls[0];
            //        EditButton.Visible = false;
            //    }
            //}
        }

        protected void rGridPosition_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }

        protected void rGridPosition_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                PositionDomainModel PosDM = new PositionDomainModel();
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                PosDM.PositionID = Convert.ToInt32((eeditedItem.FindControl("lblPositionID") as Label).Text.ToString());
                PosDM.PositionTypeID = Convert.ToInt32((eeditedItem.FindControl("lblPositionTypeID") as Label).Text.ToString());
                PosDM.PositionName = (eeditedItem.FindControl("lblPositionName") as Label).Text.ToString().Trim();
                PosDM.PositionNameLong = (eeditedItem.FindControl("rTXTPositionNameLong") as RadTextBox).Text.ToString().Trim();
                PosDM.MaxCount = Convert.ToInt32((eeditedItem.FindControl("rNTBMaxCount") as RadNumericTextBox).Value);

                PosBLL.UpdatePosition(PosDM);
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