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

        }


        private void LoadTeamByAccount(TeamType type)
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT Id, Name FROM EarthquakeTeam WHERE AccountID =  AND (CreateDate " +
                        appPro.GetBetweenSignUpTime() + ")", conn);
            SqlDataReader dataReader = command.ExecuteReader();
            string innerHtmlStr = "";
            if (dataReader.HasRows)
            {


                IDataRecord record = (IDataRecord)dataReader;
                string teamName = record["Name"].ToString();
                string teamId = record["Id"].ToString();
                bool hasUpdate = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndUpdateInfo));
                bool hasUpdateLink = DateTime.Now <= Convert.ToDateTime(appPro.GetApplicationString(BaseInfo.EndFilmUpdate));


            }
            else
            {
                innerHtmlStr += "<div class=\"card\">"
                    + "<div class=\"card-body\" style=\"color: dimgray; text-align: center; \">"
                    + "<div class=\"row\">"
                    + "<div class=\"col-12\" style=\"margin-top: 5px; \">"
                    + "<h6>尚未開始報名</h6>"
                    + "</div></div></div></div>";
                //div_TeamInfo.InnerHtml = innerHtmlStr;
            }
            conn.Close();
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            //登出
            Session["Login"] = "N";
            Session["LoginId"] = "Null";
            Response.Redirect("BackgroundDataManagement.aspx");
        }

        protected void btn_NewTeam_Click(object sender, EventArgs e)
        {

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
    }
}