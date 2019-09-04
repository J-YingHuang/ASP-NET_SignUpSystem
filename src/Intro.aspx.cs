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
            //讀抗震大作戰的隊伍資訊
            if (!IsPostBack)
            {
                if (Session["Login"] != null && Session["Login"].ToString() == "Y")
                    LoadAccountInfo();
                else
                    Response.Redirect("Login.aspx");
            }
            if (a_Earthquake.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Earthquake);
            if (a_Bridge.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Bridge);
            if (a_Film.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Film);
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
        private void addTeamCard(TeamType type, string teamName, string teamId, HtmlGenericControl parentControl)
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
                //確認是否可以新增隊伍
                //橋樑每個學校只能一隊
                string accountSchoolId = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand($"SELECT SchoolID FROM Account WHERE Id = '{Session["LoginId"]}';", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    accountSchoolId = dr["SchoolID"].ToString();

                dr.Close();
                command.Cancel();

                command = new SqlCommand($"SELECT Account.Name FROM BridgeTeam LEFT JOIN Account ON BridgeTeam.AccountID = Account.Id" +
                    $" WHERE Account.SchoolID = {accountSchoolId}", conn);
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    //有隊伍就不能新增
                    MsgBox_Data.InnerHtml = "<p>帳號所屬學校已報名一隊橋梁變變變隊伍，不得再進行本賽程報名！</p>";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#MsgBox').modal('show');", true);
                    LoadTeamByAccount(TeamType.Bridge);
                }
                else
                {
                    //去填橋梁變變變資料
                    Response.Redirect("BridgeRegistration.aspx");
                }
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
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = (control.ID).Split('|');
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            switch (sendInfo[0])
            {
                case "Earthquake":
                    command = new SqlCommand($"SELECT * FROM EarthquakeTeam WHERE Id = {sendInfo[2]}", conn);
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ViewEarthquakeInfo(dr);
                    }
                    dr.Close();
                    command.Cancel();
                    break;
                case "Bridge":
                    command = new SqlCommand($"SELECT * FROM BridgeTeam WHERE Id = {sendInfo[2]}", conn);
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ViewBridgeInfo(dr);
                    }
                    break;
                default:
                    command = new SqlCommand($"SELECT * FROM FilmInfo WHERE Id = {sendInfo[2]}", conn);
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ViewFilmInfo(dr);
                    }
                    break;
            }

            conn.Close();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#TeamViewer').modal('show');", true);

        }
        public void ViewEarthquakeInfo(SqlDataReader dr)
        {
            lab_TeamName.InnerText = dr["Name"].ToString();
            MemberInfo.InnerHtml = $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">素食人數：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["Vegetarian"].ToString()}  人</label>" +
                $"<div class=\"col-sm-2\"></div>" +
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
        public void ViewBridgeInfo(SqlDataReader dr)
        {
            lab_TeamName.InnerText = dr["Name"].ToString();
            MemberInfo.InnerHtml = $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">素食人數：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["Vegetarian"].ToString()}  人</label>" +
                $"<div class=\"col-sm-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<div class=\"col-8\"><hr /></div>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-4\"></div>" +
                $"<label class=\"col-sm-2 col-form-label\">隊員名字</label>" +
                $"<label class=\"col-sm-2 col-form-label\">身分證字號</label>" +
                $"<label class=\"col-sm-2 col-form-label\">生日</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";

            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                    $"<div class=\"col-2\"></div>" +
                    $"<label class=\"col-sm-2 col-form-label\">隊長</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"LeaderName"].ToString()}</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"LeaderID"].ToString()}</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"LeaderBirthday"].ToString().Replace(" 上午 12:00:00","")}</label>" +
                    $"<div class=\"col-2\" style=\"margin-right: 20px;\"></div>" +
                    $"</div>";

            for (int i = 1; i < Convert.ToInt32(dr["Count"]); i++)
            {
                MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                    $"<div class=\"col-2\"></div>" +
                    $"<label class=\"col-sm-2 col-form-label\">隊員{i}</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"PlayerName{i}"].ToString()}</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"PlayerID{i}"].ToString()}</label>" +
                    $"<label class=\"col-sm-2 col-form-label\">{dr[$"PlayerBirthday{i}"].ToString().Replace(" 上午 12:00:00", "")}</label>" +
                    $"<div class=\"col-2\" style=\"margin-right: 20px;\"></div>" +
                    $"</div>";
            }
        }
        public void ViewFilmInfo(SqlDataReader dr)
        {
            lab_TeamName.InnerText = dr["Name"].ToString();

            MemberInfo.InnerHtml = $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">設計理念：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["DesignConcept"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";
            MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                $"<div class=\"col-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">故事大綱：</label>" +
                $"<label class=\"col-sm-4 col-form-label\">{dr["Outline"].ToString()}</label>" +
                $"<div class=\"col-2\"></div>" +
                $"</div>";

            if(dr["FileLink"].ToString() != "")
            {
                MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                    $"<div class=\"col-2\"></div>" +
                    $"<label class=\"col-sm-4 col-form-label\">作品連結：</label>" +
                    $"<label class=\"col-sm-4 col-form-label\">" +
                    $"<a href=\"{dr["FileLink"].ToString()}\">{dr["FileLink"].ToString()}</a>" +
                    $"</label>" +
                    $"<div class=\"col-2\"></div>" +
                    $"</div>";
            }
            else
            {
                MemberInfo.InnerHtml += $"<div class=\"form-group row \">" +
                    $"<div class=\"col-2\"></div>" +
                    $"<label class=\"col-sm-4 col-form-label\">作品連結：</label>" +
                    $"<label class=\"col-sm-4 col-form-label\">尚未繳交</label>" +
                    $"<div class=\"col-2\"></div>" +
                    $"</div>";
            }
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