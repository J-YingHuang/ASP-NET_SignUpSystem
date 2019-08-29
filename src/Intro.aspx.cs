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
    public partial class Intro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //補Session
            //if (Session["Login"] == null)
            //    Session["Login"] = "Y";
            //if (Session["LoginId"] == null)
            //    Session["LoginId"] = "1";

            //讀抗震大作戰的隊伍資訊
            if (!IsPostBack)
            {
                LoadAccountInfo();
            }
            if(a_Earthquake.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Earthquake);
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
            div_TeamInfo.InnerHtml = "";
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
                    //舊寫法
                    //innerHtmlStr += "<div class=\"card\">"
                    //    + "<div class=\"card-body\" style=\"text-align: left; \">"
                    //    + "<div class=\"row\">"
                    //    + "<div class=\"col-7\">"
                    //    + "<h6 style=\"margin-top: 5px;\">" + teamName + "</h6>"
                    //    + "</div><div class=\"col-5 \">"
                    //    + "<a id=\"" + teamId + "\" class=\"btn btn-outline-secondary float-right\" style=\"height: 32px; font-size: 12px; width: 70px;\" runat=\"server\" onserverclick=\"teamEdit\">"
                    //    + "<img width=\"15px\" style=\"margin-bottom: 4px;\" src=\"https://img.icons8.com/ios-glyphs/64/000000/edit.png \">"
                    //    + "<span>Edit</span>"
                    //    + "</a>"
                    //    + "<a id=\"view_team1\" class=\"btn btn-outline-secondary float-right\" style=\"height: 32px; font-size: 12px; margin-right: 5px; width: 70px;\" runat=\"server\" onserverclick=\"teamView\">"
                    //    + "<img width=\"15px\" style=\"margin-bottom: 4px;\" src=\"https://img.icons8.com/ios-glyphs/24/000000/visible.png \">"
                    //    + "<span>View</span>"
                    //    + "</a>"
                    //    + "</div></div></div></div>";
                    addTeamCard(type, teamName, teamId, div_TeamInfo);
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
                div_TeamInfo.InnerHtml = innerHtmlStr;
            }
            conn.Close();
        }
        private void addTeamCard(TeamType type,string teamName, string teamId, HtmlGenericControl parentControl)
        {
            HtmlGenericControl cardDiv = NewDiv("card");
            HtmlGenericControl cardBodyDiv = NewDiv("card-body");
            cardBodyDiv.Attributes.Add("style", "text-align: left;");
            HtmlGenericControl rowDiv = NewDiv("row");
            HtmlGenericControl rolEditDiv = NewDiv("col-7");
            HtmlGenericControl editName = new HtmlGenericControl("H6");
            editName.Attributes.Add("style", "margin-top: 5px;");
            editName.InnerText = teamName;
            HtmlGenericControl ColFiveDiv = NewDiv("col-5");
            HtmlAnchor editBtnA = new HtmlAnchor();
            editBtnA.ID = type.ToString() + "|Edit|" + teamId;
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
            HtmlAnchor viewBtnA = new HtmlAnchor();
            viewBtnA.ID = type.ToString() + "|View|" + teamId;
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
            ColFiveDiv.Controls.Add(editBtnA);
            editBtnA.Controls.Add(editImg);
            editBtnA.Controls.Add(editSpan);
            ColFiveDiv.Controls.Add(viewBtnA);
            viewBtnA.Controls.Add(viewImg);
            viewBtnA.Controls.Add(viewSpan);

            parentControl.Controls.Add(cardDiv);
        }
        public HtmlGenericControl NewDiv(string classString)
        {
            HtmlGenericControl divEle = new HtmlGenericControl("DIV");
            divEle.Attributes.Add("class", classString);

            return divEle;
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
            SqlCommand command = new SqlCommand($"SELECT * FROM Account WHERE Id = {Session["LoginId"]};", conn);
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
        protected void Btn_updateAccount_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"UPDATE Account SET Phone = '{updatePhone.Value.ToString()}', Email = '{updateEmail.Value.ToString()}' WHERE Id = {Session["LoginId"]}", conn);
            command.ExecuteNonQuery();
            conn.Close();

            LoadAccountInfo();
        }
        protected void TeamEdit(object sender, EventArgs e)
        {
            //去隊伍編輯的頁面
            //HtmlAnchor control = (HtmlAnchor)sender;
            //String sendInfo = control.ID;
        }
        protected void TeamView(object sender, EventArgs e)
        {
            //去查看隊伍資訊的頁面
            //HtmlAnchor control = (HtmlAnchor)sender;
            //String sendInfo = control.ID;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            //登出
            Session["Login"] = "N";
            Session["LoginId"] = "Null";
            Response.Redirect("Default.aspx");
        }
    }
    enum TeamType
    {
        Earthquake,
        Bridge,
        Film
    }
}