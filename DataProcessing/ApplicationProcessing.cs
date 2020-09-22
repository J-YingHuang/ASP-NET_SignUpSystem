using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace DataProcessing
{
    public class ApplicationProcessing
    {
        public ApplicationProcessing(string strConn)
        {
            GetBaseInfo(strConn);
        }
        public void GetBaseInfo(string strConn)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM BaseInfo", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                HttpContext.Current.Application.Clear();
                HttpContext.Current.Application.Add("EarthquakeName", dr["EarthquakeName"].ToString());
                HttpContext.Current.Application.Add("BridgeName", dr["BridgeName"].ToString());
                HttpContext.Current.Application.Add("FilmName", dr["FilmName"].ToString());
                HttpContext.Current.Application.Add("StartSignUp", dr["StartSignUp"].ToString());
                HttpContext.Current.Application.Add("EndSignUp", dr["EndSignUp"].ToString());
                HttpContext.Current.Application.Add("EndUpdateInfo", dr["EndUpdateInfo"].ToString());
                HttpContext.Current.Application.Add("EndFilmUpdate", dr["EndFilmUpdate"].ToString());
                HttpContext.Current.Application.Add("GameNumber", dr["GameNumber"].ToString());
                HttpContext.Current.Application.Add("GameDate", dr["GameDate"].ToString());
            }
        }
        public string GetApplicationString(BaseInfo infoType)
        {
            return HttpContext.Current.Application.Get(Enum.GetName(typeof(BaseInfo), infoType)).ToString();
        }
        public string GetDateFormat(BaseInfo infoType,string format)
        {
            string data = GetApplicationString(infoType);
            return Convert.ToDateTime(data).ToString(format);
        }
        public string GetBetweenSignUpTime()
        {
            string startSiguUp = GetDateFormat(BaseInfo.StartSignUp, "yyyy-MM-dd HH:mm:ss");
            string endSignUp = GetDateFormat(BaseInfo.EndSignUp, "yyyy-MM-dd HH:mm:ss");

            return $"BETWEEN '{startSiguUp}' AND '{endSignUp}'";
        }

    }
}
