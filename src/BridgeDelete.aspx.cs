using DataProcessing;
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
    public partial class BridgeDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void select_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[2];
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE  FROM Account WHERE Name=@name";
            command.Parameters.AddWithValue("@name", conn).Value= int.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
           



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}