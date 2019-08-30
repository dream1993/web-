using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class sysMessageData : publicData
    {

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public static bool delete(int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "delete from [sysMessage] where [id] = @id";
                    var odp = new SqlParameter("id", id);
                    cmd.Parameters.Add(odp);
                    odc.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [sysMessage](");
            strSql.Append("title,contents)");
            strSql.Append(" values (");
            strSql.Append("@title,@contents)");
            strSql.Append(";select @@IDENTITY");
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = strSql.ToString();
                    cmd.Parameters.AddRange(new SqlParameter[]{
                         new SqlParameter("@title",model.title),
                         new SqlParameter("@contents",model.contents),
                    }
                    );
                    odc.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static bool update(Value model)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [sysMessage] set [contents] = @contents,[title]=@title where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                         new SqlParameter("@title",model.title),
                          new SqlParameter("@id",model.id),
                         new SqlParameter("@contents",model.contents)
                    }
                      );
                    odc.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 根查询全部
        /// </summary>
        /// <returns></returns>
        public static List<Value> table()
        {
            var sql = "select * from [sysMessage] order by [id] desc";
            return GetListBySql(sql);

        }

        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static Value row(string id)
        {
            string sql = "select * from [sysMessage] where [userid] = @id";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }

        public static Value row(int id)
        {
            string sql = "select * from [sysMessage] where [id] = @id";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        private static List<Value> GetListBySql(string sql, params SqlParameter[] para)
        {
            List<Value> list = new List<Value>();
            using (SqlDataReader dr = DBHelper.GetReader(sql, para))
            {
                while (dr.Read())
                {
                    Value temp = new Value();
                    temp.title = DBHelper.GetString(dr["title"]);
                    temp.contents = DBHelper.GetString(dr["contents"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                
                    temp.hasRow = true;
                    list.Add(temp);
                }
                dr.Close();
                return list;
            }
        }





        /// <summary>
        /// 实体
        /// </summary>
        public struct Value
        {
            /// <summary>
            /// 标示
            /// </summary>
            public int id
            {
                get;
                set;
            }
            /// <summary>
            /// 登陆名
            /// </summary>
            public string title
            {
                get;
                set;
            }
            /// <summary>
            /// 密码
            /// </summary>
            public string contents
            {
                get;
                set;
            }
         
            /// <summary>
            /// 是否存在此行
            /// </summary>
            public bool hasRow
            {
                get;
                set;
            }
        }

    }
}
