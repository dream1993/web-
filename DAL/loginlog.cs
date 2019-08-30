//============================================================
// Producnt name:		TenXiang.Code
// Coded by:			hotboart
// Auto generated at: 	2014/1/5 11:46:40
//============================================================



using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;




namespace DAL
{

    public static partial class loginlog
    {
        //Add Mothed Start
        public static readonly string InsertSql = "INSERT LoginLog (UserId, LoginTime, IfSuccess, LoginUserIp, LoginDesc)VALUES (@UserId, @LoginTime, @IfSuccess, @LoginUserIp, @LoginDesc)";
        public static readonly string UpdateSql = "Update LoginLog set UserId=@UserId, LoginTime=@LoginTime, IfSuccess=@IfSuccess, LoginUserIp=@LoginUserIp, LoginDesc=@LoginDesc where LoginId=@LoginId";
        public static readonly string DeleteSql = "Delete FROM LoginLog  where LoginId=@LoginId";
        public static readonly string SelectSql = "Select * FROM LoginLog";
        public static readonly string SelectSqlById = "Select * FROM LoginLog where LoginId =@LoginId";
        public static int AddLoginLog(Value loginLog)
        {
            string sql = InsertSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@UserId",loginLog.UserId), new SqlParameter("@LoginTime",loginLog.LoginTime), new SqlParameter("@IfSuccess",loginLog.IfSuccess), new SqlParameter("@LoginUserIp",loginLog.LoginUserIp), new SqlParameter("@LoginDesc",loginLog.LoginDesc)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int UpdateLoginLog(Value loginLog)
        {
            string sql = UpdateSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@LoginId",loginLog.LoginId), new SqlParameter("@UserId",loginLog.UserId), new SqlParameter("@LoginTime",loginLog.LoginTime), new SqlParameter("@IfSuccess",loginLog.IfSuccess), new SqlParameter("@LoginUserIp",loginLog.LoginUserIp), new SqlParameter("@LoginDesc",loginLog.LoginDesc)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static int DelLoginLog(Value loginLog)
        {
            string sql = DeleteSql;
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@LoginId",loginLog.LoginId)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static IList<Value> GetAllList()
        {
            string sql = SelectSql;
            return GetListBySql(sql);
        }


        public static Value GetLoginLogByLoginId(int LoginId)
        {
            string sql = SelectSqlById;
            SqlParameter para = new SqlParameter("@LoginId", LoginId);
            IList<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
                return list[0];
            else
                return new Value() { hasRow=false};
        }

        private static IList<Value> GetListBySql(string sql, params SqlParameter[] para)
        {
            IList<Value> list = new List<Value>();
            using (SqlDataReader reader = DBHelper.GetReader(sql, para))
            {
                while (reader.Read())
                {
                    Value temp = new Value();

                    temp.LoginId = DBHelper.GetInt(reader["LoginId"]);
                    temp.UserId = DBHelper.GetString(reader["UserId"]);
                    temp.LoginTime = DBHelper.GetDateTime(reader["LoginTime"]);
                    temp.IfSuccess = DBHelper.GetInt(reader["IfSuccess"]);
                    temp.LoginUserIp = DBHelper.GetString(reader["LoginUserIp"]);
                    temp.LoginDesc = DBHelper.GetString(reader["LoginDesc"]);
                    //temp.User	=UserInfoService.GetUserInfoByUserId(temp.UserId);

                    list.Add(temp);
                }
                reader.Close();
                return list;
            }
        }

        public static IList<Value> getByUserIdList(string t1, string t2, string UserId)
        {
            string sql = SelectSql;
            SqlParameter[] para = new SqlParameter[] { };
            if (UserId.Length == 0 && t1.Length != 0)
            {
                sql += " where LoginTime between @t1 and @t2";
                para = new SqlParameter[]
           						  {
										new SqlParameter("@t1",DateTime.Parse(t1)),
                                        new SqlParameter("@t2",DateTime.Parse(t2).AddDays(1)),
                                      
								  };
            }
            else if (UserId.Length != 0 && t1.Length != 0)
            {
                sql += " where LoginTime between @t1 and @t2 and userid=@UserId";
                para = new SqlParameter[]
           						  {
										new SqlParameter("@t1",DateTime.Parse(t1)),
                                        new SqlParameter("@t2",DateTime.Parse(t2).AddDays(1)),
                                        new SqlParameter("@UserId",UserId),
								  };
            }
            else if (UserId.Length != 0 && t1.Length == 0)
            {
                sql += " where  userid=@UserId";
                para = new SqlParameter[]
           						  {
										
                                        new SqlParameter("@UserId",UserId),
								  };
            }
            if (para.Length == 0)
                return GetListBySql(sql);
            else
                return GetListBySql(sql, para);
        }
        public struct Value
        {

		//PK	
		//[DBField("LoginId")]
        public int LoginId{get;set;}				
		
        
		//FK
		
		//[DBField("UserId")]
		public string UserId{get;set;}				
			
		//Column
		//[DBField("LoginTime")]
		public DateTime LoginTime{get;set;}	
		//[DBField("IfSuccess")]
		public int IfSuccess{get;set;}	
		//[DBField("LoginUserIp")]
		public string LoginUserIp{get;set;}	
		//[DBField("LoginDesc")]
		public string LoginDesc{get;set;}
        public bool hasRow { get; set; }	
        }
    }
}

