using System;
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

        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command;
            if (account.Value.Contains("@"))
            {
                //登入使用Email
                command = new SqlCommand("SELECT * FROM Account WHERE Email = '" + account.Value + "';", conn);
            }
            else
            {
                //登入使用UserName
                command = new SqlCommand("SELECT * FROM Account WHERE Username = '" + account.Value + "';", conn);
            }
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    loginSession.InnerText = "Login Account " + data["Username"].ToString() + " Finish!";
                }
                //Response.Redirect("~/Intro.aspx");
            }
            else
                loginSession.InnerText = "Login Error";

            conn.Close();
        }
    }
}