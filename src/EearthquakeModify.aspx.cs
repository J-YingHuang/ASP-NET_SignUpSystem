using DataProcessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class EearthquakeModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                DateTime startTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.StartSignUp));
                DateTime endTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndSignUp));
                if (!(DateTime.Now >= startTime && DateTime.Now <= endTime))
              

                a_Earthquake.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName);
            }
        }
        protected void a_Earthquake_Click(object sender, EventArgs e)
        {
            RemoveActive();
            a_Earthquake.Attributes["class"] += " active";
            LoadTeamByAccount(TeamType.Earthquake);
        }
        private void RemoveActive()
        {
            a_Earthquake.Attributes["class"] = "nav-link";
           
        }
        private void LoadTeamByAccount(TeamType type)
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

           
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT Id, Name FROM EarthquakeTeam WHERE AccountID = {Session["LoginId"]} AND (CreateDate " +
                        appPro.GetBetweenSignUpTime() + ")", conn);
            SqlDataReader dataReader = command.ExecuteReader();
            string innerHtmlStr = "";
            if (dataReader.HasRows)
            {
               
                
                    IDataRecord record = (IDataRecord)dataReader;
                    string teamName = record["Name"].ToString();
                    string teamId = record["Id"].ToString();
                    bool hasUpdate = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndUpdateInfo));
                    bool hasUpdateLink = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndFilmUpdate));
        
                
            }
            else
            {
                innerHtmlStr += "<div class=\"card\">"
                    + "<div class=\"card-body\" style=\"color: dimgray; text-align: center; \">"
                    + "<div class=\"row\">"
                    + "<div class=\"col-12\" style=\"margin-top: 5px; \">"
                    + "<h6>尚未開始報名</h6>"
                    + "</div></div></div></div>";
                div_TeamInfo.InnerHtml = innerHtmlStr;
            }
            conn.Close();
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            //登出
            Session["Login"] = "N";
            Session["LoginId"] = "Null";
            Response.Redirect("BackgroundDataManagement.aspx");
        }
    }
}