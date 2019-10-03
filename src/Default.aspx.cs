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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //讀取Application Data
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

                DateTime startTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.StartSignUp));
                DateTime endTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndSignUp));
                if (DateTime.Now > startTime && DateTime.Now < endTime)
                    LoadInfoAboutTeam();

                //加入每屆的資料
                lab_TitleName.InnerText = $"國立高雄科技大學 {appPro.GetApplicationString(BaseInfo.GameNumber)} 抗震大作戰";
                lab_TitleGameList.InnerText = $"{appPro.GetApplicationString(BaseInfo.EarthquakeName)}X" +
                    $"{appPro.GetApplicationString(BaseInfo.BridgeName)}X" +
                    $"{appPro.GetApplicationString(BaseInfo.FilmName)}";
                lab_SignTime.InnerText = $"報名開放時間：" +
                    $"{appPro.GetDateFormat(BaseInfo.StartSignUp, "yyyy/MM/dd")} ~ " +
                    $"{appPro.GetDateFormat(BaseInfo.EndSignUp, "yyyy/MM/dd")}";
                lab_Game1Name.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName);
                lab_Game2Name.InnerText = appPro.GetApplicationString(BaseInfo.BridgeName);
                lab_Game3Name.InnerText = appPro.GetApplicationString(BaseInfo.FilmName);
            }
        }
        public void LoadInfoAboutTeam()
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            //Earthquake 
            command = new SqlCommand($"SELECT School.Name AS SchoolName, EarthquakeTeam.Name AS Name FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id " +
                $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE EarthquakeTeam.CreateDate " +
                appPro.GetBetweenSignUpTime() + ";", conn);
            dr = command.ExecuteReader();
            int count = 0;
            List<string> school = new List<string>();
            while (dr.Read())
            {
                count++;
                if (!school.Contains(dr["SchoolName"].ToString()))
                    school.Add(dr["SchoolName"].ToString());
            }
            p_Earthquake_Count.InnerText = count.ToString() + " 隊";
            p_Earthquake_SchoolCount.InnerText = school.Count().ToString() + " 校";
            dr.Close();
            command.Cancel();

            //Bridge 
            command = new SqlCommand($"SELECT School.Name AS SchoolName, BridgeTeam.Name AS Name FROM BridgeTeam LEFT JOIN Account ON BridgeTeam.AccountID = Account.Id " +
                $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE BridgeTeam.CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $";", conn);
            dr = command.ExecuteReader();
            count = 0;
            school = new List<string>();
            while (dr.Read())
            {
                count++;
                if (!school.Contains(dr["SchoolName"].ToString()))
                    school.Add(dr["SchoolName"].ToString());
            }
            p_Bridge_Count.InnerText = count.ToString() + " 隊";
            p_Birdge_SchoolCount.InnerText = school.Count().ToString() + " 校";
            dr.Close();
            command.Cancel();

            //Film
            school = new List<string>();
            command = new SqlCommand($"SELECT Name, TeamType FROM FilmInfo WHERE FilmInfo.CreateDate " +
                appPro.GetBetweenSignUpTime() +
                $";", conn);
            dr = command.ExecuteReader();
            count = 0;
            List<string> earthquakeTeam = new List<string>();
            List<string> bridgeTeam = new List<string>();

            while (dr.Read())
            {
                count++;
                if (dr["TeamType"].ToString() == "Earthquake")
                    earthquakeTeam.Add(dr["Name"].ToString());
                else
                    bridgeTeam.Add(dr["Name"].ToString());
            }
            dr.Close();
            command.Cancel();

            foreach(string ear in earthquakeTeam)
            {
                command = new SqlCommand($"SELECT School.Name AS SchoolName FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id " +
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE EarthquakeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime() +
                    $" AND EarthquakeTeam.Name = '{ear}';", conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                    if (!school.Contains(dr["SchoolName"].ToString()))
                        school.Add(dr["SchoolName"].ToString());
                dr.Close();
                command.Cancel();
            }

            foreach (string bri in bridgeTeam)
            {
                command = new SqlCommand($"SELECT School.Name AS SchoolName FROM BridgeTeam LEFT JOIN Account ON BridgeTeam.AccountID = Account.Id " +
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE BridgeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime() +
                    $" AND BridgeTeam.Name = '{bri}';", conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                    if (!school.Contains(dr["SchoolName"].ToString()))
                        school.Add(dr["SchoolName"].ToString());
                dr.Close();
                command.Cancel();
            }

            p_Film_Count.InnerText = count.ToString() + " 隊";
            p_Film_SchoolCount.InnerText = school.Count().ToString() + " 校";
        }
    }
}