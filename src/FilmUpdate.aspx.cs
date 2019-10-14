using System;
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
    public partial class FilmUpdate : System.Web.UI.Page
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
                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.FilmName) + "報名資訊";

            }
        }
        public void InitLoad()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM FilmInfo WHERE Id = {Session["UpdateId"].ToString()}", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                select_Team.Items.Clear();
                select_Team.Items.Add(dr["Name"].ToString());
                select_Team.SelectedIndex = 0;

                text_Design.InnerText = dr["DesignConcept"].ToString();
                text_Outline.InnerText = dr["Outline"].ToString();

                if (dr["FileLink"].ToString() != "")
                    input_Link.Value = dr["FileLink"].ToString();
            }

            dr.Close();
            command.Cancel();
            conn.Close();
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
                if (dr["TeamType"].ToString() == "Eqrthquake")
                    earList.Remove(dr["Name"].ToString());
                else
                    briList.Remove(dr["Name"].ToString());
            }
            dr.Close();
            command.Cancel();

            foreach (string team in earList)
                select_Team.Items.Add(appPro.GetApplicationString(BaseInfo.EarthquakeName) +
                    $"|{team}");
            foreach (string team in briList)
                select_Team.Items.Add(appPro.GetApplicationString(BaseInfo.BridgeName) +
                    $"|{team}");

        }
        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            if (!CheckRegistrationData())
                return;
            string commandString = "";

            string[] teamInfo = select_Team.Items[select_Team.SelectedIndex].Text.Split('|');
            string teamName = "";
            string teamType = teamInfo[0];
            for (int i = 1; i < teamInfo.Count(); i++)
                teamName += teamInfo[i];

            if (input_Link.Value == "")
                commandString = $"UPDATE FilmInfo SET" +
                    $" Name = '{teamName}'" +
                    $", DesignConcept = '{text_Design.InnerText}'" +
                    $", Outline = '{text_Outline.InnerText}'" +
                    $" WHERE Id = '{Session["UpdateId"]}';";
            else
                commandString = $"UPDATE FilmInfo SET" +
                    $" Name = '{teamName}'" +
                    $", DesignConcept = '{text_Design.InnerText}'" +
                    $", Outline = '{text_Outline.InnerText}'" +
                    $", FileLink = '{input_Link.Value}'" +
                    $" WHERE Id = '{Session["UpdateId"]}';";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(commandString, conn);
            command.ExecuteNonQuery();

            command.Cancel();
            conn.Close();

            Session["UpdateId"] = null;
            Response.Redirect("Intro.aspx");
        }
        //確認資料後允許報名
        public bool CheckRegistrationData()
        {
            string errMes = "";
            int mainCount = 1;

            //隊名要選
            if (select_Team.Items[select_Team.SelectedIndex].Text == "請選擇隊伍")
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
            Session["UpdateId"] = null;
            if (Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y")
                Response.Redirect("~/FilmModify.aspx");
            else
                Response.Redirect("Intro.aspx");
        }
    }
}
