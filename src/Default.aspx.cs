﻿using System;
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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime(2019, 09, 30);
            DateTime endTime = new DateTime(2019, 10, 14);
            if(DateTime.Now > startTime && DateTime.Now < endTime)
                LoadInfoAboutTeam();
        }
        public void LoadInfoAboutTeam()
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            //Earthquake 
            command = new SqlCommand($"SELECT School.Name AS SchoolName, EarthquakeTeam.Name AS Name FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id " +
                $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE EarthquakeTeam.CreateDate Between '2019-01-01' AND '2019-12-31';", conn);
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
                $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE BridgeTeam.CreateDate BETWEEN '2019-01-01' AND '2019-12-31';", conn);
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
            command = new SqlCommand($"SELECT Name, TeamType FROM FilmInfo WHERE FilmInfo.CreateDate Between '2019-01-01' AND '2019-12-31';", conn);
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
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE EarthquakeTeam.CreateDate Between '2019-01-01' AND '2019-12-31'" +
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
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE BridgeTeam.CreateDate Between '2019-01-01' AND '2019-12-31'" +
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