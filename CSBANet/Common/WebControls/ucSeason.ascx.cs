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

namespace CSBANet.Controls
{
    public partial class ucSeason : System.Web.UI.UserControl
    {
        SeasonBusinessLogic BLL = new SeasonBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridSeason_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                SeasonDomainModel Season = new SeasonDomainModel();

                rGridSeason.DataSource = BLL.ListSeason();

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


        protected void rGridSeason_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                //if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)

                if (e.Item is GridEditFormInsertItem)
                {
                    GridEditableItem edtItem = (GridEditableItem)e.Item;
                    RadCalendar rCal = (RadCalendar)edtItem.FindControl("calSeasonStart");

                    rCal.SelectedDate = DateTime.UtcNow;

                }
                else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    GridEditableItem edtItem = (GridEditableItem)e.Item;
                    RadCalendar rCal = (RadCalendar)edtItem.FindControl("calSeasonStart");

                    rCal.SelectedDate = (DateTime)(DataBinder.Eval(edtItem.DataItem, "DraftDate"));
                    rCal.FocusedDate = rCal.SelectedDate;

                }
                else if (e.Item is GridItem)
                {

                }
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























        protected void rGridSeason_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridSeason_UpdIns(sender, e, "Update");
        }

        protected void rGridSeason_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridSeason_UpdIns(sender, e, "Insert");
        }

        protected void rGridSeason_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            SeasonDomainModel SeasonDM = new SeasonDomainModel();
            try
            {
                SeasonDM.SeasonID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["SeasonID"];
                BLL.DeleteSeason(SeasonDM);
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

        protected void rGridSeason_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Clear")
                try
                {
                    {
                        SeasonDomainModel SeasonDM = new SeasonDomainModel();
                        SeasonDM.SeasonID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["SeasonID"];
                        BLL.ClearSeason(SeasonDM);
                    }
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



        protected void rGridSeason_UpdIns(object sender, GridCommandEventArgs e, string Action)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                SeasonDomainModel SeasonDM = new SeasonDomainModel();

                if (Action == "Update")
                {
                    SeasonDM.SeasonID = Convert.ToInt32((eeditedItem.FindControl("lblSeasonID") as Label).Text.ToString());
                }
                SeasonDM.SeasonName = (eeditedItem.FindControl("rTBSeason") as RadTextBox).Text.ToString();
                SeasonDM.MinBid = Convert.ToInt32((eeditedItem.FindControl("rTBMinBid") as RadTextBox).Text.ToString());
                SeasonDM.StartPoints = Convert.ToInt32((eeditedItem.FindControl("rTBStartPoints") as RadTextBox).Text.ToString());
                SeasonDM.DraftDate = (eeditedItem.FindControl("calSeasonStart") as RadCalendar).SelectedDate;

                //TODO - Implement GEO CODE!!!!!
                if (Action == "Update")
                {
                    BLL.UpdateSeason(SeasonDM);

                }
                else if (Action == "Insert")
                {
                    BLL.InsertSeason(SeasonDM);
                }
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

        

        protected void rGridSeason_PreRender(object sender, EventArgs e)
        {

            if (rGridSeason.EditItems.Count > 0)
            {
                foreach (GridDataItem item in rGridSeason.MasterTableView.Items)
                {
                    if (item != rGridSeason.EditItems[0])
                    {
                        item.Visible = false;
                    }
                }
            }

            foreach (GridItem item in rGridSeason.MasterTableView.Items)
            {
                if (item is GridDataItem && item.Edit)
                {
                    item.Visible = false;
                }
            }

        }


















    }



}