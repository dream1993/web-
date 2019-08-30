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

    public static partial class RoleRightData
    {
        //Add Mothed Start
        public static readonly string InsertSql = "INSERT RoleRight (RoleId, NodeId)VALUES (@RoleId, @NodeId)";
        public static readonly string UpdateSql = "Update RoleRight set RoleId=@RoleId, NodeId=@NodeId where RoleRightId=@RoleRightId";
        public static readonly string DeleteSql = "Delete FROM RoleRight  where RoleRightId=@RoleRightId";
        public static readonly string SelectSql = "Select * FROM RoleRight";
        public static readonly string SelectSqlById = "Select * FROM RoleRight where RoleRightId =@RoleRightId";
        public static int Add(Value Value)
        {
            string sql = InsertSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleId",Value.RoleId), new SqlParameter("@NodeId",Value.NodeId)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int AddRoleRight(string sql)
        {

            return DBHelper.ExecNonQuery(sql);
        }

        public static int Del(int id)
        {
            string sql = DeleteSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleRightId",id)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        /// <summary>
        /// 根据用户权限id来删除访问的页面
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>

        public static int DelRoleId(int RoleId)
        {
            string sql = "Delete FROM RoleRight  where RoleId=@RoleId";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleId",RoleId)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        /// <summary>
        /// 根据权限查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static List<Value> GetListByRoleId(int roleId)
        {
            string sql = "Select * FROM RoleRight where RoleId=@RoleId ";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleId",roleId)
                                  };
            return GetListBySql(sql, para);
        }
        /// <summary>
        /// 根据菜单父id查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static List<Value> GetListBynodeId(int roleId)
        {
            string sql = "Select * FROM RoleRight where NodeId in (select NodeId from SysFun where ParentNodeId=@RoleId)";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleId",roleId)
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
        /// <param name="RoleRightId"></param>
        /// <returns></returns>
        public static Value row(int RoleRightId)
        {
            string sql = SelectSqlById;
            SqlParameter para = new SqlParameter("@RoleRightId", RoleRightId);
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

                    temp.RoleRightId = DBHelper.GetInt(reader["RoleRightId"]);
                    temp.RoleId = DBHelper.GetInt(reader["RoleId"]);
                    temp.NodeId = DBHelper.GetInt(reader["NodeId"]);
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
            public int RoleRightId
            {
                get;
                set;
            }
            /// <summary>
            /// 链接名称
            /// </summary>
            public int RoleId
            {
                get;
                set;
            }
            /// <summary>
            /// 链接地址
            /// </summary>
            public int NodeId
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

