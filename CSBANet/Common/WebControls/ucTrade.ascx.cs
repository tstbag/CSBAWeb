using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Security.Principal;
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
    public partial class ucTrade : System.Web.UI.UserControl
    {
        TradeBusinessLogic TradeBLL = new TradeBusinessLogic();
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            rDDSeason.DataSource = SeasonBLL.ListSeason();
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();

        }

        protected void rGridPlayer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                SetrGridPlayerDS();
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

        protected void SetrGridPlayerDS()
        {
            TradeDomainModel Trade = new TradeDomainModel();
            Trade.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
            rGridTrade.DataSource = TradeBLL.ListTrades(Trade);

        }

        /// <summary>
        /// Hide stuff that isn't being used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rGridPlayer_PreRender(object sender, EventArgs e)
        {
            if (rGridTrade.EditItems.Count > 0)
            {
                foreach (GridDataItem item in rGridTrade.MasterTableView.Items)
                {
                    if (item != rGridTrade.EditItems[0])
                    {
                        item.Visible = false;
                    }
                }
            }

            foreach (GridItem item in rGridTrade.MasterTableView.Items)
            {
                if (item is GridDataItem && item.Edit)
                {
                    item.Visible = false;
                }
            }
        }

        protected void rGridPlayer_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rGridPlayer_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridPlayer_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridTrade_UpdIns(sender, e, "Update");
        }

        protected void rGridPlayer_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridTrade_UpdIns(sender, e, "Update");
        }

        protected void rGridTrade_UpdIns(object sender, GridCommandEventArgs e, string Action)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                TradeDomainModel TradeDM = new TradeDomainModel();

                if (Action == "Update")
                {
                    TradeDM.TradeGUID = new Guid((eeditedItem.FindControl("lblTradeGUID") as Label).Text.ToString());
                }
                TradeDM.SeasonID = Convert.ToInt32((eeditedItem.FindControl("rDDSeason") as RadDropDownList).SelectedValue.ToString());
                RadCalendar rCal = (RadCalendar)eeditedItem.FindControl("rCALProposedDate");
                TradeDM.ProposedDate = rCal.SelectedDate;
                TradeDM.TeamID = Convert.ToInt32((eeditedItem.FindControl("rDDTeam") as RadDropDownList).SelectedValue.ToString());
                TradeDM.TradeStatusID = Convert.ToInt32((eeditedItem.FindControl("rDDTradeStatus") as RadDropDownList).SelectedValue.ToString());

                if (Action == "Update")
                {
                    TradeBLL.UpdateTrade(TradeDM);

                }
                else if (Action == "Insert")
                {
                    TradeBLL.InsertTrade(TradeDM);
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
        protected void rGridPlayer_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rDDSeason_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            SetrGridPlayerDS();
            rGridTrade.Rebind();
        }
    }
}