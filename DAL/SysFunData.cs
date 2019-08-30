//============================================================
// Producnt name:		TenXiang.Code
// Coded by:			hotboart
// Auto generated at: 	2014/1/5 11:48:50
//============================================================



using System;						
using System.Collections.Generic;	
using System.Text;					
using System.Data;					
using System.Data.SqlClient;		


namespace DAL
{

    public static partial class SysFunData
	{	
		//Add Mothed Start
        public static readonly string InsertSql = "INSERT SysFun (DisplayName, NodeURL, DisplayOrder, ParentNodeId)VALUES (@DisplayName, @NodeURL, @DisplayOrder, @ParentNodeId)";
        public static readonly string UpdateSql = "Update SysFun set DisplayName=@DisplayName, NodeURL=@NodeURL, DisplayOrder=@DisplayOrder where NodeId=@NodeId";
        public static readonly string DeleteSql = "Delete FROM SysFun  where NodeId=@NodeId";
        public static readonly string SelectSql = "Select * FROM SysFun";
        public static readonly string SelectSqlById = "Select * FROM SysFun where NodeId =@NodeId";
	    public static int AddValue(Value Value)
	    {								
			string sql = InsertSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@DisplayName",Value.DisplayName),new SqlParameter("@NodeURL",Value.NodeURL), new SqlParameter("@DisplayOrder",Value.DisplayOrder), new SqlParameter("@ParentNodeId",Value.ParentNodeId)
								  }	;									
    	    return DBHelper.ExecNonQuery(sql, para);
		}  
		public static int UpdateValue(Value Value)
	    {								
			string sql = UpdateSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@NodeId",Value.NodeId), new SqlParameter("@DisplayName",Value.DisplayName), new SqlParameter("@NodeURL",Value.NodeURL), new SqlParameter("@DisplayOrder",Value.DisplayOrder)
								  }	;									
    	    return DBHelper.ExecNonQuery(sql, para);
		}  
		public static int DelValue(int NodeId)
	    {								
			string sql = DeleteSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@NodeId",NodeId)
								  }	;									
    	    return DBHelper.ExecNonQuery(sql, para);
		}
		public static IList< Value > GetAllList()
		{								
			string sql = SelectSql;
    	    return GetListBySql(sql);
		}

        public static IList<Value> GetAllListByRoleId(string userid)
        {
            string sql = "select * from SysFun where NodeId in (select NodeId  from RoleRight where roleid=(select RoleId  from UserInfo where UserId='" + userid + "')) and  ParentNodeId=0";
            return GetListBySql(sql);
        }
        public static IList<Value> GetAllListByRoleId(int pnode)
        {
            string sql = "select * from SysFun where   ParentNodeId=" + pnode;
            return GetListBySql(sql);
        }
        //根据节点和用户来判断它可以访问的页面
        public static IList<Value> GetAllListByNodeId(int nodeId, string userid)
        {
            string sql = "select * from SysFun where ParentNodeId=@ParentNodeId and  NodeId in (select NodeId  from RoleRight where roleid=(select RoleId  from UserInfo where UserId='" + userid + "'))";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@ParentNodeId",nodeId)
								  };
            return GetListBySql(sql, para);
        }
		public static Value row(int NodeId)  
		{								
			string sql = SelectSqlById;
			SqlParameter para = new SqlParameter("@NodeId",NodeId);
    	    IList< Value > list =  GetListBySql(sql,para);
			if(list.Count>0)
			   return list[0];
			else
                return new Value() { hasRow = false };
		}
		
		private static IList< Value > GetListBySql(string sql,params SqlParameter[] para)
		{
			IList< Value > list = new List< Value >();
			using (SqlDataReader reader = DBHelper.GetReader(sql,para))
			{
				while(reader.Read())
				{
					Value temp = new Value();
					
					  temp.NodeId	=DBHelper.GetInt(reader["NodeId"]);
					  temp.DisplayName	=DBHelper.GetString(reader["DisplayName"]);
					  temp.NodeURL	=DBHelper.GetString(reader["NodeURL"]);
					  temp.DisplayOrder	=DBHelper.GetInt(reader["DisplayOrder"]);
					  temp.ParentNodeId	=DBHelper.GetInt(reader["ParentNodeId"]);
					
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
            public int NodeId
            {
                get;
                set;
            }
            /// <summary>
            /// 链接名称
            /// </summary>
            public string DisplayName
            {
                get;
                set;
            }
            /// <summary>
            /// 链接地址
            /// </summary>
            public string NodeURL
            {
                get;
                set;
            }
            /// <summary>
            ///排序
            /// </summary>
            public int DisplayOrder
            {
                get;
                set;
            }
            /// <summary>
            ///父节点
            /// </summary>
            public int ParentNodeId
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
		
