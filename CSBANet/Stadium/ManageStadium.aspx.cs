using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSBANet.Stadium
{
    public partial class ManageStadium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblTitle = (Master.FindControl("lblTitle") as Label);
            lblTitle.Text = "Manage Stadium";
        }
    }
}