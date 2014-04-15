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
    public partial class ucStadium : System.Web.UI.UserControl
    {
        StadiumBusinessLogic StadiumBLL = new StadiumBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rGridStadium_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                StadiumDomainModel Stadium = new StadiumDomainModel();

                rGridStadium.DataSource = StadiumBLL.ListStadiums();

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
            try
            {
                //if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)

                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    CheckBox chkActive = (CheckBox)dataItem.FindControl("chkActive");
                    chkActive.Checked = (bool)DataBinder.Eval(dataItem.DataItem, "Active_Flg");

                }

                /// We are in insert model
                if (e.Item is GridEditFormInsertItem)
                {
                }
                // We are in edit mode
                else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    GridEditFormItem dataItem = e.Item as GridEditFormItem;

                    CheckBox chkActive = (CheckBox)dataItem.FindControl("chkActive");
                    chkActive.Checked = (bool)DataBinder.Eval(dataItem.DataItem, "Active_Flg");
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

        protected void rGridStadium_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridStadium_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridStadium_UpdIns(sender, e, "Update");
        }

        protected void rGridStadium_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rGridStadium_UpdIns(sender, e, "Insert");
        }

        protected void rGridStadium_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void rGridStadium_UpdIns(object sender, GridCommandEventArgs e, string Action)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                StadiumDomainModel StadiumDM = new StadiumDomainModel();


                if (Action == "Update")
                {
                    StadiumDM.StadiumID = Convert.ToInt32((eeditedItem.FindControl("lblStadiumID") as Label).Text.ToString());
                }
                StadiumDM.StadiumName = (eeditedItem.FindControl("rTBStadiumName") as RadTextBox).Text.ToString();
                StadiumDM.Active_Flg = (eeditedItem.FindControl("chkActive") as CheckBox).Checked;

                // Deal with the image
                var aUpload = (eeditedItem.FindControl("AsyncUpload1") as RadAsyncUpload);
                if (aUpload.UploadedFiles.Count > 0)
                {
                    EditableImage img = new EditableImage((MemoryStream)Context.Cache.Get(Session.SessionID + "UploadedFile"));
                    MemoryStream s = new MemoryStream();
                    img.Image.Save(s, img.RawFormat);
                    byte[] imgData = s.ToArray();
                    StadiumDM.StadiumImage = imgData;
                }
                else
                {
                    StadiumDM.StadiumImage = null;
                }


                if (Action == "Update")
                {
                    StadiumBLL.UpdateStadium(StadiumDM);
                }
                else if (Action == "Insert")
                {
                    StadiumBLL.InsertStadium(StadiumDM);
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

        protected void rGridStadium_PreRender(object sender, EventArgs e)
        {
            
            if (rGridStadium.EditItems.Count > 0)
            {
                foreach (GridDataItem item in rGridStadium.MasterTableView.Items)
                {
                    if (item != rGridStadium.EditItems[0])
                    {
                        item.Visible = false;
                    }
                }
            }

            foreach (GridItem item in rGridStadium.MasterTableView.Items)
            {
                if (item is GridDataItem && item.Edit)
                {
                    item.Visible = false;
                }
            }

        }
    }

}