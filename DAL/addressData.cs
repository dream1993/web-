using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace DAL
{
    public class addressData : publicData
    {



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into address(");
            strSql.Append("userid,name,sheng,city,xian,address,phone,[state])");
            strSql.Append(" values (");
            strSql.Append("@userid,@name,@sheng,@city,@xian,@address,@phone,@state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@sheng", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@xian", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.sheng;
            parameters[3].Value = model.city;
            parameters[4].Value = model.xian;
            parameters[5].Value = model.address;
            parameters[6].Value = model.phone;
            parameters[7].Value = 0;

            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update address set ");
            strSql.Append("name=@name,");
            strSql.Append("sheng=@sheng,");
            strSql.Append("city=@city,");
            strSql.Append("xian=@xian,");
            strSql.Append("address=@address,");
            strSql.Append("phone=@phone,");
            strSql.Append("[state]=@state");
            strSql.Append(" where userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@sheng", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@xian", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.name;
            parameters[2].Value = model.sheng;
            parameters[3].Value = model.city;
            parameters[4].Value = model.xian;
            parameters[5].Value = model.address;
            parameters[6].Value = model.phone;
            parameters[7].Value = 0;


            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(string userid, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update address set ");
            strSql.Append("[state]=@state");
            strSql.Append(" where userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = userid;
            parameters[1].Value = state;
            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Value GetModel(string userid)
        {
            string sql = "select * from [address] where [userid] = @userid";
            SqlParameter para = new SqlParameter("@userid", userid);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        public static int Del(string id)
        {
            string sql = "Delete FROM [address]  where userid=@id";
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@id",id)
								  };
            return DBHelper.ExecNonQuery(sql, para);
        }
        public static List<Value> page(int data, int page, string userid, int state)
        {
            string where = "  userid like @userid ";
            if (state != -1)
            {
                where += " and state=" + state;
            }
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@userid","%"+userid+"%")
								  };

            string sql = "select top " + data + " * from [address]  where id not in ( select top " + data * (page - 1) + " id from [address]  where  " + where + "  order by [id] desc )  and " + where + " order by  [id] desc ";
            return GetListBySql(sql, para);
        }
        public static int count(string userid, int state)
        {
            string where = "  userid like @userid ";
            if (state != -1)
            {
                where += " and state=" + state;
            }
            SqlParameter[] para = new SqlParameter[]
           						  {
										new SqlParameter("@userid","%"+userid+"%")
								  };

            string sql = "select  count(id) from [address]  where " + where + " ";
            return (int)DBHelper.getScalar(sql, para);
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
                    temp.address = DBHelper.GetString(dr["address"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                    temp.state = DBHelper.GetInt(dr["state"]);
                    temp.city = DBHelper.GetString(dr["city"]);
                    temp.name = DBHelper.GetString(dr["name"]);
                    temp.phone = DBHelper.GetString(dr["phone"]);
                    temp.sheng = DBHelper.GetString(dr["sheng"]);
                    temp.xian = DBHelper.GetString(dr["xian"]);
                    temp.hasRow = true;
                    list.Add(temp);
                }
                dr.Close();
                return list;
            }
        }

        public struct Value
        {


            /// <summary>
            /// 
            /// </summary>
            public int id
            {
                set;
                get;
            }
            /// <summary>
            /// 地址审核
            /// </summary>
            public int state
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string userid
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string name
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string sheng
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string city
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string xian
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string address
            {
                set;
                get;
            }
            /// <summary>
            /// 
            /// </summary>
            public string phone
            {
                set;
                get;
            }
            public bool hasRow { get; set; }
        }

    }
}