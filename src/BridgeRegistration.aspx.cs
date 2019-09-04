using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SignUpSystem
{
    public partial class BridgeRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LogIn"] == null || Session["LogIn"].ToString() != "Y")
                    Response.Redirect("Login.aspx");
                AddTeamCount(1);
            }

            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.AddTeamCount(i);
                i++;
            }
        }

        protected void btn_Add_ServerClick(object sender, EventArgs e)
        {
            int count = fieldSpace.Controls.OfType<HtmlGenericControl>().ToList().Count;

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
            HtmlGenericControl colBirthday = CreateDiv("col-2", "margin-left: 25px;");
            HtmlInputText inputBirthday = new HtmlInputText("text");
            inputBirthday.Attributes.Add("class", "form-control");
            inputBirthday.Attributes.Add("style", "font-size: 8px; width: 150px;");
            inputBirthday.Attributes.Add("placeholder", "yyyy-mm-dd");
            inputBirthday.Attributes.Add("maxlength", "10");
            inputBirthday.Attributes.Add("runat", "server");
            inputBirthday.ID = "input_Birthday" + count;
            HtmlGenericControl colLeader = CreateDiv("col-2", "margin-left: 85px; margin-top: 7px;");
            HtmlInputRadioButton btn = new HtmlInputRadioButton();
            btn.Attributes.Add("class", "form-check");
            btn.Attributes.Add("runat", "server");
            btn.ID = "radioBtn_" + count;
            HtmlGenericControl col_Final = CreateDiv("col-2", "margin-right: 20px;");

            colName.Controls.Add(inputName);
            colId.Controls.Add(inputId);
            colBirthday.Controls.Add(inputBirthday);
            colLeader.Controls.Add(btn);

            formGroup.Controls.Add(colNo);
            formGroup.Controls.Add(colName);
            formGroup.Controls.Add(colId);
            formGroup.Controls.Add(colBirthday);
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

            if (keys.Count == 1)
            {
                Response.Write("<script language='javascript'>alert('至少需要1人參賽!');</script>");
                return;
            }

            //減少一個物件
            fieldSpace.Controls.Remove(fieldSpace.Controls[fieldSpace.Controls.Count - 1]);
        }

        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            if (!CheckRegistrationData())
                return;

            int teamCount = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList().Count;
            List<teamPeople> teamMembers = new List<teamPeople>();
            teamPeople leader = new teamPeople();
            //要判斷隊長是誰
            int count = (Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList()).Count;
            for (int i = 1; i <= count; i++)
            {
                HtmlInputRadioButton btn = Master.FindControl("MainContent").FindControl("radioBtn_" + i) as HtmlInputRadioButton;
                HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name" + i) as HtmlInputText;
                HtmlInputText idControl = Master.FindControl("MainContent").FindControl("input_Id" + i) as HtmlInputText;
                HtmlInputText BirthdayControl = Master.FindControl("MainContent").FindControl("input_Birthday" + i) as HtmlInputText;

                if (btn == null)
                    continue;

                if (btn.Checked)
                {
                    //隊長
                    leader.Name = nameControl.Value;
                    leader.Id = idControl.Value;
                    leader.Birthday = BirthdayControl.Value;
                }
                else
                {
                    teamPeople member2 = new teamPeople();
                    member2.Name = nameControl.Value;
                    member2.Id = idControl.Value;
                    member2.Birthday = BirthdayControl.Value;

                    teamMembers.Add(member2);
                }
            }

            string commandString = $"INSERT INTO BridgeTeam (AccountID ,Name, Count, Vegetarian, LeaderName, LeaderID, LeaderBirthday";

            for (int i = 1; i < count; i++)
                commandString += $", PlayerName{i}, PlayerID{i}, PlayerBirthday{i}";

            commandString += $") VALUES('{Session["LoginId"]}', '{input_TeamName.Value}', {teamMembers.Count + 1}";

            switch (select_Veg.Items[select_Veg.SelectedIndex].Text)
            {
                case "無":
                    commandString += ", 0";
                    break;
                case "1人":
                    commandString += ", 1";
                    break;

                case "2人":
                    commandString += ", 2";
                    break;

                case "3人":
                    commandString += ", 3";
                    break;

                case "4人":
                    commandString += ", 4";
                    break;

                case "5人":
                    commandString += ", 5";
                    break;
            }

            commandString += $", '{leader.Name}', '{leader.Id}', '{leader.Birthday}'";

            foreach(teamPeople peo in teamMembers)
                commandString += $", '{peo.Name}', '{peo.Id}', '{peo.Birthday}'";

            commandString += ");";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(commandString, conn);
            command.ExecuteNonQuery();

            command.Cancel();
            conn.Close();

            Response.Redirect("Intro.aspx");
        }

        //確認資料後允許報名
        public bool CheckRegistrationData()
        {
            string errMes = "";
            int mainCount = 1;
            //隊名要填
            if (input_TeamName.Value == "")
            {
                errMes += $"<p>{mainCount}. 請填寫隊名</p>";
                mainCount++;
            }

            int count = (Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList()).Count;
            bool hasLeader = false;
            for (int i = 1; i <= count; i++)
            {
                HtmlInputRadioButton btn = Master.FindControl("MainContent").FindControl("radioBtn_" + i) as HtmlInputRadioButton;
                HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name" + i) as HtmlInputText;
                HtmlInputText idControl = Master.FindControl("MainContent").FindControl("input_Id" + i) as HtmlInputText;
                HtmlInputText BirthdayControl = Master.FindControl("MainContent").FindControl("input_Birthday" + i) as HtmlInputText;

                //不是需要判別的控制項
                if (btn.Checked)
                    hasLeader = true;


                //判斷隊伍資訊
                string memberError = $"<p>{mainCount}. 請確認隊員{count}資訊：</p>";

                //判斷名字有沒有寫
                if (nameControl.Value == "")
                    memberError += $"<p style=\"margin-left: 10px;　margin-top: 0px;\">．姓名不可留空!</p>";

                //判斷身份證字號
                if (!Regex.IsMatch(idControl.Value, @"([A-Z]|[a-z])\d{9}"))
                    memberError += $"<p style=\"margin-left: 10px;　margin-top: 0px;\">．身分證字號不符合規定!</p>";

                //判斷生日
                if (!Regex.IsMatch(BirthdayControl.Value, @"^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$"))
                    memberError += $"<p style=\"margin-left: 10px;　margin-top: 0px;\">．生日不符合規定!</p>";

                if (memberError != $"<p>{mainCount}. 請確認隊員{count}資訊：</p>")
                {
                    errMes += memberError;
                    mainCount++;
                }

            }

            //確認有沒有隊長
            if (!hasLeader)
                errMes += $"<p>{mainCount}. 請選擇一位隊長!</p>";

            if (errMes == "")
                return true;
            else
            {
                Modal_Body.InnerHtml = errMes;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                return false;
            }
        }
    }
    class teamPeople
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}