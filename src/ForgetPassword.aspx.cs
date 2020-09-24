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
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_ForgetPassword_Click(object sender, EventArgs e)
        {

            Response.Redirect("ForgetPassword.aspx");
        }

        protected void btn_SendEmail_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            // * = 萬用字元
            SqlCommand command = new SqlCommand($"SELECT Email, Password FROM Account WHERE Email = '{email_name.Value.ToString()}';", conn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    IDataRecord data = (IDataRecord)dr;
                    serch_email.InnerText = "Login Account " + data["Email"].ToString() + " Finish!";


                    MailMessage msg = new MailMessage();
                    string lineSymbol = "<br />";
                    // 寄信人資料 wix email & show name
                    msg.From = new MailAddress("civilkuas@gmail.com", "國立高雄科技大學土木工程系", System.Text.Encoding.UTF8);
                    msg.SubjectEncoding = Encoding.UTF8;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;

                    //email title
                    msg.Subject = "第15屆抗震大作戰報名系統登入密碼";

                    //send object
                    msg.To.Add(email_name.Value.ToString());

                    // Email content
                    msg.Body = "您好,已確定此為已註冊帳號,以下為您的登入密碼:" + lineSymbol
                                + data["Password"].ToString() + lineSymbol+
                               "請再回登入頁面輸入一次帳號及密碼," + lineSymbol+
                               "若有相關問題歡迎聯絡我們" + lineSymbol +
                               lineSymbol +
                               lineSymbol +
                                "國立高雄科技大學土木工程系 蔡宛蓁小姐 07-3814526#15200";

                    SmtpClient client = new SmtpClient();
                    //wix gmail username & password
                    client.Credentials = new NetworkCredential("civilkuas@gmail.com", "Kuascivil2017");
                    client.Host = "smtp.gmail.com";
                    client.Port = 25;
                    client.EnableSsl = true;
                    client.Send(msg);
                    client.Dispose();
                    msg.Dispose();
                }


            }
            else
                serch_email.InnerText = "沒有此Email";
            dr.Close();
            command.Cancel();
            conn.Close();
        }
    }
}