using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class publicData
    {
        public static string connString = ConfigurationManager.ConnectionStrings["connection"].ToString();
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        
        protected static SqlConnection Odc()
        {
            var odc = new SqlConnection(connString);
            return odc;
        }
        /// <summary>
        /// 适配器查询方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable Odt(string sql)
        {
            var dt = new DataTable();
            var da = new SqlDataAdapter(sql, Odc());
            da.Fill(dt);
            return dt;
        }
    }
}
