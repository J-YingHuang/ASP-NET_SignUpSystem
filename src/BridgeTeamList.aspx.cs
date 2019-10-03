using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DataProcessing;

namespace SignUpSystem
{
    public partial class BridgeTeamList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //讀取Application Data
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.BridgeName) + "報名名單";

                LoadInitSelect();
                LoadTeamListBySelected();
                string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                SqlCommand command = new SqlCommand($"SELECT COUNT(*) AS Count FROM BridgeTeam WHERE CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    lab_Count.InnerText = dr["Count"].ToString() + "隊";

                dr.Close();
                command.Cancel();
                conn.Close();
            }

            //每次頁面重新彙整都會重新更新隊伍資訊
            p_UpdateTime.InnerText = $"報名隊伍清單更新時間：{DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss")}";
        }
        public void LoadInitSelect()
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //取得今年的已報名隊伍的帳號ID
            SqlCommand command = new SqlCommand($"SELECT AccountId FROM BridgeTeam WHERE CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $" GROUP BY AccountID", conn);
            SqlDataReader dr = command.ExecuteReader();
            List<string> Ids = new List<string>();
            while (dr.Read())
                Ids.Add(dr["AccountId"].ToString());
            dr.Close();
            command.Cancel();

            //取得學校名稱跟區域
            List<string> SchoolName = new List<string>();
            List<string> Areas = new List<string>();
            foreach (string id in Ids)
            {
                command = new SqlCommand($"SELECT Account.Name AS Name, School.Name AS SchoolName, School.Area AS Area  FROM Account LEFT JOIN School ON Account.SchoolID = School.Id WHERE Account.Id = '{id}';", conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    //Add teacher Name
                    select_Teacher.Items.Add(dr["Name"].ToString());
                    //取得學校名稱跟區域, 不同的才儲存
                    if (!SchoolName.Contains(dr["SchoolName"].ToString()))
                    {
                        SchoolName.Add(dr["SchoolName"].ToString());
                        select_School.Items.Add(dr["SchoolName"].ToString());
                    }
                    if (!Areas.Contains(dr["Area"].ToString()))
                    {
                        Areas.Add(dr["Area"].ToString());
                        select_Area.Items.Add(dr["Area"].ToString());
                    }
                }
                dr.Close();
                command.Cancel();
            }

            conn.Close();
        }
        public void LoadTeamListBySelected()
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            //確認符合的老師帳號
            string queryCommand = $"SELECT Account.Id AS AccountId, Account.Name AS TeacherName, School.Name AS SchoolName FROM Account LEFT JOIN School on Account.SchoolID = School.Id ";
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
                command = new SqlCommand($"SELECT Name, Count, Vegetarian FROM BridgeTeam WHERE AccountID = {teacherId} AND CreateDate " +
                    appPro.GetBetweenSignUpTime() +
                    $";", conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    string name = data["Name"].ToString();
                    string count = data["Count"].ToString();
                    string vegat = data["Vegetarian"].ToString();
                    string innerHtmltext = "<div class=\"card\" style=\"margin-bottom: 2%; display: inline-block;\">"
                        + "<div class=\"card-body text-left\">"
                        + "<h5 class=\"card-title\">" + name + "</h5>"
                        + "<h6 class=\"card-subtitle mb-2 text-muted\">" + TeacherIdToSchool[teacherId] + "</h6>"
                        + "<p class=\"card-subtitle mb-2 text-muted\">指導老師：" + TeacherIdToName[teacherId] + "</p>"
                        + "<a href=\"#\" class=\"card-link\">隊伍人數：" + count + "人</a>"
                        + "<a href=\"#\" class=\"card-link\">吃素人數：" + vegat + "人</a>"
                        + "</div></div>";

                    div_TeamCard.InnerHtml += innerHtmltext;
                }
                dr.Close();
                command.Cancel();

            }

            conn.Close();
        }
        public void LoadSchoolSelectData(string focusArea)
        {
            select_School.Items.Clear();
            select_School.Items.Add("All");
            select_Teacher.Items.Clear();
            select_Teacher.Items.Add("All");

            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //取得今年的已報名隊伍的帳號ID
            SqlCommand command = new SqlCommand($"SELECT AccountId FROM BridgeTeam WHERE CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $" GROUP BY AccountID", conn);
            SqlDataReader dr = command.ExecuteReader();
            List<string> Ids = new List<string>();
            while (dr.Read())
                Ids.Add(dr["AccountId"].ToString());
            dr.Close();
            command.Cancel();

            //取得學校名稱跟區域
            if (focusArea == "All")
            {
                List<string> SchoolName = new List<string>();
                foreach (string id in Ids)
                {
                    command = new SqlCommand($"SELECT Account.Name AS Name, School.Name AS SchoolName, School.Area AS Area  " +
                        $"FROM Account LEFT JOIN School ON Account.SchoolID = School.Id WHERE Account.Id = '{id}';", conn);
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        //Add teacher Name
                        select_Teacher.Items.Add(dr["Name"].ToString());
                        //取得學校名稱跟區域, 不同的才儲存
                        if (!SchoolName.Contains(dr["SchoolName"].ToString()))
                        {
                            SchoolName.Add(dr["SchoolName"].ToString());
                            select_School.Items.Add(dr["SchoolName"].ToString());
                        }
                    }
                    dr.Close();
                    command.Cancel();
                }
            }
            else
            {
                List<string> SchoolName = new List<string>();
                foreach (string id in Ids)
                {
                    command = new SqlCommand($"SELECT Account.Name AS Name, School.Name AS SchoolName, School.Area AS Area  " +
                        $"FROM Account LEFT JOIN School ON Account.SchoolID = School.Id WHERE Account.Id = '{id}' AND School.Area = '{focusArea}';", conn);
                    dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //Add teacher Name
                            select_Teacher.Items.Add(dr["Name"].ToString());
                            //取得學校名稱跟區域, 不同的才儲存
                            if (!SchoolName.Contains(dr["SchoolName"].ToString()))
                            {
                                SchoolName.Add(dr["SchoolName"].ToString());
                                select_School.Items.Add(dr["SchoolName"].ToString());
                            }
                        }
                    }

                    dr.Close();
                    command.Cancel();
                }
            }

            conn.Close();
        }
        public void LoadTeacherSelectData(string focusArea, string facusSchool)
        {
            select_Teacher.Items.Clear();
            select_Teacher.Items.Add("All");

            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //取得今年的已報名隊伍的帳號ID
            SqlCommand command = new SqlCommand($"SELECT AccountId FROM BridgeTeam WHERE CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $" GROUP BY AccountID", conn);
            SqlDataReader dr = command.ExecuteReader();
            List<string> Ids = new List<string>();
            while (dr.Read())
                Ids.Add(dr["AccountId"].ToString());
            dr.Close();
            command.Cancel();

            //取得學校名稱跟區域
            if (facusSchool == "All")
            {
                LoadSchoolSelectData(focusArea);
            }
            else
            {
                List<string> SchoolName = new List<string>();
                foreach (string id in Ids)
                {
                    command = new SqlCommand($"SELECT Account.Name AS Name, School.Name AS SchoolName, School.Area AS Area  " +
                        $"FROM Account LEFT JOIN School ON Account.SchoolID = School.Id WHERE Account.Id = '{id}' AND School.Name = '{facusSchool}';", conn);
                    dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //Add teacher Name
                            select_Teacher.Items.Add(dr["Name"].ToString());
                        }
                    }

                    dr.Close();
                    command.Cancel();
                }
            }

            conn.Close();
        }
        protected void select_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchoolSelectData(select_Area.Items[select_Area.SelectedIndex].Text);
            LoadTeamListBySelected();
        }
        protected void select_School_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeacherSelectData(select_Area.Items[select_Area.SelectedIndex].Text, select_School.Items[select_School.SelectedIndex].Text);
            LoadTeamListBySelected();
        }

        protected void select_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeamListBySelected();
        }
    }
}