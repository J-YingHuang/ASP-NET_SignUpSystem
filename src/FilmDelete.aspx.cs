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
    public partial class FilmDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if ((Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y") == false)
                    Response.Redirect("ManagerLogin.aspx");

            LoadTeamByAccount();

        }

        private void LoadTeamByAccount()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT FilmInfo.Name AS teamName,FilmInfo.Id AS teamid,School.Name AS SchoolName FROM FilmInfo LEFT JOIN Account ON FilmInfo.AccountID = Account.Id " +
                 $"LEFT JOIN School ON Account.SchoolID=School.Id", conn);
            SqlDataReader dataReader = command.ExecuteReader();


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    IDataRecord record = (IDataRecord)dataReader;
                    string teamName = record["teamName"].ToString();
                    string SchoolName = record["SchoolName"].ToString();
                    string teamID = record["teamid"].ToString();
                    AddTeamCard(teamName, SchoolName, teamID, div1);
                }


            }
            conn.Close();
        
    }

        private void AddTeamCard(string teamName, string schoolName, string teamID, HtmlGenericControl div1)
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
            viewBtnA.ID = "Account" + "|View|" + teamID;
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
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = (control.ID).Split('|');
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            command = new SqlCommand($"DELETE  FROM FilmInfo WHERE Id= '{sendInfo[2]}'", conn);
            dr = command.ExecuteReader();
        }

        private HtmlGenericControl NewDiv(string classString)
        {
            HtmlGenericControl divEle = new HtmlGenericControl("DIV");
            divEle.Attributes.Add("class", classString);

            return divEle;
        }
    }
}