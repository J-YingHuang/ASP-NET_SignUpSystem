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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM Account WHERE Email = '{account.Value}' OR Username = '{account.Value}';");
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    loginSession.InnerText = "Login Account " + data["Username"].ToString() + " Finish!";
                    if (data["Password"].ToString().Trim() == password.Value)
                    {
                        //successful login

                    }
                    else
                        loginSession.InnerText = "Password is invaild!";
                }
                //Response.Redirect("~/Intro.aspx");
            }
            else
                loginSession.InnerText = "Login Error";

            conn.Close();
        }
    }
}


