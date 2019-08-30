


using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;




namespace DAL
{

    public static partial class userData
    {
        //Add Mothed Start

        public static readonly string DeleteSql = "Delete FROM [user]  where id=@id";
        public static readonly string SelectSql = "Select * FROM [user] order by id desc";
        public static readonly string SelectSqlById = "Select * FROM [user] where id =@id";

        public static int Add(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [user](");
            strSql.Append("userId,userName,passWord,phone,createTime,sex,mail,imgSrc,audit,userRole,spending,birthday,cardZ,cardF,[card])");
            strSql.Append(" values (");
            strSql.Append("@userId,@userName,@passWord,@phone,@createTime,@sex,@mail,@imgSrc,@audit,@userRole,@spending,@birthday,@cardZ,@cardF,@card)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@passWord", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@mail", SqlDbType.NVarChar,250),
					new SqlParameter("@imgSrc", SqlDbType.NVarChar,250),
					new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@userRole", SqlDbType.Int,4),
					new SqlParameter("@spending", SqlDbType.Float,8),
					new SqlParameter("@birthday", SqlDbType.DateTime),
                                        new SqlParameter("@cardZ", SqlDbType.VarChar,100),
                                        new SqlParameter("@cardF", SqlDbType.VarChar,100),
                                        new SqlParameter("@card", SqlDbType.VarChar,50)};
            parameters[0].Value = model.userId;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.passWord;
            parameters[3].Value = model.phone;
            parameters[4].Value = model.createTime;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.mail;
            parameters[7].Value = model.imgSrc;
            parameters[8].Value = model.audit;
            parameters[9].Value = model.userRole;
            parameters[10].Value = model.spending;
            parameters[11].Value = model.birthday;
            parameters[12].Value = model.cardZ;
            parameters[13].Value = model.cardF;
            parameters[14].Value = model.card;
            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [user] set ");
            strSql.Append("userName=@userName,");
            strSql.Append("passWord=@passWord,");
            strSql.Append("phone=@phone,");
            strSql.Append("sex=@sex,");
            strSql.Append("mail=@mail,");
            strSql.Append("imgSrc=@imgSrc,");
            strSql.Append("userRole=@userRole,");
            strSql.Append("audit=@audit,");
            strSql.Append("cardF=@cardF,");
            strSql.Append("cardZ=@cardZ,");
            strSql.Append("card=@card,");
            strSql.Append("birthday=@birthday");
            strSql.Append(" where userId=@userId");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@userName", SqlDbType.NVarChar,50),
					new SqlParameter("@passWord", SqlDbType.VarChar,100),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@mail", SqlDbType.NVarChar,250),
					new SqlParameter("@imgSrc", SqlDbType.NVarChar,250),
					new SqlParameter("@userRole", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
                    new SqlParameter("@audit", SqlDbType.Int,4),
                    new SqlParameter("@cardZ", SqlDbType.VarChar,100),
                    new SqlParameter("@cardF", SqlDbType.VarChar,100),
                                        new SqlParameter("@card", SqlDbType.VarChar,50)};
            parameters[0].Value = model.userId;
            parameters[1].Value = model.userName;
            parameters[2].Value = model.passWord;
            parameters[3].Value = model.phone;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.mail;
            parameters[6].Value = model.imgSrc;
            parameters[7].Value = model.userRole;
            parameters[8].Value = model.birthday;
            parameters[9].Value = model.audit;
            parameters[10].Value = model.cardZ;
            parameters[11].Value = model.cardF;
            parameters[12].Value = model.card;
            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdatePwd(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [user] set ");
            strSql.Append("passWord=@passWord");

            strSql.Append(" where userId=@userId");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", model.userId),
				
					new SqlParameter("@passWord", model.passWord)};


            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改额度
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int update(string userid,double price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [user] set ");
            strSql.Append("spending=@spending");

            strSql.Append(" where userId=@userId");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", userid),
				
					new SqlParameter("@spending", price)};


            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        public static int Add(string sql)
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




        public static List<Value> GetAllList()
        {
            string sql = SelectSql;
            return GetListBySql(sql);
        }
        public static List<Value> page(int data,int page,string userid,string phone,int aduit)
        {
            string where = "  userid like @userid and phone like @phone";
            if (aduit != -1)
            {
                where += " and audit="+aduit;
            }
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@userid","%"+userid+"%"),
                                        new SqlParameter("@phone","%"+phone+"%")
								  };
          
            string sql = "select top " + data + " * from [user]  where id not in ( select top " + data * (page - 1) + " id from [user]  where  " + where + "  order by [id] desc )  and " + where + " order by  [id] desc ";
            return GetListBySql(sql, para);
        }
        public static int count( string userid, string phone, int aduit)
        {
            string where = "  userid like @userid and phone like @phone";
            if (aduit != -1)
            {
                where += " and audit=" + aduit;
            }
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@userid","%"+userid+"%"),
                                        new SqlParameter("@phone","%"+phone+"%")
								  };

            string sql = "select  count(id) from [user]  where " + where + " ";
            return (int)DBHelper.getScalar(sql,para);
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
        public static Value row(string userid)
        {
            string sql = "Select * FROM [user] where userid =@userid";
            SqlParameter para = new SqlParameter("@userid", userid);
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
                    temp.userId = DBHelper.GetString(reader["userId"]);
                    temp.passWord = DBHelper.GetString(reader["passWord"]);
                    temp.audit = DBHelper.GetInt(reader["audit"]);
                    temp.birthday = DBHelper.GetDateTime(reader["birthday"]);
                    temp.spending = DBHelper.GetDouble(reader["spending"]);
                    temp.createTime = DBHelper.GetDateTime(reader["createTime"]);
                    temp.imgSrc = DBHelper.GetString(reader["imgSrc"]);
                    temp.mail = DBHelper.GetString(reader["mail"]);
                    temp.phone = DBHelper.GetString(reader["phone"]);
                    temp.sex = DBHelper.GetInt(reader["sex"]);
                    temp.userName = DBHelper.GetString(reader["userName"]);
                    temp.cardF = DBHelper.GetString(reader["cardF"]);
                    temp.card = DBHelper.GetString(reader["card"]);
                    temp.cardZ = DBHelper.GetString(reader["cardZ"]);
                    temp.userRole = DBHelper.GetInt(reader["userRole"]);
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
            ///登录名
            /// </summary>
            public string userId
            {
                get;
                set;
            }
            /// <summary>
            ///真实姓名
            /// </summary>
            public string userName
            {
                get;
                set;
            }
            /// <summary>
            /// 密码
            /// </summary>
            public string passWord
            {
                get;
                set;
            }
            /// <summary>
            /// 手机号码
            /// </summary>
            public string phone
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
            /// 生日
            /// </summary>
            public DateTime birthday
            {
                get;
                set;
            }
            /// <summary>
            /// 会员等级
            /// </summary>
            public int userRole
            {
                get;
                set;
            }
            /// <summary>
            /// 审核 0待审核   1通过    2不通过   3拉黑
            /// </summary>
            public int audit
            {
                get;
                set;
            }
            /// <summary>
            /// 头像
            /// </summary>
            public string imgSrc
            {
                get;
                set;
            }
            /// <summary>
            /// mail
            /// </summary>
            public string mail
            {
                get;
                set;
            }
            /// <summary>
            /// 身份证正面
            /// </summary>
            public string cardZ
            {
                get;
                set;
            }
            /// <summary>
            /// 身份证号
            /// </summary>
            public string card
            {
                get;
                set;
            }
            /// <summary>
            /// 身份证反面
            /// </summary>
            public string cardF
            {
                get;
                set;
            }
            /// <summary>
            /// 性别1男0女
            /// </summary>
            public int sex
            {
                get;
                set;
            }
            /// <summary>
            /// 已用额度
            /// </summary>
            public double spending
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
