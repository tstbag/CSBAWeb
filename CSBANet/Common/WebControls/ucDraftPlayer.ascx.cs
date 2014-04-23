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

namespace CSBANet.Common.WebControls
{
    public partial class ucDraftPlayer : System.Web.UI.UserControl
    {
        SeasonBusinessLogic SeasonBLL = new SeasonBusinessLogic();
        SeasonTeamBusinessLogic SeasonTeamBLL = new SeasonTeamBusinessLogic();
        DraftPlayerBusinessLogicLayer DraftPlayerBLL = new DraftPlayerBusinessLogicLayer();

        PlayerDomainModel PagePlayer = new PlayerDomainModel();



        PickAPlayerDomainModel PlayerDrafted = new PickAPlayerDomainModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["time"] = DateTime.Now.AddSeconds(40);

            rDDSeason.DataSource = SeasonBLL.ListSeason();
            rDDSeason.DataValueField = "SeasonID";
            rDDSeason.DataTextField = "SeasonName";
            rDDSeason.DataBind();


        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan time1 = new TimeSpan();
        //    time1 = (DateTime)Session["time"] - DateTime.Now;
        //    if (time1.Seconds <= 0)
        //    {
        //        Label1.Text = "TimeOut!";
        //    }
        //    else
        //    {
        //        Label1.Text = time1.Seconds.ToString();
        //    }

        //}

        protected void LoadrDDSeasonTeam()
        {
            //  Manually load dropdown list
            try
            {
                var ds = SeasonTeamBLL.SeasonTeamOrder(Convert.ToInt32(rDDSeason.SelectedValue));
                rDDSeasonTeam.Items.Clear();

                var itemRecycle = new DropDownListItem("Recycle Bin", "0");
                rDDSeasonTeam.Items.Add(itemRecycle);
                foreach (var element in ds)
                {
                    var item = new DropDownListItem(element.TeamName.ToString(), element.TeamID.ToString());
                    if (CanTeamBid(element.SeasonID, element.TeamID, element.MaxBid))
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.BackColor = System.Drawing.Color.LightBlue;
                    }
                    rDDSeasonTeam.Items.Add(item);
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

        protected void rDDSeasonTeam_ItemDataBound(object sender, DropDownListItemEventArgs e)
        {
            e.Item.Enabled = false;
        }
        protected void rDDSeason_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            RepaintScreen();
        }

        protected void RepaintScreen()
        {
            GetGridDataSource();
            LoadrDDSeasonTeam();
            rGridDraftPlayer.DataBind();
        }

        protected void rGridDraftPlayer_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
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



        public void BindStatsGrid(PickAPlayerDomainModel PickPlayer)
        {
            try
            {
                ucPlayerStats.BindChildStatsGrid();

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
                //MembershipUser currentUser = Membership.GetUser();
                //Guid? UserID = new Guid(currentUser.ProviderUserKey.ToString());

                rGridDraftPlayer.DataSource = DraftPlayerBLL.DraftTeamList(Convert.ToInt32(rDDSeason.SelectedValue));
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

        protected void rGridDraftPlayer_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                int SeasonID = Convert.ToInt32((item.FindControl("lblSeasonID") as Label).Text);
                int TeamID = Convert.ToInt32((item.FindControl("lblTeamID") as Label).Text);
                int MaxBid = Convert.ToInt32((item.FindControl("lblMaxBid") as Label).Text);

                if (CanTeamBid(SeasonID, TeamID, MaxBid))
                {
                }
                else
                {
                    item.Enabled = false;
                    item.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }

        protected bool CanTeamBid(int SeasonID, int TeamID, int? MaxBid)
        {
            bool ReturnVal = true;

            if (MaxBid < Convert.ToInt32(rNTBCurrBid.Value))
            {
                ReturnVal = false;
            }
            return ReturnVal;
        }

        protected void rGridDraftPlayer_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void rBTNPickPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                PickAPlayerDomainModel PickPlayer = new PickAPlayerDomainModel();
                PlayerDrafted = DraftPlayerBLL.PickAPLayer(Convert.ToInt32(rDDSeason.SelectedValue));

                if (PlayerDrafted != null)
                {
                    hddSeasonID.Value = "0"; // I want all seasons
                    hddPlayerGUID.Value = PlayerDrafted.PlayerGUID.ToString();
                    hddPrimPosID.Value = PlayerDrafted.PrimPositionTypeID.ToString();
                    imgPlayer.DataValue = PlayerDrafted.PlayerImage;
                    imgPositon.ImageUrl = "~/Content/images/" + PlayerDrafted.PrimPositionName.Trim() + ".jpg" ;

                    lblCurrPlayer.Text = PlayerDrafted.PlayerName;

                    imgPlayer.Visible = true;
                    imgPositon.Visible = true;
                    lblCurrPlayer.Visible = true;
                    rBTNAssign.Enabled = true; 

                    BindStatsGrid(PlayerDrafted);
                    LoadrDDSeasonTeam();

                    rNTBCurrBid.Value = 2;
                }
                else
                {
                    lblMessage.Text = "Draft Completed";
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

        protected void rNTBCurrBid_TextChanged(object sender, EventArgs e)
        {
            RepaintScreen();

            //GetGridDataSource();
            //rGridDraftPlayer.DataBind();
            //LoadrDDSeasonTeam();
        }

        protected void rBTNAssign_Click(object sender, EventArgs e)
        {

            if (rDDSeasonTeam.SelectedValue == "0")     // Put player in recycle bin
            {
                SeasonPlayerDomainModel SP = new SeasonPlayerDomainModel();
                SeasonPlayerBusinessLogic SPBLL = new SeasonPlayerBusinessLogic();
                SP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                SP.PlayerGUID = new Guid(hddPlayerGUID.Value);
                SPBLL.InsertSeasonPlayerRecycle(SP);
            }
            else
            {
                SeasonTeamPlayerDomainModel STP = new SeasonTeamPlayerDomainModel();
                STP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
                STP.TeamID = Convert.ToInt32(rDDSeasonTeam.SelectedValue);
                STP.PlayerGUID = new Guid(hddPlayerGUID.Value);
                STP.Points = Convert.ToInt32(rNTBCurrBid.Value);

                DraftPlayerBLL.DraftPlayer(STP);
            }
            RepaintScreen();
            
        }

        protected void rBTNEmptyRecycleBin_Click(object sender, EventArgs e)
        {
            SeasonPlayerDomainModel SP = new SeasonPlayerDomainModel();
            SeasonPlayerBusinessLogic SPBLL = new SeasonPlayerBusinessLogic();
            SP.SeasonID = Convert.ToInt32(rDDSeason.SelectedValue);
            SPBLL.DeleteSeasonRecyclePlayerAll(SP);
        }


        protected void rBTNTeamName_Click(object sender, EventArgs e)
        {
            RadButton rb = (RadButton)sender;

            int iTeamID = Convert.ToInt32(rb.CommandArgument);
            int iSeasonID = Convert.ToInt32(rDDSeason.SelectedValue);

            Response.Redirect(string.Format("~/Team/TeamRoster.aspx?SeasonID={0}&TeamID={1}", iSeasonID, iTeamID));


        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            rGridDraftPlayer.Rebind();
            int icnt = Convert.ToInt32(iCountDown.Text);
            icnt = icnt - 1;
            iCountDown.Text = icnt.ToString();

        }


    }
}