﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataProcessing;

namespace SignUpSystem
{
    public partial class FilmRegistration : System.Web.UI.Page
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

                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.FilmName) + "報名表";

                LoadInitTeam();
            }
        }

        public void LoadInitTeam()
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();

            List<string> earList = new List<string>();
            List<string> briList = new List<string>();

            //先抓抗震的
            SqlCommand command = new SqlCommand($"SELECT Name FROM EarthquakeTeam WHERE AccountID = {Session["LoginId"].ToString()}" +
                $" AND CreateDate " +
                appPro.GetBetweenSignUpTime(), conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
                earList.Add(dr["Name"].ToString());
            dr.Close();
            command.Cancel();

            //抓橋梁的
            command = new SqlCommand($"SELECT Name FROM BridgeTeam WHERE AccountID = {Session["LoginId"].ToString()}" +
                $" AND CreateDate " +
                appPro.GetBetweenSignUpTime(), conn);
            dr = command.ExecuteReader();
            while (dr.Read())
                briList.Add(dr["Name"].ToString());
            dr.Close();
            command.Cancel();

            //確認微電影報了沒有
            command = new SqlCommand($"SELECT Name, TeamType FROM FilmInfo WHERE AccountID = {Session["LoginId"].ToString()}" +
                $" AND CreateDate " +
                appPro.GetBetweenSignUpTime(), conn);
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                if(dr["TeamType"].ToString() == "Earthquake")
                    earList.Remove(dr["Name"].ToString());
                else
                    briList.Remove(dr["Name"].ToString());
            }
            dr.Close();
            command.Cancel();
            conn.Close();

            foreach (string team in earList)
                select_Team.Items.Add(appPro.GetApplicationString(BaseInfo.EarthquakeName) +
                    $"|{team}");
            foreach (string team in briList)
                select_Team.Items.Add(appPro.GetApplicationString(BaseInfo.BridgeName) +
                    $"|{team}");
        }
        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            if (!CheckRegistrationData())
                return;

            if (Session["IsFirstSubmit"] == null || Session["IsFirstSubmit"].ToString() == "Y")
                Session["IsFirstSubmit"] = "N";
            else
            {
                Session["IsFirstSubmit"] = null;
                Response.Redirect("Intro.aspx");
            }

            string commandString = "";

            string[] teamInfo = select_Team.Items[select_Team.SelectedIndex].Text.Split('|');
            string teamName = "";
            string teamType = teamInfo[0];
            for (int i = 1; i < teamInfo.Count(); i++)
                teamName += teamInfo[i];

            if (teamType == appPro.GetApplicationString(BaseInfo.EarthquakeName))
                teamType = "Earthquake";
            else
                teamType = "Bridge";

            if (input_Link.Value == "")
                commandString = $"INSERT INTO FilmInfo (Name, DesignConcept, Outline, AccountID, TeamType)" +
                    $" VALUES('{teamName}'," +
                    $"'{text_Design.InnerText}'," +
                    $"'{text_Outline.InnerText}'," +
                    $"'{Session["LoginId"]}'," +
                    $"'{teamType}')";
            else
                commandString = $"INSERT INTO FilmInfo (Name, DesignConcept, Outline, AccountID, TeamType, FileLink)" +
                    $" VALUES('{select_Team.Items[select_Team.SelectedIndex].Text}'," +
                    $"'{text_Design.InnerText}'," +
                    $"'{text_Outline.InnerText}'," +
                    $"'{Session["LoginId"]}'," +
                    $"'{select_Team.Items[select_Team.SelectedIndex].Value}'," +
                    $"'{input_Link.Value}')";

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

            //隊名要選
            if (select_Team.Items[select_Team.SelectedIndex].Text == "請選擇隊伍")
            {
                errMes += $"<p>{mainCount}. 請填寫隊名！</p>";
                mainCount++;
            }
            else if(select_Team.Items[select_Team.SelectedIndex].Text == "")
            {
                errMes += $"<p>{mainCount}. 請填寫隊名！</p>";
                mainCount++;
            }

            //設計理念要填
            if (text_Design.Value == "")
            {
                errMes += $"<p>{mainCount}. 請填寫設計理念！</p>";
                mainCount++;
            }

            //故事大綱要填
            if (text_Design.Value == "")
            {
                errMes += $"<p>{mainCount}. 請填寫故事大綱！</p>";
                mainCount++;
            }

            //確認選取的隊伍是不是被搶報了
            string[] teamInfo = select_Team.Items[select_Team.SelectedIndex].Text.Split('|');
            string teamName = "";
            for (int i = 1; i < teamInfo.Count(); i++)
                teamName += teamInfo[i];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT Name FROM FilmInfo WHERE " +
                $"Name = '{teamName}' AND CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $";", conn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                //該隊伍已經報名了
                errMes = $"不好意思，該隊伍已報名" +
                    appPro.GetApplicationString(BaseInfo.FilmName) +
                    $"賽程！";
            }
            dr.Close();
            command.Cancel();
            conn.Close();

            if (errMes != "")
            {
                Modal_Body.InnerHtml = errMes;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                return false;
            }
            else
                return true;
        }

        protected void btn_Cancel_ServerClick(object sender, EventArgs e)
        {
            Session["IsFirstSubmit"] = null;
            Response.Redirect("Intro.aspx");
        }
    }
}