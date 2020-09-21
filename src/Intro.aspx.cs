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
using DataProcessing;

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
            update_AppData();
            if (a_Earthquake.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Earthquake);
            if (a_Bridge.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Bridge);
            if (a_Film.Attributes["class"].Contains("active"))
                LoadTeamByAccount(TeamType.Film);
        }
        private void update_AppData()
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            DateTime startTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.StartSignUp));
            DateTime endTime = Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndSignUp));
            if (!(DateTime.Now >= startTime && DateTime.Now <= endTime))
                btn_NewTeam.Enabled = false;

            a_Earthquake.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName);
            a_Bridge.InnerText = appPro.GetApplicationString(BaseInfo.BridgeName);
            a_Film.InnerText = appPro.GetApplicationString(BaseInfo.FilmName);
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
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            div_TeamInfo.InnerHtml = "";
            //Loading Team Function
            //Connect to SQL DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand();

            switch (type)
            {
                case TeamType.Earthquake:
                    command = new SqlCommand($"SELECT Id, Name FROM EarthquakeTeam WHERE AccountID = {Session["LoginId"]} AND (CreateDate " +
                        appPro.GetBetweenSignUpTime() + ")", conn);
                    break;
                case TeamType.Bridge:
                    command = new SqlCommand($"SELECT Id, Name FROM BridgeTeam WHERE AccountID = {Session["LoginId"]} AND (CreateDate " +
                        appPro.GetBetweenSignUpTime() + ")", conn);
                    break;
                case TeamType.Film:
                    command = new SqlCommand($"SELECT Id, Name, FileLink FROM FilmInfo WHERE AccountID = {Session["LoginId"]} AND (CreateDate " +
                        appPro.GetBetweenSignUpTime() +
                        $")", conn);
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
                    bool hasUpdate = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndUpdateInfo));
                    bool hasUpdateLink = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndFilmUpdate));
                    if (type == TeamType.Film)
                    {
                        if (record["FileLink"].ToString() == "")
                            AddFilmTeamCard(teamName, teamId, div_TeamInfo, false, hasUpdate, hasUpdateLink);
                        else
                            AddFilmTeamCard(teamName, teamId, div_TeamInfo, true, hasUpdate, hasUpdateLink);
                    }
                    else
                        AddTeamCard(type, teamName, teamId, div_TeamInfo, hasUpdate);
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
        private void AddTeamCard(TeamType type, string teamName, string teamId, HtmlGenericControl parentControl, bool hasUpdate)
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

            if (hasUpdate)
            {
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

                ColFiveDiv.Controls.Add(editBtnA);
                editBtnA.Controls.Add(editImg);
                editBtnA.Controls.Add(editSpan);
            }

            cardDiv.Controls.Add(cardBodyDiv);
            cardBodyDiv.Controls.Add(rowDiv);
            rowDiv.Controls.Add(rolEditDiv);
            rolEditDiv.Controls.Add(editName);
            rowDiv.Controls.Add(ColFiveDiv);
            ColFiveDiv.Controls.Add(viewBtnA);
            viewBtnA.Controls.Add(viewImg);
            viewBtnA.Controls.Add(viewSpan);

            parentControl.Controls.Add(cardDiv);
        }
        private void AddFilmTeamCard(string teamName, string teamId, HtmlGenericControl parentControl, bool hasLink, bool hasUpdate, bool hasUpdateLink)
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
            viewBtnA.ID = "Film|View|" + teamId;
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

            if (hasUpdateLink)
            {
                HtmlAnchor linkBtnA = new HtmlAnchor();
                linkBtnA.ID = "Film|Link|" + teamId;
                linkBtnA.Attributes.Add("class", "btn btn-outline-secondary float-right");
                linkBtnA.Attributes.Add("style", "height: 32px; font-size: 12px; margin-left: 5px; width: 90px;");
                linkBtnA.Attributes.Add("runat", "server");
                linkBtnA.Attributes.Add("onClick", "return true;");
                linkBtnA.Attributes.Add("onserverclick", "TeamLink");
                linkBtnA.ServerClick += new EventHandler(TeamLink);
                HtmlGenericControl linkImg = new HtmlGenericControl("IMG");
                linkImg.Attributes.Add("width", "15px");
                linkImg.Attributes.Add("style", "margin-bottom: 4px;");
                linkImg.Attributes.Add("src", "https://img.icons8.com/windows/32/000000/link.png");
                HtmlGenericControl linkSpan = new HtmlGenericControl("SPAN");
                if (!hasLink)
                {
                    linkSpan.InnerText = "繳交作品";
                    AddLinkTitle.InnerText = "繳交作品";
                }
                else
                {
                    linkSpan.InnerText = "更新作品";
                    AddLinkTitle.InnerText = "更新作品";
                }

                ColFiveDiv.Controls.Add(linkBtnA);
                linkBtnA.Controls.Add(linkImg);
                linkBtnA.Controls.Add(linkSpan);
            }

            if (hasUpdate)
            {
                HtmlAnchor editBtnA = new HtmlAnchor();
                editBtnA.ID = "Film|Edit|" + teamId;
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
            }
            cardDiv.Controls.Add(cardBodyDiv);
            cardBodyDiv.Controls.Add(rowDiv);
            rowDiv.Controls.Add(rolEditDiv);
            rolEditDiv.Controls.Add(editName);
            rowDiv.Controls.Add(ColFiveDiv);
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
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            if (a_Earthquake.Attributes["class"].Contains("active"))
            {
                //確認是否可以新增隊伍
                //抗震是一校六隊
                string accountSchoolId = "";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand($"SELECT SchoolID FROM Account WHERE Id = '{Session["LoginId"]}';", conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    accountSchoolId = dr["SchoolID"].ToString();

                dr.Close();
                command.Cancel();

                command = new SqlCommand($"SELECT Count(*) AS Count FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id" +
                    $" WHERE Account.SchoolID = {accountSchoolId}" +
                    $"AND EarthquakeTeam.CreateDate {appPro.GetBetweenSignUpTime()}", conn);
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    if(Convert.ToInt32(dr["Count"]) == 6)
                    {
                        //有隊伍就不能新增
                        MsgBox_Data.InnerHtml = $"<p>帳號所屬學校已報名六隊" +
                            appPro.GetApplicationString(BaseInfo.EarthquakeName) +
                            $"隊伍，不得再進行本賽程報名！</p>";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#MsgBox').modal('show');", true);
                        LoadTeamByAccount(TeamType.Bridge);
                    }
                    else
                    {
                        //去填抗震盃報名資料
                        Response.Redirect("EarthquakeRegistration.aspx");
                    }
                }

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
                    $" WHERE Account.SchoolID = {accountSchoolId}" +
                    $"AND BridgeTeam.CreateDate {appPro.GetBetweenSignUpTime()}", conn);
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    //有隊伍就不能新增
                    MsgBox_Data.InnerHtml = $"<p>帳號所屬學校已報名一隊" +
                        appPro.GetApplicationString(BaseInfo.BridgeName) +
                        $"隊伍，不得再進行本賽程報名！</p>";
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
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();

                List<string> earList = new List<string>();
                List<string> briList = new List<string>();

                //先抓抗震的
                SqlCommand command = new SqlCommand($"SELECT Name FROM EarthquakeTeam WHERE AccountID = {Session["LoginId"].ToString()}" +
                    $" AND CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    earList.Add(dr["Name"].ToString());
                dr.Close();
                command.Cancel();

                //抓橋梁的
                command = new SqlCommand($"SELECT Name FROM BridgeTeam WHERE AccountID = {Session["LoginId"].ToString()}" +
                    $" AND CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                    briList.Add(dr["Name"].ToString());
                dr.Close();
                command.Cancel();

                //確認微電影報了沒有
                command = new SqlCommand($"SELECT Name, TeamType FROM FilmInfo WHERE AccountID = {Session["LoginId"].ToString()}" +
                    $" AND CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["TeamType"].ToString() == "Eqrthquake")
                        earList.Remove(dr["Name"].ToString());
                    else
                        briList.Remove(dr["Name"].ToString());
                }
                dr.Close();
                command.Cancel();

                if(earList.Count == 0 && briList.Count == 0)
                {
                    MsgBox_Data.InnerHtml = $"<p>帳號中" +
                        appPro.GetApplicationString(BaseInfo.EarthquakeName) +
                        $"與" +
                        appPro.GetApplicationString(BaseInfo.BridgeName) +
                        $"皆已參加" +
                        appPro.GetApplicationString(BaseInfo.FilmName) +
                        $"賽程！</p>";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#MsgBox').modal('show');", true);
                    LoadTeamByAccount(TeamType.Bridge);
                }
                else
                {
                    Response.Redirect("FilmRegistration.aspx");
                }
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
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = control.ID.Split('|');

            Session["UpdateId"] = sendInfo[2];
            switch (sendInfo[0].ToString())
            {
                case "Earthquake":
                    Response.Redirect("EarthquakeUpdate.aspx");
                    break;
                case "Bridge":
                    Response.Redirect("BridgeUpdate.aspx");
                    break;
                default:
                    Response.Redirect("FilmUpdate.aspx");
                    break;
            }
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

        protected void TeamLink(object  sender, EventArgs e)
        {
            //去查看隊伍資訊的頁面
            HtmlAnchor control = (HtmlAnchor)sender;
            string[] sendInfo = (control.ID).Split('|');
            Session["AddLink"] = sendInfo[2];
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Msg_AddLink').modal('show');", true);
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

            MemberInfo.InnerHtml += $"<div class=\"form-group row\">" +
                $"<div class=\"col-sm-2\"></div>" +
                $"<label class=\"col-sm-4 col-form-label\">共同指導老師：</label>";

            if(dr["SecondTeacher"].ToString() != "")
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
        public void ViewBridgeInfo(SqlDataReader dr)
        {
            lab_TeamName.InnerText = dr["Name"].ToString();
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

        protected void btn_AddFilmLink_ServerClick(object sender, EventArgs e)
        {
            //空的連結就不處理了 -.-
            if (FilmLink.Value == "")
                return;

            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            //有連結就更新資料
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"UPDATE FilmInfo SET FileLink = '{FilmLink.Value}' WHERE Id = '{Session["AddLink"].ToString()}'" +
                $" AND CreateDate " +
                appPro.GetBetweenSignUpTime(), conn);
            command.ExecuteNonQuery();
            command.Cancel();
            conn.Close();

            //Init something
            FilmLink.Value = "";
            Session["AddLink"] = null;

            LoadTeamByAccount(TeamType.Film);
        }
    }
    enum TeamType
    {
        Earthquake,
        Bridge,
        Film
    }
}