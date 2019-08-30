//============================================================
// Producnt name:		TenXiang.Code
// Coded by:			hotboart
// Auto generated at: 	2014/1/5 11:48:31
//============================================================



using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;




namespace DAL
{

    public static partial class userRoleData
    {
        //Add Mothed Start
        public static readonly string InsertSql = "INSERT userRole (roleName, price)VALUES (@roleName, @price)";
        public static readonly string UpdateSql = "Update userRole set roleName=@roleName, price=@price where id=@id";
        public static readonly string DeleteSql = "Delete FROM userRole  where id=@id";
        public static readonly string SelectSql = "Select * FROM userRole";
        public static readonly string SelectSqlById = "Select * FROM userRole where id =@id";
        public static int Add(Value Value)
        {
            string sql = InsertSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@roleName",Value.roleName), new SqlParameter("@price",Value.price)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int update(Value Value)
        {
            string sql = UpdateSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@roleName",Value.roleName), new SqlParameter("@price",Value.price), new SqlParameter("@id",Value.id)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int AdduserRole(string sql)
        {

            return DBHelper.ExecNonQuery(sql);
        }

        public static int Del(int id)
        {
            string sql = DeleteSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@id",id)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        /// <summary>
        /// 根据用户权限id来删除访问的页面
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>

        public static int DelroleName(int roleName)
        {
            string sql = "Delete FROM userRole  where roleName=@roleName";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@roleName",roleName)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        /// <summary>
        /// 根据权限查询
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static List<Value> GetListByroleName(int roleName)
        {
            string sql = "Select * FROM userRole where roleName=@roleName ";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@roleName",roleName)
                                  };
            return GetListBySql(sql, para);
        }
        /// <summary>
        /// 根据菜单父id查询
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static List<Value> GetListByprice(int roleName)
        {
            string sql = "Select * FROM userRole where price in (select price from SysFun where Parentprice=@roleName)";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@roleName",roleName)
                                  };
            return GetListBySql(sql, para);
        }
        public static List<Value> GetAllList()
        {
            string sql = SelectSql;
            return GetListBySql(sql);
        }
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Value row(int id)
        {
            string sql = SelectSqlById;
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
                return list[0];
            else
                return new Value() { hasRow = false };
        }

        private static List<Value> GetListBySql(string sql, params SqlParameter[] para)
        {
            List<Value> list = new List<Value>();
            using (SqlDataReader reader = DBHelper.GetReader(sql, para))
            {
                while (reader.Read())
                {
                    Value temp = new Value();

                    temp.id = DBHelper.GetInt(reader["id"]);
                    temp.roleName = DBHelper.GetString(reader["roleName"]);
                    temp.price = DBHelper.GetDouble(reader["price"]);
                    temp.hasRow = true;
                    list.Add(temp);
                }
                reader.Close();
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
            /// 权限名称
            /// </summary>
            public string roleName
            {
                get;
                set;
            }
            /// <summary>
            /// 等级对应的额度
            /// </summary>
            public double price
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

