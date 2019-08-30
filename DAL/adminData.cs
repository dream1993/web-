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
    public class adminData : publicData
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
                    cmd.CommandText = "delete from [admin] where [id] = @id";
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
            strSql.Append("insert into [admin](");
            strSql.Append("password,role,userid,createTime,loginIp,loginTime)");
            strSql.Append(" values (");
            strSql.Append("@password,@role,@userid,@createTime,@loginIp,@loginTime)");
            strSql.Append(";select @@IDENTITY");
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = strSql.ToString();
                    cmd.Parameters.AddRange(new SqlParameter[]{
                         new SqlParameter("@password",model.password),
                         new SqlParameter("@role",model.role),
                         new SqlParameter("@userid",model.userid),
                             new SqlParameter("@createTime",model.createTime),
                         new SqlParameter("@loginIp",model.loginIp),
                         new SqlParameter("@loginTime",model.loginTime)
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
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public static bool loginip(string userid, string loginIp)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [admin] set [loginIp] = @loginIp,[loginTime]=@loginTime where [userid] = @userid";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@userid",userid),
                        new SqlParameter("@loginTime",DateTime.Now),
                        new SqlParameter("@loginIp",loginIp)
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
        /// 修改登录ip
        /// </summary>
        /// <returns></returns>
        public static bool updatepwd(string userid, string pwd)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [admin] set [password] = @pwd where [userid] = @userid";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@userid",userid),
                        new SqlParameter("@pwd",pwd)
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
        public static bool updatepwd(int id, string pwd)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [admin] set [password] = @pwd where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@id",id),
                        new SqlParameter("@pwd",pwd)
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
        public static bool updatepwd(int id, int role)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [admin] set [role] = @role where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@id",id),
                        new SqlParameter("@role",role)
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
            var sql = "select * from [admin] order by [id] desc";
            return GetListBySql(sql);

        }

        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static Value row(string id)
        {
            string sql = "select * from [admin] where [userid] = @id";
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
            string sql = "select * from [admin] where [id] = @id";
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
                    temp.userid = DBHelper.GetString(dr["userid"]);
                    temp.password = DBHelper.GetString(dr["password"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                    temp.role = DBHelper.GetInt(dr["role"]);
                    temp.createTime = DBHelper.GetDateTime(dr["createTime"]);
                    temp.loginTime = DBHelper.GetDateTime(dr["loginTime"]);
                    temp.loginIp = DBHelper.GetString(dr["loginIp"]);
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
            /// 密码
            /// </summary>
            public string password
            {
                get;
                set;
            }
            /// <summary>
            ///权限
            /// </summary>
            public int role
            {
                get;
                set;
            }
            /// <summary>
            /// 登录Ip
            /// </summary>
            public string loginIp
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
            /// 最近一次登录时间
            /// </summary>
            public DateTime loginTime
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
