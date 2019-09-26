using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class AccountDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);

            string in_put = DropDownList1.SelectedValue;
            string strsql = "SELECT * from Account";
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "test");
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Name";
            DropDownList1.DataSource = ds.Tables["test"].DefaultView;
            DropDownList1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConn);

                string in_put = DropDownList1.SelectedValue;
                string strsql = "SELECT * from Account WHERE  Name = " + in_put;
                SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test");
               



                GridView1.DataSource = ds.Tables["test"].DefaultView;
                GridView1.DataBind();
              
                
                                
             
            }
            catch (Exception ex)
            {
                GridView1.Columns.Clear();
                GridView1.DataBind();
            }
        }

        }
}