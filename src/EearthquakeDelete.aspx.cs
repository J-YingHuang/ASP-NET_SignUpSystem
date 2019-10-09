using DataProcessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class EearthquakeDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ManageLogin"] == null || Session["ManageLogin"].ToString() != "Y")
                    Response.Redirect("~/ManagerLogin.aspx");
                LoadSchoolSelectData();
            }
            LoadTeamByAccount();
        }

        private void LoadSchoolSelectData()
        {
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            Select_School.Items.Clear();
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand da = new SqlCommand("SELECT Name FROM School ", conn);
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
                Select_School.Items.Add(dr["Name"].ToString());
            dr.Close();
            da.Cancel();
            conn.Close();
        }

        private void LoadTeamByAccount()
        {
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            string queryCommand = $"SELECT EarthquakeTeam.Name AS teamName, EarthquakeTeam.Id AS teamid,School.Name AS SchoolName FROM EarthquakeTeam LEFT JOIN  Account ON EarthquakeTeam.AccountID = Account.Id " +
                                $"LEFT JOIN School ON Account.SchoolID=School.Id ";
            if (Select_School.Items[Select_School.SelectedIndex].Text != "All")
                queryCommand += $"WHERE School.Name = '{Select_School.Items[Select_School.SelectedIndex].Text}' AND EarthquakeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime();

            command = new SqlCommand(queryCommand + ";", conn);
            dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    IDataRecord record = (IDataRecord)dr;
                    string teamName = record["teamName"].ToString();
                    string SchoolName = record["SchoolName"].ToString();
                    string teamID = record["teamid"].ToString();
             
                    AddTeamCard(teamName, SchoolName, teamID, div1);
                }
            }
            dr.Close();
            command.Cancel();
            conn.Close();
        }

        private void AddTeamCard(string teamName, string schoolName, string teamID,  HtmlGenericControl div1)
        {
            HtmlGenericControl cardDiv = NewDiv("card");
            cardDiv.Attributes.Add("style", "margin-bottom: 10px;");
            HtmlGenericControl cardBodyDiv = NewDiv("card-body");
            cardBodyDiv.Attributes.Add("style", "text-align: left;");
            HtmlGenericControl rowDiv = NewDiv("row");
            HtmlGenericControl rolEditDiv = NewDiv("col-7");
            HtmlGenericControl editName = new HtmlGenericControl("H6");
            editName.Attributes.Add("style", "margin-top: 5px;");
            editName.InnerText = teamName + "," + schoolName;
            HtmlGenericControl ColFiveDiv = NewDiv("col-5");
            HtmlAnchor viewBtnA = new HtmlAnchor();
            viewBtnA.ID = "EquakeTeam" + "|View|" + teamID;
            viewBtnA.Attributes.Add("class", "btn btn-outline-secondary float-right");
            viewBtnA.Attributes.Add("style", "height: 32px; font-size: 12px; margin-right: 5px; width: 70px;");
            viewBtnA.Attributes.Add("runat", "server");
            viewBtnA.Attributes.Add("onClick", "return true;");
            viewBtnA.Attributes.Add("onserverclick", "TeamView");
            viewBtnA.ServerClick += new EventHandler(TeamView);
            HtmlGenericControl viewImg = new HtmlGenericControl("IMG");
            viewImg.Attributes.Add("width", "15px");
            viewImg.Attributes.Add("style", "margin-bottom: 4px;");
            viewImg.Attributes.Add("src", "https://img.icons8.com/ios/32/000000/trash.png");
            HtmlGenericControl viewSpan = new HtmlGenericControl("SPAN");
            viewSpan.InnerText = "Delete";
            cardDiv.Controls.Add(cardBodyDiv);
            cardBodyDiv.Controls.Add(rowDiv);
            rowDiv.Controls.Add(rolEditDiv);
            rolEditDiv.Controls.Add(editName);
            rowDiv.Controls.Add(ColFiveDiv);
            ColFiveDiv.Controls.Add(viewBtnA);
            viewBtnA.Controls.Add(viewImg);
            viewBtnA.Controls.Add(viewSpan);

            div1.Controls.Add(cardDiv);
        }

        private void TeamView(object sender, EventArgs e)
        {
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            string teamName = "";
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = (control.ID).Split('|');
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            command = new SqlCommand($"SELECT Name FROM EarthquakeTeam WHERE Id = '{sendInfo[2]}' AND EarthquakeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    teamName = dr["Name"].ToString();
                }
            }
            dr.Close();
            command.Cancel();
            command = new SqlCommand($"DELETE FROM FilmInfo WHERE AccountId = '{teamName}' AND CreateDate " +
                  appPro.GetBetweenSignUpTime() + $" AND TeamType = 'Earthquake';", conn);
            command.ExecuteNonQuery();
            command.Cancel();

            command = new SqlCommand($"DELETE FROM EarthquakeTeam WHERE Id= '{sendInfo[2]}'", conn);
            command.ExecuteNonQuery();
            command.Cancel();
        }

        private HtmlGenericControl NewDiv(string classString)
        {
            HtmlGenericControl divEle = new HtmlGenericControl("DIV");
            divEle.Attributes.Add("class", classString);

            return divEle;
        }

    }
}