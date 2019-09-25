using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class BackgroundDataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_DataUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void btn_Addin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountAddin.aspx");
        }

        protected void btn_AccountModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountModify.aspx");
        }

        protected void AccountDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountDelete.aspx");
        }

        protected void btn_EearthquakeModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("EearthquakeModify.aspx");
        }

        protected void btn_EearthquakeDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("EearthquakeDelete.aspx");
        }

        protected void btn_BridgeModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("BridgeModify.aspx");
        }

        protected void btn_BridgeDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("BridgeDelete.aspx");
        }

        protected void btn_FilmModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilmModify.aspx");
        }
        protected void btn_FilmDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilmDelete.aspx");
        }
    }

        
}
    
