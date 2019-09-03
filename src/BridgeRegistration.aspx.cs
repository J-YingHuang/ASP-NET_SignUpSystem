using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class BridgeRegistration : System.Web.UI.Page
    {
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            if (count == 5)
                Response.Write("<script language='javascript'>alert('隊伍人數已達上限!');</script>");


        }
        public void AddTeamCount()
        {

        }
        protected void btn_Delete_ServerClick(object sender, EventArgs e)
        {

        }
    }
}