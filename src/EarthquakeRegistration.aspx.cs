using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataProcessing;

namespace SignUpSystem
{
    public partial class EarthquakeRegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LogIn"] == null || Session["LogIn"].ToString() != "Y")
                    Response.Redirect("Login.aspx");
                Session["IsFirstSubmit"] = "Y";
                //讀取Application Data
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName) + "報名表";

                AddTeamCount(1);
                AddTeamCount(2);
                AddTeamCount(3);
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

            if (count == 6)
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
            HtmlGenericControl firstCol = CreateDiv("col-1", "");
            HtmlGenericControl colNo = CreateDiv("col-2", "margin-right: 0px;");
            colNo.InnerText = "隊員" + count + "：";
            HtmlGenericControl colName = CreateDiv("col-2", "margin-left: 100px;");
            HtmlInputText inputName = new HtmlInputText("text");
            inputName.Attributes.Add("class", "form-control");
            inputName.Attributes.Add("style", "font-size: 8px; width: 150px;");
            inputName.Attributes.Add("runat", "server");
            inputName.ID = "input_Name" + count;
            HtmlGenericControl colLeader = CreateDiv("col-2", "margin-left: 180px; margin-top: 7px;");
            HtmlInputRadioButton btn = new HtmlInputRadioButton();
            btn.Attributes.Add("class", "form-check");
            btn.Attributes.Add("runat", "server");
            btn.ID = "radioBtn_" + count;
            HtmlGenericControl col_Final = CreateDiv("col-5", "margin-right: 20px;");

            colName.Controls.Add(inputName);
            colLeader.Controls.Add(btn);

            formGroup.Controls.Add(firstCol);
            formGroup.Controls.Add(colNo);
            formGroup.Controls.Add(colName);
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

            if (keys.Count == 3)
            {
                Response.Write("<script language='javascript'>alert('至少需要3人參賽!');</script>");
                return;
            }

            //減少一個物件
            fieldSpace.Controls.Remove(fieldSpace.Controls[fieldSpace.Controls.Count - 1]);
        }
        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            if (!CheckRegistrationData())
                return;

            if (Session["IsFirstSubmit"] == null || Session["IsFirstSubmit"].ToString() == "Y")
                Session["IsFirstSubmit"] = "N";
            else
            {
                Session["IsFirstSubmit"] = null;
                Response.Redirect("Intro.aspx");
            }

            int teamCount = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList().Count;
            List<string> teamMembers = new List<string>();
            string leader = "";
            //要判斷隊長是誰
            int count = (Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList()).Count;
            for (int i = 1; i <= count; i++)
            {
                HtmlInputRadioButton btn = Master.FindControl("MainContent").FindControl("radioBtn_" + i) as HtmlInputRadioButton;
                HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name" + i) as HtmlInputText;

                if (btn == null)
                    continue;

                if (btn.Checked)
                {
                    //隊長
                    leader = nameControl.Value;
                }
                else
                {
                    teamMembers.Add(nameControl.Value);
                }
            }

            //判斷有沒有第二位老師
            bool hasSecondTeacher = false;
            if (input_SecondTeacher.Value != "")
                hasSecondTeacher = true;

            //string commandString = $"INSERT INTO EarthquakeTeam (AccountID ,Name, Count, Vegetarian, LeaderName";
            string commandString = $"INSERT INTO EarthquakeTeam (AccountID ,Name, Count, LeaderName";

            for (int i = 1; i < count; i++)
                commandString += $", PlayerName{i}";

            if (hasSecondTeacher)
                commandString += ", SecondTeacher";

            commandString += $") VALUES('{Session["LoginId"]}', '{input_TeamName.Value}', {teamMembers.Count + 1}";

            /*switch (select_Veg.Items[select_Veg.SelectedIndex].Text)
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
            }*/

            commandString += $", '{leader}'";

            foreach (string peo in teamMembers)
                commandString += $", '{peo}'";

            if (hasSecondTeacher)
                commandString += $", '{input_SecondTeacher.Value}'";

            commandString += ");";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(commandString, conn);
            command.ExecuteNonQuery();

            command.Cancel();
            conn.Close();

            Session["IsFirstSubmit"] = null;
            Response.Redirect("Intro.aspx");
        }
        //確認資料後允許報名
        public bool CheckRegistrationData()
        {
            if (Session["IsFirstSubmit"] == null || Session["IsFirstSubmit"].ToString() == "N")
                return true;

            string errMes = "";
            int mainCount = 1;
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            //隊名要填
            if (input_TeamName.Value == "")
            {
                errMes += $"<p>{mainCount}. 請填寫隊名</p>";
                mainCount++;
            }
            else
            {
                //有填要確定有沒有重複的隊名
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                connect.Open();
                SqlCommand comm = new SqlCommand($"SELECT Name FROM EarthquakeTeam WHERE Name = '{input_TeamName.Value}' " +
                    $"AND CreateDate " +
                    appPro.GetBetweenSignUpTime() +
                    $";", connect);
                SqlDataReader theDr = comm.ExecuteReader();
                if (theDr.HasRows)
                {
                    errMes += $"<p>{mainCount}. 本已存在相同隊名之隊伍，請更換隊名!</p>";
                    mainCount++;
                }
                else
                {
                    theDr.Close();
                    comm.Cancel();
                    comm = new SqlCommand($"SELECT Name FROM EarthquakeTeam WHERE Name = '{input_TeamName.Value}' " +
                    $"AND CreateDate " +
                    appPro.GetBetweenSignUpTime() +
                    $";", connect);
                    theDr = comm.ExecuteReader();
                    if (theDr.HasRows)
                    {
                        errMes += $"<p>{mainCount}. 本已存在相同隊名之隊伍，請更換隊名!</p>";
                        mainCount++;
                    }
                }
                theDr.Close();
                comm.Cancel();
                connect.Close();
            }

            int count = (Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList()).Count;
            bool hasLeader = false;
            for (int i = 1; i <= count; i++)
            {
                HtmlInputRadioButton btn = Master.FindControl("MainContent").FindControl("radioBtn_" + i) as HtmlInputRadioButton;
                HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name" + i) as HtmlInputText;

                //是否為隊長
                if (btn.Checked)
                    hasLeader = true;

                //判斷隊伍資訊
                string memberError = $"<p>{mainCount}. 請確認隊員{i}資訊：</p>";

                //判斷名字有沒有寫
                if (nameControl.Value == "")
                    memberError += $"<p style=\"margin-left: 10px;　margin-top: 0px;\">．姓名不可留空!</p>";

                if (memberError != $"<p>{mainCount}. 請確認隊員{i}資訊：</p>")
                {
                    errMes += memberError;
                    mainCount++;
                }

            }

            //確認有沒有隊長
            if (!hasLeader)
            {
                errMes += $"<p>{mainCount}. 請選擇一位隊長!</p>";
                mainCount++;
            }

            //確認素食人數沒有大於隊伍人數
            /*int vegCount = 0;
            switch (select_Veg.Items[select_Veg.SelectedIndex].Text)
            {
                case "無":
                    vegCount = 0;
                    break;
                case "1人":
                    vegCount = 1;
                    break;

                case "2人":
                    vegCount = 2;
                    break;

                case "3人":
                    vegCount = 3;
                    break;

                case "4人":
                    vegCount = 4;
                    break;

                case "5人":
                    vegCount = 5;
                    break;
            }
            if(vegCount > count)
                errMes += $"<p>{mainCount}. 素食人數不得大於隊伍人數!</p>";*/

            //確認是否可以新增隊伍
            //抗震是一校六隊
            string accountSchoolId = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT SchoolID FROM Account WHERE Id = '{Session["LoginId"]}';", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
                accountSchoolId = dr["SchoolID"].ToString();

            dr.Close();
            command.Cancel();

            command = new SqlCommand($"SELECT Count(*) AS Count FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id" +
                $" WHERE Account.SchoolID = {accountSchoolId}" +
                $"AND EarthquakeTeam.CreateDate " + appPro.GetBetweenSignUpTime(), conn);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["Count"]) == 6)
                {
                    //有隊伍就不能新增
                    errMes = $"不好意思，本帳號所屬學校已報名六隊" +
                        appPro.GetApplicationString(BaseInfo.EarthquakeName) +
                        $"隊伍，不得再進行本賽程報名！";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                }
            }

            if (errMes == "")
                return true;
            else
            {
                Modal_Body.InnerHtml = errMes;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                return false;
            }
        }

        protected void btn_Cancel_ServerClick(object sender, EventArgs e)
        {
            Session["IsFirstSubmit"] = null;
            Response.Redirect("Intro.aspx");
        }
    }
}