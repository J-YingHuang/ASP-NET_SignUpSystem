using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SignUpSystem
{
    public partial class AccountAddin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
               
            }
            LoadInSchoolSelectData();




        }

        private void LoadInSchoolSelectData()
        {
            DropDownList1.Items.Clear();

            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand da = new SqlCommand("SELECT Name FROM School ", conn);
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
                DropDownList1.Items.Add(dr["Name"].ToString());
            dr.Close();
            da.Cancel();


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string SchoolID = "";
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT Id FROM School WHERE Name='{ DropDownList1.Items[DropDownList1.SelectedIndex].Text}'", conn);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SchoolID=dr["Id"].ToString();
                }
            }
            dr.Close();
            command.Cancel();

            command = new SqlCommand("INSERT INTO Account (Username,Password,Name,Phone,Email,IsVegetarian,SchoolID)" +
                "values (@Username,@Password,@Name,@Phone,@Email,@IsVegetarian,@SchoolID)", conn);
            command.Parameters.AddWithValue(@"Username", UsernameInput.Value);
            command.Parameters.AddWithValue(@"Password", PasswordInput.Value);
            command.Parameters.AddWithValue(@"Name", NameInput.Value);
            command.Parameters.AddWithValue(@"Phone", PhoneInput.Value);
            command.Parameters.AddWithValue(@"Email", EmailInput.Value);
            if(inlineRadio1.Checked)
                command.Parameters.AddWithValue(@"IsVegetarian", "true");
            else
                command.Parameters.AddWithValue(@"IsVegetarian", "false");
            command.Parameters.AddWithValue(@"SchoolID", SchoolID);
            command.ExecuteNonQuery();
            

            MailMessage msg = new MailMessage();
            string lineSymbol = "<br />";
            // 寄信人資料 wix email & show name
            msg.From = new MailAddress("civilkuas@gmail.com", "國立高雄科技大學土木工程系", System.Text.Encoding.UTF8);
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            //email title
            msg.Subject = "抗震大作戰教師帳號申請確認函";

            //send object
            msg.To.Add(EmailInput.Value.ToString());

            // Email content
            msg.Body = NameInput.Value + "老師您好"+ lineSymbol +
                        "已為您開通抗震大作戰帳號，煩請您前往本次報名系統網站進行帳號登入確認帳號內容，若有問題請盡速聯繫我們！" + lineSymbol+
                        "報名系統網站：htttp：//203.64.97.214/"+ lineSymbol+
                        "本次賽程報名開放時間：2019/09/30 18：00～2019/10/14 18：00"+ lineSymbol+
                        "國立高雄科技大學 土木工程系 敬上";

            SmtpClient client = new SmtpClient();
            //wix gmail username & password
            client.Credentials = new NetworkCredential("civilkuas@gmail.com", "Kuascivil2017");
            client.Host = "smtp.gmail.com";
            client.Port = 25;
            client.EnableSsl = true;
            client.Send(msg);
            client.Dispose();
            msg.Dispose();
            Response.Redirect("~/BackgroundDataManagement.aspx");
        }

        protected void btn_AddSchool_Click(object sender, EventArgs e)
        {


            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO School  values (@Schoolname,@Address,@Area)", conn);
            command.Parameters.AddWithValue(@"Schoolname", School_name.Value);
            command.Parameters.AddWithValue(@"Address", Address.Value);
            command.Parameters.AddWithValue(@"Area", Area.Value);
            command.ExecuteNonQuery();
            


        }
    }
}