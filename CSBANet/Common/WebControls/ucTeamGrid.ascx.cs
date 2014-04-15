using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    public partial class ucTeamGrid : System.Web.UI.UserControl
    {
        TeamBusinessLogicLayer TeamBLL = new TeamBusinessLogicLayer();
        aspnet_UsersBusinessLogic aspUserBLL = new aspnet_UsersBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridTeam_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                TeamDomainModel Team = new TeamDomainModel();

                rGridTeam.DataSource = TeamBLL.ListTeams();

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
            try
            {
                //if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)

                if (e.Item is GridDataItem)
                {

                }

                if (e.Item is GridEditFormInsertItem)
                {
                    GridEditFormInsertItem dataItem = e.Item as GridEditFormInsertItem;

                    RadDropDownList rDDUserName = (RadDropDownList)dataItem.FindControl("rDDUserName");
                    rDDUserName.DataSource = aspUserBLL.ListAspUsers();
                    rDDUserName.DataValueField = "UserId";
                    rDDUserName.DataTextField = "UserName";
                    rDDUserName.DataBind();

                }
                else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    //GridDataItem dataItem = e.Item as GridDataItem;

                    GridEditFormItem dataItem = e.Item as GridEditFormItem;

                    RadDropDownList rDDUserName = (RadDropDownList)dataItem.FindControl("rDDUserName");
                    rDDUserName.DataSource = aspUserBLL.ListAspUsers();
                    rDDUserName.DataValueField = "UserId";
                    rDDUserName.DataTextField = "UserName";
                    rDDUserName.DataBind();
                    rDDUserName.SelectedValue = DataBinder.Eval(dataItem.DataItem, "OwnerUserID").ToString();



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

        protected void rGridTeam_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridTeam_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridTeam_UpdIns(sender, e, "Update");
        }

        protected void rGridTeam_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridTeam_UpdIns(sender, e, "Insert");
        }

        protected void rGridTeam_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridTeam_UpdIns(object sender, GridCommandEventArgs e, string Action)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                TeamDomainModel TeamDM = new TeamDomainModel();

                if (Action == "Update")
                {
                    TeamDM.TeamID = Convert.ToInt32((eeditedItem.FindControl("lblTeamID") as Label).Text.ToString());
                }
                TeamDM.TeamName = (eeditedItem.FindControl("rTBTeamName") as RadTextBox).Text.Trim();
                TeamDM.OwnerName = (eeditedItem.FindControl("rTBOwnerName") as RadTextBox).Text.Trim();
                TeamDM.OwnerUserID = new Guid((eeditedItem.FindControl("rDDUserName") as RadDropDownList).SelectedValue.ToString());
                TeamDM.OwnerEmail = (eeditedItem.FindControl("rTBOwnerEmail") as RadTextBox).Text.Trim();

                var aUpload = (eeditedItem.FindControl("AsyncUpload1") as RadAsyncUpload);



                if (aUpload.UploadedFiles.Count > 0)
                {
                    EditableImage img = new EditableImage((MemoryStream)Context.Cache.Get(Session.SessionID + "UploadedFile"));
                    MemoryStream s = new MemoryStream();
                    img.Image.Save(s, img.RawFormat);
                    byte[] imgData = s.ToArray();
                    TeamDM.TeamImage = imgData;
                }
                else
                {
                    TeamDM.TeamImage = null;
                }


                if (Action == "Update")
                {
                    TeamBLL.UpdateTeam(TeamDM);
                }
                else if (Action == "Insert")
                {
                    TeamBLL.InsertTeam(TeamDM);
                }

                //rGridPlayer.Rebind();
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

        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            //Clear changes and remove uploaded image from Cache
            Context.Cache.Remove(Session.SessionID + "UploadedFile");
            using (Stream stream = e.File.InputStream)
            {
                byte[] imgData = new byte[stream.Length];
                stream.Read(imgData, 0, imgData.Length);
                MemoryStream ms = new MemoryStream();
                ms.Write(imgData, 0, imgData.Length);

                Context.Cache.Insert(Session.SessionID + "UploadedFile", ms, null, DateTime.Now.AddMinutes(20), TimeSpan.Zero);
            }
        }

        protected void RadImageEditor1_ImageLoading(object sender, ImageEditorLoadingEventArgs args)
        {
            //Handle Uploaded images
            if (!Object.Equals(Context.Cache.Get(Session.SessionID + "UploadedFile"), null))
            {
                using (EditableImage image = new EditableImage((MemoryStream)Context.Cache.Get(Session.SessionID + "UploadedFile")))
                {
                    args.Image = image.Clone();
                    args.Cancel = true;
                }
            }
        }
    }
}