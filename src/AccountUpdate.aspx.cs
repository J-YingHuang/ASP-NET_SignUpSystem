using DataProcessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class AccountUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ManageLogin"] != null && Session["ManageLogin"].ToString() == "Y")
                    InitLoad();
                else
                    Response.Redirect("~/ManagerLogin.aspx");
            }
        }

        private void InitLoad()
        {
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command;
            SqlDataReader dr;
            string queryCommand = $"SELECT Account.Name, Account.Username, Account.Password, " +
                $"Account.Phone, Account.Email, Account.Id, SchoolID  FROM Account WHERE Id = '{Session["UpdateId"].ToString()}'";

            command = new SqlCommand(queryCommand + ";", conn);
            dr = command.ExecuteReader();
            string accountSchoolId = "";
            while (dr.Read())
            {
                input_Username.Value = dr["Username"].ToString();
                Text1.Value = dr["Password"].ToString();
                input_Name.Value = dr["Name"].ToString();
                Text2.Value = dr["Phone"].ToString();
                Text3.Value = dr["Email"].ToString();
                accountSchoolId = dr["SchoolID"].ToString();
                Text5.Value = dr["Id"].ToString();
            }
            dr.Close();
            command.Cancel();

            command = new SqlCommand($"SELECT Id, Name FROM School;", conn);
            dr = command.ExecuteReader();
            int accountIndex = 0;
            while (dr.Read())
            {
                Select_School.Items.Add(dr["Name"].ToString());
                if (dr["Id"].ToString() == accountSchoolId)
                {
                    accountIndex = Select_School.Items.Count - 1;
                }
            }
            dr.Close();
            command.Cancel();
            conn.Close();

            //設定選擇的SchoolName
            Select_School.SelectedIndex = accountIndex;
        }
        protected void btn_Close_ServerClick(object sender, EventArgs e)
        {
            Session["UpdateId"] = null;
            Response.Redirect("~/BackgroundDataManagement.aspx");
        }
        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            string Email = "[a - zA - Z0 - 9._ % -] +@[a-zA-Z0-9._%-]+.[a-zA-Z]{2,4}";
            if (!Regex.IsMatch(Text3.Value,Email))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();
                SqlDataReader dr;
               
                SqlCommand command = new SqlCommand($"SELECT Id FROM School WHERE Name = '{Select_School.Items[Select_School.SelectedIndex].Text}';", conn);
                dr = command.ExecuteReader();
                string newSchoolId = "";
                while (dr.Read())
                {
                    newSchoolId = dr["Id"].ToString();
                }
                command.Cancel();
                conn.Close();

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();
                string commandString = $"UPDATE Account SET Email = '{ Text3.Value}',Username='{input_Username.Value}',Password='{Text1.Value}',Name='{input_Name.Value}',Phone='{Text2.Value}',SchoolID = '{newSchoolId}'  WHERE Id='{Text5.Value}'";
                command = new SqlCommand(commandString, conn);
                command.ExecuteNonQuery();

                command.Cancel();
                dr.Close();
                conn.Close();
                
              



                Response.Redirect("BackgroundDataManagement.aspx");
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closepup", "$('#Modal_ErrMsg').modal('show');", true);
            }
        }
        }
    }

       
    
