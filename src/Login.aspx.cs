using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;

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

            SqlCommand command = new SqlCommand($"SELECT * FROM Account WHERE Email = '{account.Value}' OR Username = '{account.Value}';", conn);
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    loginSession.InnerText = "信箱確認,請至Email收取信件!";
                    if (data["Password"].ToString() == password.Value)
                    {
                        //successful login
                        Session["Lonin"] = "Y";
                        Session["LoginId"] = data["Id"].ToString();
                        Response.Redirect("Intro.aspx");
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

        protected void btn_ForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgetPassword.aspx");
        }
    }
    }



