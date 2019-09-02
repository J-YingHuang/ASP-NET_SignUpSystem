using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SignUpSystem
{
    public partial class BackgroundDataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void myListDropDown_Change(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            
            switch (DropDownList1.SelectedItem.Value)
            {
                case "0":
                   new SqlCommand("SELECT Name,Count,Vegetarian,LraderName,PlayerName1,PlayerName2," +
                        "PlayerName3,PlayerName4,PlayerName5,AccountID FORM EarthquakeTeam", conn);
                    break;
                case "1":
                     new SqlCommand("SELECT Name,Count,Vegetarian,LraderName,LraderID,PlayerName1,PlayerID1," +
                        "PlayerName2,PlayerID2,PlayerName3,PlayerID3,PlayerName4,PlayerID4,PlayerName5,PlayerID5,AccountID FORM BridgeTeam", conn);
                    break;
                case " 2":
                     new SqlCommand("SELECT TeamID,DesignConcept,Outline,FileLink FORM FilmInfo", conn);
                    break;
                case "3":
                     new SqlCommand("SELECT * FORM Account", conn);
                    break;

           
            }
           SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {

            }
           








                //input data to gridview


            //    protected void btn_Export_Click(object sender, EventArgs e)
            //    {
            //        Response.Clear();
            //        Response.Buffer = true;
            //        Response.Charset = "BIG5";
            //        string Excel_ShortTime = DateTime.Now.ToShortTimeString();
            //        Response.AppendHeader("Content-Disposion", "attent;file name=test_file_"
            //            + Excel_ShortTime + ".xls");

            //        Response.ContentEncoding = Encoding.GetEncoding("BIG5");
            //        Response.ContentType = "application/ms-excel";

            //        //GridView1.EnableViewState = false;
            //        //GridView1.AllowPaging = false;
            //        //StringWriter objStringWriter = new StringWriter();
            //        //HtmlTextWriter.objHtmlTextWriter = new HtmlTextWriter(objStringWriter);



        }



        }

    }
