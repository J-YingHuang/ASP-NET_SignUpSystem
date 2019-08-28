using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SignUpSystem
{
    public partial class Intro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
                Session["Login"] = "Y";
            if (Session["LoginId"] == null)
                Session["LoginId"] = "1";

            //讀抗震大作戰的隊伍資訊
            if (!IsPostBack)
            {
                LoadTeamByAccount(TeamType.Earthquake);
                LoadAccountInfo();
            }
        }
        protected void a_Earthquake_Click(object sender, EventArgs e)
        {
            RemoveActive();
            a_Earthquake.Attributes["class"] += " active";
            LoadTeamByAccount(TeamType.Earthquake);
        }
        protected void a_Bridge_Click(object sender, EventArgs e)
        {
            RemoveActive();
            a_Bridge.Attributes["class"] += " active";
            LoadTeamByAccount(TeamType.Bridge);
        }
        protected void a_Film_Click(object sender, EventArgs e)
        {
            RemoveActive();
            a_Film.Attributes["class"] += " active";
            LoadTeamByAccount(TeamType.Film);
        }
        private void LoadTeamByAccount(TeamType type)
        {
            //Loading Team Function
            //Connect to SQL DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand();

            switch (type)
            {
                case TeamType.Earthquake:
                    command = new SqlCommand($"SELECT Id, Name FROM EarthquakeTeam WHERE AccountID = {Session["LoginId"]} AND (CreateDate BETWEEN '2019-01-01 00:00:00.000' AND '2019-12-31 00:00:00.000')", conn);
                    break;
                case TeamType.Bridge:
                    command = new SqlCommand($"SELECT Id, Name FROM BridgeTeam WHERE AccountID = {Session["LoginId"]} AND (CreateDate BETWEEN '2019-01-01 00:00:00.000' AND '2019-12-31 00:00:00.000')", conn);
                    break;
                case TeamType.Film:
                    command = new SqlCommand($"SELECT Id, Name FROM FilmInfo WHERE AccountID = {Session["LoginId"]} AND (CreateDate BETWEEN '2019-01-01 00:00:00.000' AND '2019-12-31 00:00:00.000')", conn);
                    break;
            }

            SqlDataReader dataReader = command.ExecuteReader();
            string innerHtmlStr = "";
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    IDataRecord record = (IDataRecord)dataReader;
                    string teamName = record["Name"].ToString();
                    string teamId = record["Id"].ToString();
                    innerHtmlStr += "<div class=\"card\">"
                        + "<div class=\"card-body\" style=\"text-align: left; \">"
                        + "<div class=\"row\">"
                        + "<div class=\"col-7\">"
                        + "<h6 style=\"margin-top: 5px;\">" + teamName + "</h6>"
                        + "</div><div class=\"col-5 \">"
                        + "<a id=\"" + teamId + "\" class=\"btn btn-outline-secondary float-right\" style=\"height: 32px; font-size: 12px; width: 70px;\">"
                        + "<img width=\"15px\" style=\"margin-bottom: 4px;\" src=\"https://img.icons8.com/ios-glyphs/64/000000/edit.png \">"
                        + "<span>Edit</span>"
                        + "</a>"
                        + "<a id=\"view_team1\" class=\"btn btn-outline-secondary float-right\" style=\"height: 32px; font-size: 12px; margin-right: 5px; width: 70px;\">"
                        + "<img width=\"15px\" style=\"margin-bottom: 4px;\" src=\"https://img.icons8.com/ios-glyphs/24/000000/visible.png \">"
                        + "<span>View</span>"
                        + "</a>"
                        + "</div></div></div></div>";
                }
            }
            else
            {
                innerHtmlStr += "<div class=\"card\">"
                    + "<div class=\"card-body\" style=\"color: dimgray; text-align: center; \">"
                    + "<div class=\"row\">"
                    + "<div class=\"col-12\" style=\"margin-top: 5px; \">"
                    + "<h6>尚未開始報名</h6>"
                    + "</div></div></div></div>";
            }
            div_TeamInfo.InnerHtml = innerHtmlStr;
            conn.Close();
        }
        private void RemoveActive()
        {
            a_Earthquake.Attributes["class"] = "nav-link";
            a_Bridge.Attributes["class"] = "nav-link";
            a_Film.Attributes["class"] = "nav-link";
        }
        protected void btn_NewTeam_Click(object sender, EventArgs e)
        {
            if (a_Earthquake.Attributes["class"].Contains("active"))
            {
                //去填抗震盃報名資料
            }
            else if (a_Bridge.Attributes["class"].Contains("active"))
            {
                //去填橋梁變變變資料
            }
            else
            {
                //去填微電影資料
            }
        }
        private void LoadAccountInfo()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM Account WHERE Id = {Session["LoginId"]}", conn);
            SqlDataReader reader = command.ExecuteReader();
            int schoolid = 0;
            while (reader.Read())
            {
                IDataRecord record = (IDataRecord)reader;
                user_Name.InnerText = record["Name"].ToString();
                user_Phone.InnerText = record["Phone"].ToString();
                updatePhone.Value = record["Phone"].ToString();
                user_Email.InnerText = record["Email"].ToString();
                updateEmail.Value = record["Email"].ToString();
                schoolid = Convert.ToInt32(record["SchoolID"]);
            }
            reader.Close();
            command = new SqlCommand($"SELECT Name FROM School WHERE Id = {schoolid}", conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = (IDataRecord)reader;
                user_School.InnerText = record["Name"].ToString();
            }

            conn.Close();
        }

        protected void btn_updateAccount_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"UPDATE Account SET Phone = '{updatePhone.Value.ToString()}', Email = '{updateEmail.Value.ToString()}' WHERE Id = {Session["LoginId"]}", conn);
            command.ExecuteNonQuery();
            conn.Close();

            LoadAccountInfo();
        }
    }
    enum TeamType
    {
        Earthquake,
        Bridge,
        Film
    }
}