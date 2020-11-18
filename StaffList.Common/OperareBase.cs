using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Common
{
    public class OperareBase
    {
        #region 数据库链接
        public static SqlConnection getStart(string Conn)
        {
            String con = ConfigurationManager.ConnectionStrings["Darkshadow"].ConnectionString;
            SqlConnection sct = new SqlConnection(con);
            return sct;
        }
        #endregion

        #region 数据库查询

        public static DataSet getData(string sql)
        {
            SqlConnection sct = getStart(sql);
            SqlDataAdapter sda = new SqlDataAdapter(sql, sct);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        #endregion

        #region 数据库增删改方法

        public static int CommanBySql(string sql)
        {
            SqlConnection sct = getStart(sql);
            SqlCommand smd = new SqlCommand(sql, sct);
            sct.Open();//打开
            int flag = smd.ExecuteNonQuery();
            sct.Close();//关闭
            return flag;
        }
        #endregion



    }
}