using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class ManagerLoginin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_MangerLogin_Click(object sender, EventArgs e)
        {
            string UserName = account_name.Value.Trim();
            string PW = Text1.Value.Trim();
            if ((UserName == "civilkuas@gmail.com") && (PW == "manager"))
            {
                Session["ManageLogin"] = "Y";
                Response.Redirect("BackgroundDataManagement.aspx");
            }
            else
            {
                loginSession.InnerText = "Login Error!";
            }
        }
    }
}