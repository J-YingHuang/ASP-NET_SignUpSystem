using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpSystem
{
    public partial class SchoolAddin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            
        }

        protected void btn_SendEmail_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = new SqlCommand("INSERT INTO School  values (@Schoolname,@Address,@Area)", conn);
            command.Parameters.AddWithValue(@"Schoolname", School_name.Value);
            command.Parameters.AddWithValue(@"Address", Address.Value);
            command.Parameters.AddWithValue(@"Area", Area.Value);
            command.ExecuteNonQuery();
            Server.Transfer("AccountAddin.aspx");

        }
    }
}