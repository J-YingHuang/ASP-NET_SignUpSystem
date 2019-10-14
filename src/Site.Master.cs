using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DataProcessing;

namespace SignUpSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            list_Eqrthquake.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName);
            list_Bridge.InnerText = appPro.GetApplicationString(BaseInfo.BridgeName);
            list_Film.InnerText = appPro.GetApplicationString(BaseInfo.FilmName);
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