using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.XlsIO;
using DataProcessing;

namespace SignUpSystem
{
    public partial class BackgroundDataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["ManageLogin"] == null || Session["ManageLogin"].ToString() != "Y")
                    Response.Redirect("~/ManagerLogin.aspx");
            }
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
                $"GameDate = '{input_GameDate.Value} 18:00:00', " +
                $"GameNumber = '{input_GameNumber.Value}' Where Id = 1;";

            SqlCommand comm = new SqlCommand(commStr, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            //讀取Application Data
            ApplicationProcessing appPro = new ApplicationProcessing(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString);
            conn.Open();
            SqlCommand comm;
            SqlDataReader dr;

            //Create an instance of ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Set the default application version as Excel 2016
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;

                //Create a workbook with a worksheet
                IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);


                //抗震大作戰Sheet
                //Access first worksheet from the workbook instance
                IWorksheet earthquakeWorksheet = workbook.Worksheets[0];
                earthquakeWorksheet.Name = appPro.GetApplicationString(BaseInfo.EarthquakeName) + "報名資訊";

                //標題列
                //Insert sample text into cell “A1”
                earthquakeWorksheet.Range[1, 1].Text = "隊伍編號";
                earthquakeWorksheet.Range[1, 2].Text = "隊伍名稱";
                earthquakeWorksheet.Range[1, 3].Text = "報名人數";
                earthquakeWorksheet.Range[1, 4].Text = "隊長姓名";
                earthquakeWorksheet.Range[1, 5].Text = "隊員一姓名";
                earthquakeWorksheet.Range[1, 6].Text = "隊員二姓名";
                earthquakeWorksheet.Range[1, 7].Text = "隊員三姓名";
                earthquakeWorksheet.Range[1, 8].Text = "隊員四姓名";
                earthquakeWorksheet.Range[1, 9].Text = "隊員五姓名";
                earthquakeWorksheet.Range[1, 10].Text = "帶隊老師";
                earthquakeWorksheet.Range[1, 11].Text = "帶隊老師電話";
                earthquakeWorksheet.Range[1, 12].Text = "帶隊老師Email";
                earthquakeWorksheet.Range[1, 13].Text = "共同指導老師";
                earthquakeWorksheet.Range[1, 14].Text = "學校名稱";
                earthquakeWorksheet.Range[1, 15].Text = "學校地址";

                //匯出資料
                comm = new SqlCommand($"SELECT * FROM EarthquakeTeam LEFT JOIN Account ON EarthquakeTeam.AccountID = Account.Id " +
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE EarthquakeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = comm.ExecuteReader();

                int num = 2;
                while (dr.Read())
                {
                    //匯出每一筆資料
                    earthquakeWorksheet.Range[num, 1].Text = dr[0].ToString();
                    earthquakeWorksheet.Range[num, 2].Text = dr[1].ToString();
                    earthquakeWorksheet.Range[num, 3].Text = dr[2].ToString();
                    earthquakeWorksheet.Range[num, 4].Text = dr[3].ToString();
                    earthquakeWorksheet.Range[num, 5].Text = dr[4].ToString();
                    earthquakeWorksheet.Range[num, 6].Text = dr[5].ToString();
                    earthquakeWorksheet.Range[num, 7].Text = dr[6].ToString();
                    earthquakeWorksheet.Range[num, 8].Text = dr[7].ToString();
                    earthquakeWorksheet.Range[num, 9].Text = dr[8].ToString();
                    earthquakeWorksheet.Range[num, 10].Text = dr[15].ToString();
                    earthquakeWorksheet.Range[num, 11].Text = dr[16].ToString();
                    earthquakeWorksheet.Range[num, 12].Text = dr[17].ToString();
                    earthquakeWorksheet.Range[num, 13].Text = dr[11].ToString();
                    earthquakeWorksheet.Range[num, 14].Text = dr[21].ToString();
                    earthquakeWorksheet.Range[num, 15].Text = dr[22].ToString();


                    num++;
                }

                dr.Close();
                comm.Cancel();

                //橋梁變變變Sheet
                //Access 2nd worksheet from the workbook instance
                IWorksheet bridgeWorksheet = workbook.Worksheets.Create(appPro.GetApplicationString(BaseInfo.BridgeName) + "報名資訊");

                //標題列
                //Insert sample text into cell “A1”
                bridgeWorksheet.Range[1, 1].Text = "隊伍編號";
                bridgeWorksheet.Range[1, 2].Text = "隊伍名稱";
                bridgeWorksheet.Range[1, 3].Text = "報名人數";
                bridgeWorksheet.Range[1, 4].Text = "隊長姓名";
                bridgeWorksheet.Range[1, 5].Text = "隊長身分證字號";
                bridgeWorksheet.Range[1, 6].Text = "隊長生日";
                bridgeWorksheet.Range[1, 7].Text = "隊員一姓名";
                bridgeWorksheet.Range[1, 8].Text = "隊員一身分證字號";
                bridgeWorksheet.Range[1, 9].Text = "隊員一生日";
                bridgeWorksheet.Range[1, 10].Text = "隊員二姓名";
                bridgeWorksheet.Range[1, 11].Text = "隊員二身分證字號";
                bridgeWorksheet.Range[1, 12].Text = "隊員二生日";
                bridgeWorksheet.Range[1, 13].Text = "隊員三姓名";
                bridgeWorksheet.Range[1, 14].Text = "隊員三身分證字號";
                bridgeWorksheet.Range[1, 15].Text = "隊員三生日";
                bridgeWorksheet.Range[1, 16].Text = "隊員四姓名";
                bridgeWorksheet.Range[1, 17].Text = "隊員四身分證字號";
                bridgeWorksheet.Range[1, 18].Text = "隊員四生日";
                bridgeWorksheet.Range[1, 19].Text = "帶隊老師";
                bridgeWorksheet.Range[1, 20].Text = "帶隊老師電話";
                bridgeWorksheet.Range[1, 21].Text = "帶隊老師Email";
                bridgeWorksheet.Range[1, 22].Text = "共同指導老師";
                bridgeWorksheet.Range[1, 23].Text = "學校名稱";
                bridgeWorksheet.Range[1, 24].Text = "學校地址";

                //匯出資料
                comm = new SqlCommand($"SELECT * FROM BridgeTeam LEFT JOIN Account ON BridgeTeam.AccountID = Account.Id " +
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE BridgeTeam.CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = comm.ExecuteReader();

                num = 2;
                while (dr.Read())
                {
                    //匯出每一筆資料
                    bridgeWorksheet.Range[num, 1].Text = dr[0].ToString();
                    bridgeWorksheet.Range[num, 2].Text = dr[1].ToString();
                    bridgeWorksheet.Range[num, 3].Text = dr[2].ToString();
                    bridgeWorksheet.Range[num, 4].Text = dr[3].ToString();
                    bridgeWorksheet.Range[num, 5].Text = dr[4].ToString();
                    bridgeWorksheet.Range[num, 6].Text = dr[5].ToString().Replace("上午 12:00:00", "");
                    bridgeWorksheet.Range[num, 7].Text = dr[6].ToString();
                    bridgeWorksheet.Range[num, 8].Text = dr[7].ToString();
                    bridgeWorksheet.Range[num, 9].Text = dr[8].ToString().Replace("上午 12:00:00", "");
                    bridgeWorksheet.Range[num, 10].Text = dr[9].ToString();
                    bridgeWorksheet.Range[num, 11].Text = dr[10].ToString();
                    bridgeWorksheet.Range[num, 12].Text = dr[11].ToString().Replace("上午 12:00:00", "");
                    bridgeWorksheet.Range[num, 13].Text = dr[12].ToString();
                    bridgeWorksheet.Range[num, 14].Text = dr[13].ToString();
                    bridgeWorksheet.Range[num, 15].Text = dr[14].ToString().Replace("上午 12:00:00", "");
                    bridgeWorksheet.Range[num, 16].Text = dr[15].ToString();
                    bridgeWorksheet.Range[num, 17].Text = dr[16].ToString();
                    bridgeWorksheet.Range[num, 18].Text = dr[17].ToString().Replace("上午 12:00:00", "");
                    bridgeWorksheet.Range[num, 19].Text = dr[24].ToString();
                    bridgeWorksheet.Range[num, 20].Text = dr[25].ToString();
                    bridgeWorksheet.Range[num, 21].Text = dr[26].ToString();
                    bridgeWorksheet.Range[num, 22].Text = dr[20].ToString();
                    bridgeWorksheet.Range[num, 23].Text = dr[30].ToString();
                    bridgeWorksheet.Range[num, 24].Text = dr[31].ToString();


                    num++;
                }

                dr.Close();
                comm.Cancel();

                //微電影Sheet
                //Access 3rd worksheet from the workbook instance
                IWorksheet filmWorksheet = workbook.Worksheets.Create(appPro.GetApplicationString(BaseInfo.FilmName) + "報名資訊");

                //標題列
                //Insert sample text into cell “A1”
                filmWorksheet.Range[1, 1].Text = "隊伍編號";
                filmWorksheet.Range[1, 2].Text = "隊伍名稱";
                filmWorksheet.Range[1, 3].Text = "設計理念";
                filmWorksheet.Range[1, 4].Text = "故事大綱";
                filmWorksheet.Range[1, 5].Text = "作品連結";
                filmWorksheet.Range[1, 6].Text = "隊伍類型";
                filmWorksheet.Range[1, 7].Text = "帶隊老師";

                //匯出資料
                comm = new SqlCommand($"SELECT * FROM FilmInfo LEFT JOIN Account ON FilmInfo.AccountID = Account.Id " +
                    $"WHERE FilmInfo.CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = comm.ExecuteReader();

                num = 2;
                while (dr.Read())
                {
                    //匯出每一筆資料
                    filmWorksheet.Range[num, 1].Text = dr[0].ToString();
                    filmWorksheet.Range[num, 2].Text = dr[1].ToString();
                    filmWorksheet.Range[num, 3].Text = dr[2].ToString();
                    filmWorksheet.Range[num, 4].Text = dr[3].ToString();
                    filmWorksheet.Range[num, 5].Text = dr[4].ToString();
                    filmWorksheet.Range[num, 6].Text = dr[7].ToString();
                    filmWorksheet.Range[num, 7].Text = dr[11].ToString();

                    num++;
                }

                dr.Close();
                comm.Cancel();



                IWorksheet eatWorksheet = workbook.Worksheets.Create("便當統計");
                //標題列
                //Insert sample text into cell “A1”
                eatWorksheet.Range[1, 1].Text = "總葷食便當";
                eatWorksheet.Range[1, 2].Text = "總素食便當";
                eatWorksheet.Range[1, 4].Text = "帶隊老師";
                eatWorksheet.Range[1, 5].Text = "學校名稱";
                eatWorksheet.Range[1, 6].Text = "葷食便當";
                eatWorksheet.Range[1, 7].Text = "素食便當";

                //匯出資料
                comm = new SqlCommand($"SELECT * FROM LunchInfo LEFT JOIN Account ON LunchInfo.AccountID = Account.Id " +
                    $"LEFT JOIN School ON Account.SchoolID = School.Id WHERE LunchInfo.CreateDate " +
                    appPro.GetBetweenSignUpTime(), conn);
                dr = comm.ExecuteReader();
                int VegLunch_Count = 0;
                int Lunch_Count = 0;

                num = 2;
                while (dr.Read())
                {
                    //匯出每一筆資料
                    eatWorksheet.Range[num, 4].Text = dr[8].ToString();
                    eatWorksheet.Range[num, 5].Text = dr[14].ToString();
                    eatWorksheet.Range[num, 6].Text = dr[1].ToString();
                    eatWorksheet.Range[num, 7].Text = dr[2].ToString();
                    VegLunch_Count += (int)dr[1];
                    Lunch_Count += (int)dr[2];

                    num++;
                }

                dr.Close();
                comm.Cancel();
                
                //值
                eatWorksheet.Range[2, 1].Text =VegLunch_Count.ToString();
                eatWorksheet.Range[2, 2].Text = Lunch_Count.ToString();




                IWorksheet accountWorkSheet = workbook.Worksheets.Create("帳戶資訊");

                //標題列
                //Insert sample text into cell “A1”
                accountWorkSheet.Range[1, 1].Text = "老師名稱";
                accountWorkSheet.Range[1, 2].Text = "連絡電話";
                accountWorkSheet.Range[1, 3].Text = "Email";
                accountWorkSheet.Range[1, 4].Text = "任職學校";
                accountWorkSheet.Range[1, 5].Text = "學校地址";

                //匯出資料
                comm = new SqlCommand($"SELECT * FROM Account LEFT JOIN School ON Account.SchoolID = School.Id ;", conn);
                dr = comm.ExecuteReader();

                num = 2;
                while (dr.Read())
                {
                    //匯出每一筆資料
                    accountWorkSheet.Range[num, 1].Text = dr[3].ToString();
                    accountWorkSheet.Range[num, 2].Text = dr[4].ToString();
                    accountWorkSheet.Range[num, 3].Text = dr[5].ToString();
                    accountWorkSheet.Range[num, 4].Text = dr[10].ToString();
                    accountWorkSheet.Range[num, 5].Text = dr[11].ToString();

                    num++;
                }

                dr.Close();
                comm.Cancel();

                //Save the workbook to disk in xlsx format
                workbook.SaveAs("Output.xlsx", Response, ExcelDownloadType.Open, ExcelHttpContentType.Excel2016);
            }
        }
        public string GetDrString(SqlDataReader dr, int index)
        {
            List<string> fieldName = new List<string>();
            for (int i = 0; i < dr.FieldCount; i++)
                fieldName.Add(dr.GetName(i));

            return dr.GetString(index);
        }

        protected void btn_Button1_Click(object sender, EventArgs e)
        {
            Session["ManageLogin"] = null;
            Response.Redirect("ManagerLogin.aspx");
        }
    }

        
}
    
