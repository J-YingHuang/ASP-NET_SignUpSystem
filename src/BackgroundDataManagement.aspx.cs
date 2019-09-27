﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.XlsIO;

namespace SignUpSystem
{
    public partial class BackgroundDataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Addin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountAddin.aspx");
        }

        protected void btn_AccountModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountModify.aspx");
        }

        protected void AccountDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountDelete.aspx");
        }

        protected void btn_EearthquakeModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("EearthquakeModify.aspx");
        }

        protected void btn_EearthquakeDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("EearthquakeDelete.aspx");
        }

        protected void btn_BridgeModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("BridgeModify.aspx");
        }

        protected void btn_BridgeDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("BridgeDelete.aspx");
        }

        protected void btn_FilmModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilmModify.aspx");
        }
        protected void btn_FilmDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilmDelete.aspx");
        }

        protected void btn_UpdateToNextYear_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();

            string commStr = $"UPDATE BaseInfo SET " +
                $"EarthquakeName = '{input_EarthquakeName.Value}', " +
                $"BridgeName = '{input_BridgeName.Value}', " +
                $"FilmName = '{input_FilmName.Value}', " +
                $"StartSignUp = '{input_StartSignUp.Value} 18:00:00', " +
                $"EndSignUp = '{input_EndSignUp.Value} 18:00:00', " +
                $"EndUpdateInfo = '{input_EndUpdateInfo.Value} 18:00:00', " +
                $"EndFilmUpdate = '{input_EndFilmUpdate.Value} 18:00:00', " +
                $"GameNumber = '{input_GameNumber.Value}' Where Id = 1;";

            SqlCommand comm = new SqlCommand(commStr, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            //Create an instance of ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Set the default application version as Excel 2016
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;

                //Create a workbook with a worksheet
                IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

                //Access first worksheet from the workbook instance
                IWorksheet worksheet = workbook.Worksheets[0];

                //Insert sample text into cell “A1”
                worksheet.Range["A1"].Text = "Hello World";

                //Save the workbook to disk in xlsx format
                workbook.SaveAs("Output.xlsx", Response, ExcelDownloadType.Open, ExcelHttpContentType.Excel2016);
            }
        }
    }

        
}
    
