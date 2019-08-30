using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public static class DBHelper
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static int ExecNonQuery(string sql, params SqlParameter[] values)
        {
            using (SqlConnection scon = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, scon);
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteNonQuery();
            }
        }
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection scon = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, scon);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static object getScalar(string safeSql, params SqlParameter[] values)
        {
            using (SqlConnection scon = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(safeSql, scon);
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteScalar();
            }
        }


        public static int GetInt(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return (int)obj;
        }
        public static float GetFloat(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return (float)obj;
        }
        public static double GetDouble(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return (double)obj;
        }
        public static long GetLong(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return (long)obj;
        }
        public static decimal GetDecimal(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return (decimal)obj;
        }
        public static bool GetBoolean(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (bool)obj;
        }
        public static DateTime GetDateTime(object obj)
        {
            if (obj == null)
            {
                return DateTime.Now;
            }
            return (DateTime)obj;
        }
        public static string GetString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj + "";
        }

    }
}

