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
    public class messageData : publicData
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
                    cmd.CommandText = "delete from [message] where [id] = @id";
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
            strSql.Append("insert into [message](");
            strSql.Append("userid,contents,createTime)");
            strSql.Append(" values (");
            strSql.Append("@userid,@contents,@createTime)");
            strSql.Append(";select @@IDENTITY");
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = strSql.ToString();
                    cmd.Parameters.AddRange(new SqlParameter[]{
                         new SqlParameter("@userid",model.userid),
                         new SqlParameter("@contents",model.contents),
                         new SqlParameter("@createTime",DateTime.Now)
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
            var sql = "select * from [message] order by [id] desc";
            return GetListBySql(sql);
        }

        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static Value row(string id)
        {
            string sql = "select * from [message] where [userid] = @id";
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
            string sql = "select * from [message] where [id] = @id";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        public static List<Value> page(int data, int page)
        {
     

            string sql = "select top " + data + " * from [message]  where id not in ( select top " + data * (page - 1) + " id from [message]    order by [id] desc )  order by  [id] desc ";
            return GetListBySql(sql);
        }
        public static int count()
        {
            string sql = "select count(id) from [message]  " ;
            return (int)DBHelper.getScalar(sql);
        }
        private static List<Value> GetListBySql(string sql, params SqlParameter[] para)
        {
            List<Value> list = new List<Value>();
            using (SqlDataReader dr = DBHelper.GetReader(sql, para))
            {
                while (dr.Read())
                {
                    Value temp = new Value();
                    temp.userid = DBHelper.GetString(dr["userid"]);
                    temp.contents = DBHelper.GetString(dr["contents"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                    temp.createTime = DBHelper.GetDateTime(dr["createTime"]);
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
            public string userid
            {
                get;
                set;
            }
            /// <summary>
            /// 内容
            /// </summary>
            public string contents
            {
                get;
                set;
            }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime createTime
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
