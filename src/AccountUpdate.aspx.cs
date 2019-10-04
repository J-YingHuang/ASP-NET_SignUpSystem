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
                    Response.Redirect("Login.aspx");
                ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                lab_Title.InnerText = appPro.GetApplicationString(BaseInfo.EarthquakeName) + "報名資訊";

            }

         
        }

        private void InitLoad()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM Account WHERE Id = {Session["UpdateId"].ToString()}", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                input_Username.Value = dr["UserName"].ToString();
                Text1.Value = dr["Password"].ToString();
                input_Name.Value = dr["Name"].ToString();
                Text2.Value = dr["Phone"].ToString();
                Text3.Value = dr["Email"].ToString();
                Text4.Value = dr["SchoolId"].ToString();
                Text5.Value = dr["Id"].ToString();
            }
        }
        protected void btn_Close_ServerClick(object sender, EventArgs e)
        {
            Session["UpdateId"] = null;
            Response.Redirect("Intro.aspx");
        }
        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            string Email = "[a - zA - Z0 - 9._ % -] +@[a-zA-Z0-9._%-]+.[a-zA-Z]{2,4}";
            if (!Regex.IsMatch(Text3.Value,Email))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
                conn.Open();
               
                string commandString = $"UPDATE Account SET Email = '{ Text3.Value}',Username='{input_Username.Value}',Password='{Text1.Value}',Name='{input_Name.Value}',Phone='{Text2.Value}'  WHERE Id='{Text5.Value}'";
                SqlCommand command = new SqlCommand(commandString, conn);
                command.ExecuteNonQuery();

                command.Cancel();
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

       
    
