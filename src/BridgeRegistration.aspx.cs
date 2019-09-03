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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            if (fieldSpace.Controls.Count == 5)
            {
                Response.Write("<script language='javascript'>alert('隊伍人數已達上限!');</script>");
                return;
            }

            int count = fieldSpace.Controls.Count + 1;
            //加一個物件
            fieldSpace.InnerHtml += "<div class=\"form-group row \" style=\"font-size: 18px;\">"
                        + "<div class=\"col-2\" style=\"margin-right: 0px;\">隊員" + count + "：</div>"
                        + "<div class=\"col-2\" style=\"margin-left: 0px;\">"
                        + "<input Id=\"input_Name" + count + "\" runat=\"server\" class=\"form-control\" type=\"text\" style=\"font-size: 8px; width: 150px;\" />"
                        + "</div><div class=\"col-2\" style=\"margin-left: 25px;\">"
                        + "<input Id=\"input_Id" + count + "\" class=\"form-control\" type=\"text\" style=\"font-size: 8px; width: 150px;\" placeholder=\" A123456789\" maxlength=\"10\" />"
                        + "</div><div class=\"col-2\" style=\"margin-left: 25px;\">"
                        + "<input Id=\"input_BirthDate" + count + "\" class=\"form-control\" type=\"text\" style=\"font-size: 8px; width: 150px;\" placeholder=\" xxxx/xx/xx\" maxlength=\"10\" />"
                        + "</div><div class=\"col-2\" style=\"margin-left: 85px; margin-top: 7px;\">"
                        + "<input Id=\"input_Leader" + count + "\" class=\"form-check\" type=\"radio\" name=\"radiobutton\" />"
                        + "</div><div class=\"col-2\" style=\"margin-right: 20px;\"></div></div>";
        }
        public void AddTeamCount()
        {

        }
        protected void btn_Delete_ServerClick(object sender, EventArgs e)
        {
            if (fieldSpace.Controls.Count == 1)
            {
                Response.Write("<script language='javascript'>alert('至少需要1人參賽!');</script>");
                return;
            }

            //減少一個物件
            fieldSpace.Controls.Remove(fieldSpace.Controls[fieldSpace.Controls.Count - 1]);
        }

        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            Control control = FindControl("input_Name2");
        }
    }
}