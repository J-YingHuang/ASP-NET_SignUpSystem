using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;


namespace SignUpSystem
{
    public partial class EarthquakeTeamList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeamListBySelected();
                string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) AS Count FROM EarthquakeTeam", conn);
                SqlDataReader dr = command.ExecuteReader();
                while(dr.Read())
                    lab_Count.InnerText = dr["Count"].ToString() + "隊";

                dr.Close();
                command.Cancel();
                conn.Close();
            }
        }

        public void LoadTeamListBySelected()
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            //確認符合的老師帳號
            string queryCommand = $"SELECT Account.Id AS AccountId, Account.Name AS TeacherName, School.Name AS SchoolName FROM Account LEFT JOIN School on Account.SchoolID = School.Id ";

            //if (select_School.Items[select_School.SelectedIndex].Text != "All")
            //    whereCommand += $" School.Name = {select_School.Items[select_School.SelectedIndex].Text}";
            //if (select_Area.Items[select_Area.SelectedIndex].Text != "All")
            //    whereCommand += $", School.Area = {select_Area.Items[select_Area.SelectedIndex].Text}";
            if (select_Teacher.Items[select_Teacher.SelectedIndex].Text != "All")
                queryCommand += $"WHERE Account.Name = '{select_Teacher.Items[select_Teacher.SelectedIndex].Text}'";


            command = new SqlCommand(queryCommand + ";", conn);
            dr = command.ExecuteReader();

            //紀錄帳戶相關資訊
            Dictionary<string, string> TeacherIdToSchool = new Dictionary<string, string>();
            Dictionary<string, string> TeacherIdToName = new Dictionary<string, string>();
            while (dr.Read())
            {
                IDataRecord data = (IDataRecord)dr;
                TeacherIdToSchool.Add(data["AccountId"].ToString(), data["SchoolName"].ToString());
                TeacherIdToName.Add(data["AccountId"].ToString(), data["TeacherName"].ToString());
            }

            dr.Close();
            command.Cancel();

            div_TeamCard.InnerHtml = "";
            //讀隊伍, 然後把隊伍加進去Card
            foreach (string teacherId in TeacherIdToName.Keys)
            {
                command = new SqlCommand($"SELECT Name, Count, Vegetarian FROM EarthquakeTeam WHERE AccountID = {teacherId};", conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    string name = data["Name"].ToString();
                    string count = data["Count"].ToString();
                    string vegat = data["Vegetarian"].ToString();
                    string innerHtmltext = "<div class=\"col - 4 text - left \">"
                        + "<div class=\"card w-100\" style=\"width: 18rem; margin-bottom: 15px; \">"
                        + "<div class=\"card-body text-left\">"
                        + "<h5 class=\"card-title\">" + name + "</h5>"
                        + "<h6 class=\"card-subtitle mb-2 text-muted\">" + TeacherIdToSchool[teacherId] + "</h6>"
                        + "<p class=\"card-subtitle mb-2 text-muted\">指導老師：" + TeacherIdToName[teacherId] + "</p>"
                        + "<a href=\"#\" class=\"card-link\">隊伍人數：" + count + "人</a>"
                        + "<a href=\"#\" class=\"card-link\">吃素人數：" + vegat + "人</a>"
                        + "</div></div></div>";

                    div_TeamCard.InnerHtml += innerHtmltext;
                }
            }
            dr.Close();
            command.Cancel();

            conn.Close();
        }
        public void LoadSchoolSelectData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            //確認區域來取得相應的校名
            if (select_Area.Items[select_Area.SelectedIndex].Text == "All")
                command = new SqlCommand($"SELECT Name FROM School", conn);
            else
                command = new SqlCommand($"SELECT Name FROM School WHERE Area = '{select_Area.Items[select_Area.SelectedIndex].Text}';", conn);
            dr = command.ExecuteReader();

            select_School.Items.Clear();
            select_School.Items.Add("All");
            while (dr.Read())
            {
                select_School.Items.Add(dr["Name"].ToString());
            }
            select_School.SelectedIndex = 0;

            dr.Close();
            command.Cancel();
            conn.Close();
        }
        public void LoadTeacherSelectData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            select_Teacher.Items.Clear();
            select_Teacher.Items.Add("All");

            //確認校名來取得老師
            for(int i= 1; i < select_School.Items.Count; i++)
            {
                command = new SqlCommand("SELECT Account.Name AS Name FROM Account LEFT JOIN School on Account.SchoolID = School.Id WHERE School.Name ='"
                    + select_School.Items[select_School.SelectedIndex].Text + "';", conn);
                dr = command.ExecuteReader();

                while(dr.Read())
                    select_Teacher.Items.Add(dr["Name"].ToString());

                dr.Close();
                command.Cancel();
            }

            conn.Close();
        }
        protected void select_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchoolSelectData();
            LoadTeacherSelectData();
            LoadTeamListBySelected();
        }

        protected void select_School_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeacherSelectData();
            LoadTeamListBySelected();
        }

        protected void select_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeamListBySelected();
        }
    }
}