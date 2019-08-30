using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        protected void btn_Export_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "BIG5";
            string Excel_ShortTime = DateTime.Now.ToShortTimeString();
            Response.AppendHeader("Content-Disposion", "attent;file name=test_file_"
                + Excel_ShortTime + ".xls");

            Response.ContentEncoding = Encoding.GetEncoding("BIG5");
            Response.ContentType = "application/ms-excel";

            GridView1.EnableViewState = false;
            GridView1.AllowPaging = false;
           StringWriter objStringWriter = new StringWriter();
           HtmlTextWriter.objHtmlTextWriter = new HtmlTextWriter(objStringWriter);



        }

       

}
}
