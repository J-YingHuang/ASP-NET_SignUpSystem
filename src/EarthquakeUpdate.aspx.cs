﻿using System;
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
    public partial class EarthquakeUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] != null && Session["Login"].ToString() == "Y")
                    InitLoad();
                else if (Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y")
                    InitLoad();
                else
                    Response.Redirect("Login.aspx");

                //讀取Application Data
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName) + "報名資訊";

            }

            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("input_Name")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.AddTeamCount(i);
                i++;
            }
        }
        public void InitLoad()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM EarthquakeTeam WHERE Id = {Session["UpdateId"].ToString()}", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                input_TeamName.Value = dr["Name"].ToString();
                Session["OrginName"] = dr["Name"].ToString();

                if (dr["SecondTeacher"].ToString() != "")
                    input_SecondTeacher.Value = dr["SecondTeacher"].ToString();

                for (int i = 0; i < Convert.ToInt32(dr["Count"]); i++)
                    AddTeamCount(i + 1);

                //加入隊長
                HtmlInputRadioButton btn = Master.FindControl("MainContent").FindControl("radioBtn_1") as HtmlInputRadioButton;
                HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name1") as HtmlInputText;
                btn.Checked = true;
                nameControl.Value = dr[$"LeaderName"].ToString();

                //加入隊員資料
                for (int i = 1; i < Convert.ToInt32(dr["Count"]); i++)
                    addTeamInfo(i + 1, dr);
            }
            dr.Close();
            command.Cancel();
            conn.Close();
        }
        public void addTeamInfo(int index, SqlDataReader dr)
        {
            HtmlInputText nameControl = Master.FindControl("MainContent").FindControl("input_Name" + index) as HtmlInputText;
            nameControl.Value = dr[$"PlayerName{index - 1}"].ToString();
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

            string commandString = $"UPDATE EarthquakeTeam SET Count = {count},Name ='{input_TeamName.Value}'";

            //隊長
            commandString += $", LeaderName = '{leader}'";

            //隊員
            for (int i = 1; i < count; i++)
            {
                commandString += $", PlayerName{i} = '{teamMembers[i - 1]}'";
            }

            if (input_SecondTeacher.Value != "")
                commandString += $", SecondTeacher = '{input_SecondTeacher.Value}'";
            else
                commandString += $", SecondTeacher = NULL";

            commandString += $" WHERE Id = '{Session["UpdateId"]}';";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(commandString, conn);
            command.ExecuteNonQuery();

            command.Cancel();
            conn.Close();

            //Update Name of FilmInfo 
            commandString = $"UPDATE FilmInfo SET Name ='{input_TeamName.Value}' WHERE Name='{Session["OrginName"].ToString()}'";

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            command = new SqlCommand(commandString, conn);
            command.ExecuteNonQuery();

            command.Cancel();
            conn.Close();

            



            Session["UpdateId"] = null;

            if (Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y")
                Response.Redirect("~/EearthquakeModify.aspx");
            else
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
            if (errMes == "")
                return true;
            else
            {
                Modal_Body.InnerHtml = errMes;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                return false;
            }
        }

        protected void btn_Close_ServerClick(object sender, EventArgs e)
        {
            Session["UpdateId"] = null;
            if (Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y")
                Response.Redirect("~/EearthquakeModify.aspx");
            else
                Response.Redirect("Intro.aspx");
        }
    }
}