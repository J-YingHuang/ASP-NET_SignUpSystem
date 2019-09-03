using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class BridgeRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList();
            int i = 2;
            foreach(string key in keys)
            {
                this.AddTeamCount(i);
                i++;
            }
        }

        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            int count = fieldSpace.Controls.OfType<HtmlGenericControl>().ToList().Count + 1;

            if (count == 5)
            {
                Response.Write("<script language='javascript'>alert('隊伍人數已達上限!');</script>");
                return;
            }

            count += 1;
            this.AddTeamCount(count);
        }
        public void AddTeamCount(int count)
        {
            HtmlGenericControl formGroup = CreateDiv("form-group row", "font-size: 18px;");
            formGroup.ID = "form_Team" + count;
            formGroup.Attributes.Add("name", "form_Team" + count);
            HtmlGenericControl colNo = CreateDiv("col-2", "margin-right: 0px;");
            colNo.InnerText = "隊員" + count + "：";
            HtmlGenericControl colName = CreateDiv("col-2", "margin-left: 0px;");
            HtmlInputText inputName = new HtmlInputText("text");
            inputName.Attributes.Add("class", "form-control");
            inputName.Attributes.Add("style", "font-size: 8px; width: 150px;");
            inputName.Attributes.Add("runat", "server");
            inputName.ID = "input_Name" + count;
            HtmlGenericControl colId = CreateDiv("col-2", "margin-left: 25px;");
            HtmlInputText inputId = new HtmlInputText("text");
            inputId.Attributes.Add("class", "form-control");
            inputId.Attributes.Add("style", "font-size: 8px; width: 150px;");
            inputId.Attributes.Add("placeholder", "A123456789");
            inputId.Attributes.Add("maxlength", "10");
            inputId.Attributes.Add("runat", "server");
            inputId.ID = "input_Id" + count;
            HtmlGenericControl colBirthDate = CreateDiv("col-2", "margin-left: 25px;");
            HtmlInputText inputBirthDate = new HtmlInputText("text");
            inputBirthDate.Attributes.Add("class", "form-control");
            inputBirthDate.Attributes.Add("style", "font-size: 8px; width: 150px;");
            inputBirthDate.Attributes.Add("placeholder", "xxxx/xx/xx");
            inputBirthDate.Attributes.Add("maxlength", "10");
            inputBirthDate.Attributes.Add("runat", "server");
            inputBirthDate.ID = "input_BirthDate" + count;
            HtmlGenericControl colLeader = CreateDiv("col-2", "margin-left: 85px; margin-top: 7px;");
            HtmlInputText btn = new HtmlInputText("radio");
            btn.Attributes.Add("class", "form-check");
            btn.Attributes.Add("runat", "server");
            btn.ID = "radioBtn_" + count;
            HtmlGenericControl col_Final = CreateDiv("col-2", "margin-right: 20px;");

            colName.Controls.Add(inputName);
            colId.Controls.Add(inputId);
            colBirthDate.Controls.Add(inputBirthDate);
            colLeader.Controls.Add(btn);

            formGroup.Controls.Add(colNo);
            formGroup.Controls.Add(colName);
            formGroup.Controls.Add(colId);
            formGroup.Controls.Add(colBirthDate);
            formGroup.Controls.Add(colLeader);
            formGroup.Controls.Add(col_Final);

            fieldSpace.Controls.Add(formGroup);
        }
        public HtmlGenericControl CreateDiv(string classString, string styleString)
        {
            HtmlGenericControl newDiv = new HtmlGenericControl("DIV");
            newDiv.Attributes.Add("class", classString);
            newDiv.Attributes.Add("style", styleString);
            return newDiv;
        }
        protected void btn_Delete_ServerClick(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList();

            if (keys.Count == 0)
            {
                Response.Write("<script language='javascript'>alert('至少需要1人參賽!');</script>");
                return;
            }

            //減少一個物件
            fieldSpace.Controls.Remove(fieldSpace.Controls[fieldSpace.Controls.Count - 1]);
        }

        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            int teamCount = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList().Count;
            List<teamPeople> teamMembers = new List<teamPeople>();
            teamPeople leader = new teamPeople();
            if(radioBtn_1.Checked)
            {
                //第一個隊員是隊長
                leader.Name = input_Name1.Value;
                leader.Id = input_Id1.Value;
                leader.BirthDate = input_BirthDate1.Value;

                //其他都隊員, 不需要再判斷
            }
            else
            {
                teamPeople member = new teamPeople();
                member.Name = input_Name1.Value;
                member.Id = input_Id1.Value;
                member.BirthDate = input_BirthDate1.Value;
                teamMembers.Add(member);

                //其他有可能有隊長, 每個都需要判斷 0-0
            }
        }

        //確認資料後允許報名
        public bool CheckRegistrationData()
        {

        }
    }
    class teamPeople
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string BirthDate { get; set; }
    }
}