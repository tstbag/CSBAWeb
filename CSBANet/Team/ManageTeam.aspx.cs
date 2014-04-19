using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSBANet.Team
{
    public partial class ManageTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Label lblTitle = (Master.FindControl("lblTitle") as Label);
            lblTitle.Text = "Manage Team";
        }
    }
}