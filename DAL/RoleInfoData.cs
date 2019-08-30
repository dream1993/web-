//============================================================
// Producnt name:		TenXiang.Code
// Coded by:			hotboart
// Auto generated at: 	2014/1/5 11:48:22
//============================================================



using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace DAL
{

    public class RoleInfoData : publicData
    {
        //Add Mothed Start
        public static readonly string InsertSql = "INSERT RoleInfo (RoleId,RoleName, RoleDesc,parentId,layer)VALUES (@RoleId,@RoleName, @RoleDesc,@parentId,@layer)";
        public static readonly string UpdateSql = "Update RoleInfo set RoleName=@RoleName,RoleDesc=@RoleDesc where id=@id";
        public static readonly string DeleteSql = "Delete FROM RoleInfo  where id=@id";
        public static readonly string SelectSql = "Select * FROM RoleInfo";
        public static readonly string SelectSqlById = "Select * FROM RoleInfo where id =@id";
        public static readonly string MaxIdSql = "Select max(id) FROM RoleInfo ";

        /// <summary>
        /// 计数
        /// </summary>
        /// <returns></returns>
        public static int count()
        {
            int result = 0;
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select count([id]) from [RoleInfo]";
                    odc.Open();
                    var sum = cmd.ExecuteScalar();
                    if (!Convert.IsDBNull(sum))
                    {
                        result = Convert.ToInt32(sum);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 最大id
        /// </summary>
        /// <returns></returns>
        public static int max()
        {
            int result = 0;
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select MAX([id]) from [RoleInfo]";
                    odc.Open();
                    var sum = cmd.ExecuteScalar();
                    if (!Convert.IsDBNull(sum))
                    {
                        result = Convert.ToInt32(sum);
                    }
                }
            }
            return result;
        }
        public static int AddRoleInfo(Value roleInfo)
        {
            string sql = InsertSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@RoleId",roleInfo.RoleId), new SqlParameter("@parentId",roleInfo.parentId),
                                        new SqlParameter("@RoleName",roleInfo.RoleName), new SqlParameter("@RoleDesc",roleInfo.RoleDesc),
                                        new SqlParameter("@layer",roleInfo.layer)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int UpdateRoleInfo(Value roleInfo)
        {
            string sql = UpdateSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										 new SqlParameter("@RoleName",roleInfo.RoleName), new SqlParameter("@RoleDesc",roleInfo.RoleDesc),new SqlParameter("@id",roleInfo.id)
								  };
            int i = DBHelper.ExecNonQuery(sql, para);
            return i;
        }
        public static int DelRoleInfo(int id)
        {
            string sql = DeleteSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@id",id)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static List<Value> GetAllList()
        {
            string sql = SelectSql;
            return GetListBySql(sql);
        }
        /// <summary>
        /// 根据父级查 
        /// </summary>
        /// <returns></returns>
        public static List<Value> GetList(string pid)
        {
            string sql = SelectSql + " where parentId=@parentId";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@parentId",pid)
								  };
            return GetListBySql(sql, para);
        }
        public static Value row(int id)
        {
            string sql = SelectSqlById;
            SqlParameter para = new SqlParameter("@id", id);
            IList<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
                return list[0];
            else
                return new Value() { hasRow = false };
        }


        public static int GetCount(string pid)
        {
            string sql = "select count(id) from  RoleInfo where parentId=@parentId";

            int result = 0;
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@parentId",pid)
								  };
                    cmd.Parameters.AddRange(para);
                    odc.Open();
                    var sum = cmd.ExecuteScalar();
                    if (!Convert.IsDBNull(sum))
                    {
                        result = Convert.ToInt32(sum);
                    }
                }
            }
            return result;
        }

        private static List<Value> GetListBySql(string sql, params SqlParameter[] para)
        {
            List<Value> list = new List<Value>();
            using (SqlDataReader reader = DBHelper.GetReader(sql, para))
            {
                while (reader.Read())
                {
                    Value temp = new Value();
                    temp.RoleId = DBHelper.GetString(reader["RoleId"]);
                    temp.id = DBHelper.GetInt(reader["id"]);
                    temp.layer = DBHelper.GetInt(reader["layer"]);
                    temp.parentId = DBHelper.GetString(reader["parentId"]);
                    temp.RoleName = DBHelper.GetString(reader["RoleName"]);
                    temp.RoleDesc = DBHelper.GetString(reader["RoleDesc"]);
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
            /// id
            /// </summary>
            public string RoleId
            {
                get;
                set;
            }
            /// <summary>
            /// 权限名称
            /// </summary>
            public string RoleName
            {
                get;
                set;
            }
            /// <summary>
            ///权限描述
            /// </summary>
            public string RoleDesc
            {
                get;
                set;
            }
            /// <summary>
            ///父节点
            /// </summary>
            public string parentId
            {
                get;
                set;
            }
            /// <summary>
            ///层级
            /// </summary>
            public int layer
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

