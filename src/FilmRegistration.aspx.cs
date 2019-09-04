using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class FilmRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            if (!CheckRegistrationData())
                return;
            string commandString = "";
            //Value 為Type
            //Text 為隊名
            if (input_Link.Value == "")
                commandString = $"INSERT INTO FilmInfo (Name, DesignConcept, Outline, AccountID, TeamType)" +
                    $" VALUES('{select_Team.Items[select_Team.SelectedIndex].Text}'," +
                    $"'{text_Design.InnerText}'," +
                    $"'{text_Outline.InnerText}'," +
                    $"'{Session["LoginId"]}'," +
                    $"'{select_Team.Items[select_Team.SelectedIndex].Value}')";
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

            Response.Redirect("Intro.aspx");
        }
        //確認資料後允許報名
        public bool CheckRegistrationData()
        {
            string errMes = "";
            int mainCount = 1;

            //隊名要選
            if(select_Team.Items[select_Team.SelectedIndex].Text == "請選擇隊伍")
            {
                errMes += $"<p>{mainCount}. 請填寫隊名！</p>";
                mainCount++;
            }
                
            //設計理念要填
            if(text_Design.Value == "")
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

            if(errMes != "")
            {
                Modal_Body.InnerHtml = errMes;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
                return false;
            }
            else
                return true;
        }
    }
}