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
    public partial class BridgeModify_aspx : System.Web.UI.Page
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
            SqlCommand command = new SqlCommand($"SELECT BridgeTeam.Name AS teamName,BridgeTeam.Id AS teamid,School.Name AS SchoolName FROM BridgeTeam LEFT JOIN Account ON BridgeTeam.AccountID = Account.Id " +
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

        private void AddTeamCard(string teamName, string SchoolName, string teamID, HtmlGenericControl div1)
        {
            HtmlGenericControl cardDiv = NewDiv("card");
            cardDiv.Attributes.Add("style", "margin-bottom: 10px;");
            HtmlGenericControl cardBodyDiv = NewDiv("card-body");
            cardBodyDiv.Attributes.Add("style", "text-align: left;");
            HtmlGenericControl rowDiv = NewDiv("row");
            HtmlGenericControl rolEditDiv = NewDiv("col-7");
            HtmlGenericControl editName = new HtmlGenericControl("H6");
            editName.Attributes.Add("style", "margin-top: 5px;");
            editName.InnerText = teamName + "," + SchoolName;
            HtmlGenericControl ColFiveDiv = NewDiv("col-5");
            HtmlAnchor viewBtnA = new HtmlAnchor();
            viewBtnA.ID = "Earthquake" + "|View|" + teamID;
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

            HtmlAnchor editBtnA = new HtmlAnchor();
            editBtnA.ID = "Earthquake" + "|Edit|" + teamID;
            editBtnA.Attributes.Add("class", "btn btn-outline-secondary float-right");
            editBtnA.Attributes.Add("style", "height: 32px; font-size: 12px; width: 70px;");
            editBtnA.Attributes.Add("runat", "server");
            editBtnA.Attributes.Add("onClick", "return true;");
            editBtnA.Attributes.Add("onserverclick", "TeamEdit");
            editBtnA.ServerClick += new EventHandler(TeamEdit);
            HtmlGenericControl editImg = new HtmlGenericControl("IMG");
            editImg.Attributes.Add("width", "15px");
            editImg.Attributes.Add("style", "margin-bottom: 4px;");
            editImg.Attributes.Add("src", "https://img.icons8.com/ios-glyphs/64/000000/edit.png");
            HtmlGenericControl editSpan = new HtmlGenericControl("SPAN");
            editSpan.InnerText = "Edit";

            ColFiveDiv.Controls.Add(editBtnA);
            editBtnA.Controls.Add(editImg);
            editBtnA.Controls.Add(editSpan);


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

        private HtmlGenericControl NewDiv(string classString)
        {
            HtmlGenericControl divEle = new HtmlGenericControl("DIV");
            divEle.Attributes.Add("class", classString);

            return divEle;
        }

        private void TeamView(object sender, EventArgs e)
        {
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = (control.ID).Split('|');
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            command = new SqlCommand($"SELECT * FROM BridgeTeam ", conn);
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                ViewBridgeInfo(dr);
            }
            dr.Close();
            command.Cancel();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#TeamView').modal('show');", true);
        }

        private void ViewBridgeInfo(SqlDataReader dr)
        {
            Div2.InnerHtml = dr["Name"].ToString();
            MemberInfo.InnerHtml = $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-5 col-form-label\">素食人數：</label>" +
                $"<label class=\"col-sm-5 col-form-label\">{dr["Vegetarian"].ToString()}  人</label>" +
                $"<div class=\"col-sm-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-6 col-form-label\">共同指導老師：</label>";

            if (dr["SecondTeacher"].ToString() != "")
                MemberInfo.InnerHtml += $"<label class=\"col-sm-5 col-form-label\">{dr["SecondTeacher"].ToString()}</label>";
            else
                MemberInfo.InnerHtml += $"<label class=\"col-sm-4 col-form-label\">無</label>";

            MemberInfo.InnerHtml += $"<div class=\"col-sm-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-5 col-form-label\">隊長姓名：</label>" +
                $"<label class=\"col-sm-5 col-form-label\">{dr["LeaderName"].ToString()}</label>" +
                $"<label class=\"col-sm-5 col-form-label\">隊長生日：</label>" +
                $"<label class=\"col-sm-5 col-form-label\">{dr["LeaderBirthday"].ToString()}</label>" +
                $"<label class=\"col-sm-5 col-form-label\">隊長身分證字號：</label>" +
                $"<label class=\"col-sm-5 col-form-label\">{dr["LeaderID"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";

            for (int i = 1; i < Convert.ToInt32(dr["Count"]); i++)
            {
                MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-6 col-form-label\">隊員{i}姓名：</label>" +
                $"<label class=\"col-sm-6 col-form-label\">{dr[$"PlayerName{i}"].ToString()}</label>" +
                $"<label class=\"col-sm-6 col-form-label\">隊員{i}生日：</label>"+
                $"<label class=\"col-sm-6 col-form-label\">{dr[$"PlayerBirthday{i}"].ToString()}</label>" +
                $"<label class=\"col-sm-5 col-form-label\">>隊員{i}身分證字號：</label>" +
                $"<label class=\"col-sm-5 col-form-label\">{dr[$"PlayerID{i}"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";
            }
            }

        private void TeamEdit(object sender, EventArgs e)
        {
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = control.ID.Split('|');
            Session["UpdateId"] = sendInfo[2];
            Response.Redirect("BridgeUpdate.aspx");
        }
    }
}