using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SignUpSystem
{
    public partial class BackgroundDataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 2;
        }
        //protected void myListDropDown_Change(object sender, EventArgs e)
        //{
        //    string strConn = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(strConn);
        //    conn.Open();

        //switch (DropDownList1.SelectedItem.Value)
        //{
        //    case "0":
        //        SqlCommand t1 = new SqlCommand("SELECT Name,Count,Vegetarian,LraderName,PlayerName1,PlayerName2," +
        //              "PlayerName3,PlayerName4,PlayerName5,AccountID FORM EarthquakeTeam", conn);
        //        SqlDataReader dr = t1.ExecuteReader();
        //        break;
        //    case "1":
        //        SqlCommand t2 = new SqlCommand("SELECT Name,Count,Vegetarian,LraderName,LraderID,PlayerName1,PlayerID1," +
        //            "PlayerName2,PlayerID2,PlayerName3,PlayerID3,PlayerName4,PlayerID4,PlayerName5,PlayerID5,AccountID FORM BridgeTeam", conn);
        //        SqlDataReader dr2 = t2.ExecuteReader();
        //        break;
        //    case " 2":
        //        SqlCommand t3 = new SqlCommand("SELECT TeamID,DesignConcept,Outline,FileLink FORM FilmInfo", conn);
        //        SqlDataReader dr3 = t3.ExecuteReader();
        //        break;
        //    case "3":
        //        SqlCommand t4 = new SqlCommand("SELECT * FORM Account", conn);
        //        SqlDataReader dr4 = t4.ExecuteReader();
        //        break;
        //}
        //DataTable dt = new DataTable();
        //DataRow drow;
        //DataColumn dc1 = new DataColumn("Code", typeof(string));
        //DataColumn dc2 = new DataColumn("Name", typeof(string));
        //dt.Columns.Add(dc1);
        //dt.Columns.Add(dc2);
        //if (dr.HasRow)
        //{
        //    foreach (var dr in dt.Columns)
        //    {

        //    }
        //input data to gridview


        protected void btn_Export_Click(object sender, EventArgs e)
        {

            string filename = "SampleExcelFile";
            string strfileext = ".xls";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

            //先把分頁關掉
            GridView2.AllowPaging = false;
            GridView2.DataBind();

            //Get the HTML for the control.
            GridView2.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();

            GridView2.AllowPaging = true;
            GridView2.DataBind();
        }
        //必須覆寫 Page.VerifyRenderingInServerForm　
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btn1_Export_Click(object sender, EventArgs e)
        {

            string filename = "SampleExcelFile";
            string strfileext = ".xls";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

            //先把分頁關掉
            GridView3.AllowPaging = false;
            GridView3.DataBind();

            //Get the HTML for the control.
            GridView3.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();

            GridView3.AllowPaging = true;
            GridView3.DataBind();
        }
        protected void btn2_Export_Click(object sender, EventArgs e)
        {

            string filename = "SampleExcelFile";
            string strfileext = ".xls";
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

            //先把分頁關掉
            GridView4.AllowPaging = false;
            GridView4.DataBind();

            //Get the HTML for the control.
            GridView4.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();

            GridView4.AllowPaging = true;
            GridView4.DataBind();
        }

    }
}






















