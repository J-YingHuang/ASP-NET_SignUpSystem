using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Session["LoginId"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}