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
    public partial class ucPlayerGrid : System.Web.UI.UserControl
    {
        PlayerBusinessLogic PlayerBLL = new PlayerBusinessLogic();
        PlayerPostiionBusinessLogic PlayerPostionBLL = new PlayerPostiionBusinessLogic();

        PositionBusinessLogic PosBLL = new PositionBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridPlayer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                PlayerDomainModel Player = new PlayerDomainModel();

                rGridPlayer.DataSource = PlayerBLL.ListPlayerPositions();

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


        protected void rGridPlayer_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                //if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)

                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;

                    //RadDropDownList rDDPrimPosition = (RadDropDownList)dataItem.FindControl("rDDPrimPosition");
                    //rDDPrimPosition.DataSource = PosBLL.ListPositions();
                    //rDDPrimPosition.DataValueField = "PositionID";
                    //rDDPrimPosition.DataTextField = "PositionNameLong";
                    //rDDPrimPosition.DataBind();

                    //rDDPrimPosition.SelectedValue = DataBinder.Eval(dataItem.DataItem, "PrimaryPositionID").ToString();

                    //RadDropDownList rDDSecPosition = (RadDropDownList)dataItem.FindControl("rDDSecPosition");
                    //rDDSecPosition.DataSource = PosBLL.ListPositions();
                    //rDDSecPosition.DataValueField = "PositionID";
                    //rDDSecPosition.DataTextField = "PositionNameLong";
                    //rDDSecPosition.DataBind();

                    //rDDSecPosition.SelectedValue = DataBinder.Eval(dataItem.DataItem, "SecondaryPostiionID").ToString();
                }

                if (e.Item is GridEditFormInsertItem)
                {
                    GridEditFormInsertItem dataItem = e.Item as GridEditFormInsertItem;

                    RadDropDownList rDDPrimPos = (RadDropDownList)dataItem.FindControl("rDDPrimPos");
                    rDDPrimPos.DataSource = PosBLL.ListPositions();
                    rDDPrimPos.DataValueField = "PositionID";
                    rDDPrimPos.DataTextField = "PositionNameLong";
                    rDDPrimPos.DataBind();

                    RadDropDownList rDDSecPos = (RadDropDownList)dataItem.FindControl("rDDSecPos");
                    rDDSecPos.DataSource = PosBLL.ListPositions();
                    rDDSecPos.DataValueField = "PositionID";
                    rDDSecPos.DataTextField = "PositionNameLong";
                    rDDSecPos.DataBind();



                }
                else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    //GridDataItem dataItem = e.Item as GridDataItem;

                    GridEditFormItem dataItem = e.Item as GridEditFormItem;

                    RadDropDownList rDDPrimPos = (RadDropDownList)dataItem.FindControl("rDDPrimPos");
                    rDDPrimPos.DataSource = PosBLL.ListPositions();
                    rDDPrimPos.DataValueField = "PositionID";
                    rDDPrimPos.DataTextField = "PositionNameLong";
                    rDDPrimPos.DataBind();
                    if (DataBinder.Eval(dataItem.DataItem, "PrimaryPositionID") != null)
                    {
                        rDDPrimPos.SelectedValue = DataBinder.Eval(dataItem.DataItem, "PrimaryPositionID").ToString();
                    }

                    RadDropDownList rDDSecPos = (RadDropDownList)dataItem.FindControl("rDDSecPos");
                    rDDSecPos.DataSource = PosBLL.ListPositions();
                    rDDSecPos.DataValueField = "PositionID";
                    rDDSecPos.DataTextField = "PositionNameLong";
                    rDDSecPos.DataBind();
                    if (DataBinder.Eval(dataItem.DataItem, "SecondaryPostiionID") != null)
                    {
                        rDDSecPos.SelectedValue = DataBinder.Eval(dataItem.DataItem, "SecondaryPostiionID").ToString();
                    }













                    //RadImageEditor rImage = (RadImageEditor)e.Item.FindControl("RadImageEditor1");
                    //if (rImage != null)
                    //{
                    //    //rImage.ResetChanges();                        
                    //}

                    byte[] buffer = null;



                    //buffer = (byte[])dataItem.DataItem["PlayerImage"];

                    //MemoryStream memStream = new MemoryStream(buffer);
                    //MemoryStream memStream1 = new MemoryStream();
                    //System.Drawing.Bitmap.FromStream(memStream).Save(memStream1, System.Drawing.Imaging.ImageFormat.Png);
                    //rImage.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(memStream1.ToArray());














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

        protected void rGridPlayer_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridPlayer_UpdIns(sender, e, "Update");
        }

        protected void rGridPlayer_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridPlayer_UpdIns(sender, e, "Insert");
        }

        protected void rGridPlayer_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            PlayerDomainModel PlayerDM = new PlayerDomainModel();
            PlayerPositionDomainModel PlayerPositionDM = new PlayerPositionDomainModel();
            try
            {
                PlayerDM.PlayerGUID = (Guid)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PlayerGUID"];
                PlayerPositionDM.PlayerGUID = (Guid)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PlayerGUID"];

                PlayerPostionBLL.DeletePlayerPosition(PlayerPositionDM);
                PlayerBLL.DeletePlayer(PlayerDM);
                rGridPlayer.Rebind();
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

        protected void rGridPlayer_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Clear")
                try
                {
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



        protected void rGridPlayer_UpdIns(object sender, GridCommandEventArgs e, string Action)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                PlayerDomainModel PlayerDM = new PlayerDomainModel();
                PlayerPositionDomainModel PlayerPositionDM = new PlayerPositionDomainModel();

                if (Action == "Update")
                {
                    PlayerDM.PlayerGUID = new Guid((eeditedItem.FindControl("lblPlayerGUID") as Label).Text.ToString());
                }
                PlayerDM.PlayerName = (eeditedItem.FindControl("rTBPlayerName") as RadTextBox).Text.ToString();

                // Deal with the image
                var aUpload = (eeditedItem.FindControl("AsyncUpload1") as RadAsyncUpload);
                if (aUpload.UploadedFiles.Count > 0)
                {
                    EditableImage img = new EditableImage((MemoryStream)Context.Cache.Get(Session.SessionID + "UploadedFile"));
                    MemoryStream s = new MemoryStream();
                    img.Image.Save(s, img.RawFormat);
                    byte[] imgData = s.ToArray();
                    PlayerDM.PlayerImage = imgData;
                }
                else
                {
                    PlayerDM.PlayerImage = null;
                }

                // Setup PlayerPositionDM
                PlayerPositionDM.PrimaryPositionID = Convert.ToInt32(((eeditedItem.FindControl("rDDPrimPos") as RadDropDownList)).SelectedValue);
                PlayerPositionDM.SecondaryPostiionID = Convert.ToInt32(((eeditedItem.FindControl("rDDSecPos") as RadDropDownList)).SelectedValue);

                if (Action == "Update")
                {
                    PlayerPositionDM.PlayerGUID = new Guid((eeditedItem.FindControl("lblPlayerGUID") as Label).Text.ToString());
                    PlayerPostionBLL.DeletePlayerPosition(PlayerPositionDM);
                    PlayerBLL.UpdatePlayer(PlayerDM);
                    PlayerPostionBLL.UpdatePlayerPosition(PlayerPositionDM);
                }
                else if (Action == "Insert")
                {
                    PlayerBLL.InsertPlayer(PlayerDM);
                    PlayerPositionDM.PlayerGUID = PlayerDM.PlayerGUID;
                    PlayerPostionBLL.InsertPlayerPosition(PlayerPositionDM);
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




        protected void rGridPlayer_PreRender(object sender, EventArgs e)
        {

            if (rGridPlayer.EditItems.Count > 0)
            {
                foreach (GridDataItem item in rGridPlayer.MasterTableView.Items)
                {
                    if (item != rGridPlayer.EditItems[0])
                    {
                        item.Visible = false;
                    }
                }
            }

            foreach (GridItem item in rGridPlayer.MasterTableView.Items)
            {
                if (item is GridDataItem && item.Edit)
                {
                    item.Visible = false;
                }
            }

        }
    }
}