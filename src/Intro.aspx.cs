using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SignUpSystem
{
    public partial class Intro : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
                Session["Login"] = "Y";
            if (Session["LoginId"] == null)
                Session["LoginId"] = "1";


        }

    }
}