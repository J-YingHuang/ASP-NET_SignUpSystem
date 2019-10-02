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
using System.Web.UI.HtmlControls;

namespace SignUpSystem
{
    public partial class EearthquakeModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTeamByAccount();
        }
        private void LoadTeamByAccount()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT Name FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID=Account.Id"+$"SELECT Name FROM School LEFT JOIN School ON Account.SchoolID=School.Id", conn);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                IDataRecord record = (IDataRecord)dataReader;
                string teamName = record[2].ToString();
                string teamId = record[24].ToString();
                AddTeamCard( teamName, teamId, div1);
            }


        }
            private void AddTeamCard( string teamName, string teamId, HtmlGenericControl div1)
        {
            HtmlGenericControl cardDiv = NewDiv("card");
            cardDiv.Attributes.Add("style", "margin-bottom: 10px;");
            HtmlGenericControl cardBodyDiv = NewDiv("card-body");
            cardBodyDiv.Attributes.Add("style", "text-align: left;");
            HtmlGenericControl rowDiv = NewDiv("row");
            HtmlGenericControl rolEditDiv = NewDiv("col-7");
            HtmlGenericControl editName = new HtmlGenericControl("H6");
            editName.Attributes.Add("style", "margin-top: 5px;");
            editName.InnerText = teamName;
            HtmlGenericControl ColFiveDiv = NewDiv("col-5");
            HtmlAnchor viewBtnA = new HtmlAnchor();
            viewBtnA.ID = "Earthquake" + "|View|" + teamId;
            viewBtnA.Attributes.Add("class", "btn btn-outline-secondary float-right");
            viewBtnA.Attributes.Add("style", "height: 32px; font-size: 12px; margin-right: 5px; width: 70px;");
            viewBtnA.Attributes.Add("runat", "server");
            viewBtnA.Attributes.Add("onClick", "return true;");
            viewBtnA.Attributes.Add("onserverclick", "TeamView");
            viewBtnA.ServerClick += new EventHandler(TeamView);
            HtmlGenericControl viewImg = new HtmlGenericControl("IMG");
            viewImg.Attributes.Add("width", "15px");
            viewImg.Attributes.Add("style", "margin-bottom: 4px;");
            viewImg.Attributes.Add("src", "https://img.icons8.com/ios-glyphs/24/000000/visible.png");
            HtmlGenericControl viewSpan = new HtmlGenericControl("SPAN");
            viewSpan.InnerText = "View";

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
            throw new NotImplementedException();
        }

        protected void btn_updateAccount_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"UPDATE EquakeTeam SET Name = '{Div2.Value.ToString()}', SecondTeacher = '{updatesecondteacher.Value.ToString()}'  FORM EarthquakeTeam", conn);
            command.ExecuteNonQuery();
            conn.Close();

            //LoadAccountInfo();
        }
        public void ViewEarthquakeInfo(SqlDataReader dr)
        {
            Div2.Value = dr["Name"].ToString();
            MemberInfo.InnerHtml = $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">素食人數：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["Vegetarian"].ToString()}  人</label>" +
                $"<div class=\"col-sm-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">共同指導老師：</label>";

            if (dr["SecondTeacher"].ToString() != "")
                MemberInfo.InnerHtml += $"<label class=\"col-sm-4 col-form-label\">{dr["SecondTeacher"].ToString()}</label>";
            else
                MemberInfo.InnerHtml += $"<label class=\"col-sm-4 col-form-label\">無</label>";

            MemberInfo.InnerHtml += $"<div class=\"col-sm-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">隊長姓名：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["LeaderName"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";

            for (int i = 1; i < Convert.ToInt32(dr["Count"]); i++)
            {
                MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">隊員{i}姓名：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr[$"PlayerName{i}"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";
            }
        }

        protected void btn_ModifyTeam_Click(object sender, EventArgs e)
        {

        }
        public HtmlGenericControl NewDiv(string classString)
        {
            HtmlGenericControl divEle = new HtmlGenericControl("DIV");
            divEle.Attributes.Add("class", classString);

            return divEle;
        }
    }
}