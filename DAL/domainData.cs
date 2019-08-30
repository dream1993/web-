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
    public class domainData : publicData
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
                    cmd.CommandText = "delete from [domain] where [id] = @id";
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
        /// 增加一条数据
        /// </summary>
        public static int Add(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into domain(");
            strSql.Append("adminId,company,contactName,phone,email,createTime,domainName,ftp,remarks,adminName,domainTime,serverTime,isUsFtp,isUsServer,domainRemarks,isUsDomain,ftpTime,server)");
            strSql.Append(" values (");
            strSql.Append("@adminId,@company,@contactName,@phone,@email,@createTime,@domainName,@ftp,@remarks,@adminName,@domainTime,@serverTime,@isUsFtp,@isUsServer,@domainRemarks,@isUsDomain,@ftpTime,@server)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@company", model.company),
					new SqlParameter("@contactName", model.contactName),
                    new SqlParameter("@adminId", model.adminId),
					new SqlParameter("@phone",model.phone),
					new SqlParameter("@email",model.email),
					new SqlParameter("@createTime",model.createTime),
					new SqlParameter("@domainName",model.domainName),
					new SqlParameter("@ftp",model.ftp),
					new SqlParameter("@remarks",model.remarks),
					new SqlParameter("@adminName",model.adminName),
					new SqlParameter("@domainTime",model.domainTime),
					new SqlParameter("@serverTime",model.serverTime),
					new SqlParameter("@isUsFtp",model.isUsFtp),
					new SqlParameter("@isUsServer",model.isUsServer),
					new SqlParameter("@isUsDomain",model.isUsDomain),
                    new SqlParameter("@domainRemarks",model.domainRemarks),
                    new SqlParameter("@ftpTime",model.ftpTime),
                    new SqlParameter("@server",model.server)};
            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int Update(Value model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update domain set ");
            strSql.Append("company=@company,");
            strSql.Append("contactName=@contactName,");
            strSql.Append("phone=@phone,");
            strSql.Append("email=@email,");
            strSql.Append("domainName=@domainName,");
            strSql.Append("ftp=@ftp,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("adminName=@adminName,");
            strSql.Append("serverTime=@serverTime,");
            strSql.Append("isUsFtp=@isUsFtp,");
            strSql.Append("isUsServer=@isUsServer,");
            strSql.Append("domainRemarks=@domainRemarks,");
            strSql.Append("isUsDomain=@isUsDomain,");
            strSql.Append("ftpTime=@ftpTime,");
            strSql.Append("domainTime=@domainTime,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("searchcompany=@searchcompany,");
            strSql.Append("server=@server");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", model.id),
				    new SqlParameter("@company", model.company),
					new SqlParameter("@contactName", model.contactName),
					new SqlParameter("@phone",model.phone),
					new SqlParameter("@email",model.email),
					new SqlParameter("@createTime",model.createTime),
					new SqlParameter("@domainName",model.domainName),
					new SqlParameter("@ftp",model.ftp),
					new SqlParameter("@remarks",model.remarks),
					new SqlParameter("@adminName",model.adminName),
					new SqlParameter("@domainTime",model.domainTime),
					new SqlParameter("@serverTime",model.serverTime),
					new SqlParameter("@isUsFtp",model.isUsFtp),
					new SqlParameter("@isUsServer",model.isUsServer),
					new SqlParameter("@isUsDomain",model.isUsDomain),
                    new SqlParameter("@domainRemarks",model.domainRemarks),
                    new SqlParameter("@ftpTime",model.ftpTime),
                    new SqlParameter("@server",model.server)};
            return DBHelper.ExecNonQuery(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 根查询全部
        /// </summary>
        /// <returns></returns>
        public static List<Value> table()
        {
            var sql = "select * from [domain] order by [id] desc";
            return GetListBySql(sql);

        }
        public static int count(string search)
        {
            string where = "";
            if (!string.IsNullOrEmpty(search))
            {
                where = " where domainName like @searchcompany or company like @searchcompany or contactName like @searchcompany or phone like @searchcompany or email like @searchcompany  ";
            }
            var sql = "select count(id) from [domain]  " + where;
            if (!string.IsNullOrEmpty(search))
            {
                SqlParameter para = new SqlParameter("@searchcompany", "%" + search + "%");
                return (int)DBHelper.getScalar(sql, para);
            }
            return (int)DBHelper.getScalar(sql);
        }
        public static List<Value> table(int ishear, int top, int phone)
        {
            string where = " where  email ='true' and domainName='false' ";
            if (ishear == 1)
            {
                where += " and isUsFtp='true'";
            }
            if (ishear == 2)
            {
                where += " and isUsServer='true' and phone in (select id from [type] where phone like '%," + phone + "%,')";
            }
            if (ishear == 3)
            {
                where += " and isUsDomain='true' and phone=" + phone;
            }
            var sql = "select top " + top + " * from [domain] " + where + "order by [id] desc";
            return GetListBySql(sql);

        }
        public static List<Value> table(int top, int phone)
        {
            string where = " where  email ='true' and domainName='false' ";
            where += "  and phone in (select id from [type] where phone like '%," + phone + "%,')";
            var sql = "select top " + top + " * from [domain] " + where + "order by [id] desc";
            return GetListBySql(sql);
        }
        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static Value row(string id)
        {
            string sql = "select * from [domain] where [userid] = @id";
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
            string sql = "select * from [domain] where [id] = @id ";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        /// <summary>
        /// 展示用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Value rowq(int id)
        {
            string sql = "select * from [domain] where [id] = @id and domainName='false' and email='true'";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        public static List<Value> row(int top, int phone, int type)
        {
            string str = "";
            if (type == 1)
            {
                str = " and isUsFtp='true'";
            }
            if (type == 2)
            {
                str = " and isUsServer='true'";
            }
            if (type == 3)
            {
                str = " and isUsDomain='true'";
            }
            string sql = "select top " + top + " * from [domain] where [phone] in (select id from [type] where phone like '%," + phone + ",%') " + str + " order by sort desc,serverTime desc,id desc";

            List<Value> list = GetListBySql(sql);

            return list;
        }
        public static List<Value> page(int phone, int page, int data)
        {
            string sql = " select top " + data + " * from [domain]  where id not in ( select top " + data * (page - 1) + " id from [domain]  where [domainName] = 'false' and [phone] in (select id from [type] where phone like  '%," + phone + ",%')  order by [sort] desc,[domainTime] desc, [id] desc ) and [domainName] = 'false' and [phone] in (select id from [type] where phone like  '%," + phone + ",%') order by [sort] desc,[domainTime] desc, [id] desc";
            return GetListBySql(sql);
        }
        public static List<Value> page(int page, int data, string search)
        {
            string where = "";
            if (!string.IsNullOrEmpty(search))
            {
                where = " and (domainName like @searchcompany or company like @searchcompany or contactName like @searchcompany or phone like @searchcompany or email like @searchcompany)  ";
            }
            string order = "  order by [domainTime] ,[ftpTime] , [serverTime] ,id desc";

            string sql = " select top " + data + " * from [domain]  where id not in ( select top " + data * (page - 1) + " id from [domain]  where 1=1 " + where + order+"  ) and  " + where + order;
            if (!string.IsNullOrEmpty(search))
            {
                SqlParameter para = new SqlParameter("@search", "%" + search + "%");
                return GetListBySql(sql, para);
            }
            return GetListBySql(sql);
        }
        public static int counth(int type, int typepro, string email, string company)
        {
            int phone = 1;
            if (typepro != -1)
            {
                phone = typepro;
            }
            if (type != -1)
            {
                phone = type;
            }
            string where = "";
            if (!string.IsNullOrEmpty(company))
            {
                where += " and company like @company ";

            }
            if (!string.IsNullOrEmpty(email))
            {
                where += " and email = '" + bool.Parse(email) + "'";
            }

            string sql = " select  count(id)  from [domain]  where  [domainName] = 'false' " + where + " and [phone] in (select id from [type] where phone like  '%," + phone + ",%' )";
            if (!string.IsNullOrEmpty(company))
            {
                SqlParameter para = new SqlParameter("@company", "%" + company + "%");
                return (int)DBHelper.getScalar(sql, para);
            }
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
                    temp.ftp = DBHelper.GetString(dr["ftp"]);
                    temp.adminName = DBHelper.GetString(dr["adminName"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                    temp.adminId = DBHelper.GetInt(dr["adminId"]);
                    temp.company = DBHelper.GetString(dr["company"]);
                    temp.domainTime = DBHelper.GetDateTime(dr["domainTime"]);
                    temp.serverTime = DBHelper.GetDateTime(dr["serverTime"]);
                    temp.remarks = DBHelper.GetString(dr["remarks"]);
                    temp.contactName = DBHelper.GetString(dr["contactName"]);
                    temp.createTime = DBHelper.GetDateTime(dr["createTime"]);
                    temp.isUsDomain = DBHelper.GetBoolean(dr["isUsDomain"]);
                    temp.domainName = DBHelper.GetString(dr["domainName"]);
                    temp.isUsFtp = DBHelper.GetBoolean(dr["isUsFtp"]);
                    temp.isUsServer = DBHelper.GetBoolean(dr["isUsServer"]);
                    temp.email = DBHelper.GetString(dr["email"]);
                    temp.domainRemarks = DBHelper.GetString(dr["domainRemarks"]);
                    temp.ftpTime = DBHelper.GetDateTime(dr["ftpTime"]);
                    temp.server = DBHelper.GetString(dr["server"]);
                    temp.phone = DBHelper.GetString(dr["phone"]);
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
            /// 管理员标示
            /// </summary>
            public int adminId
            {
                get;
                set;
            }
            /// <summary>
            /// 公司名称
            /// </summary>
            public string company
            {
                get;
                set;
            }
            /// <summary>
            /// 联系人姓名
            /// </summary>
            public string contactName
            {
                get;
                set;
            }
            /// <summary>
            ///手机号码
            /// </summary>
            public string phone
            {
                get;
                set;
            }
            /// <summary>
            ///  邮箱
            /// </summary>
            public string email
            {
                get;
                set;
            }
            /// <summary>
            /// 域名到期时间
            /// </summary>
            public DateTime domainTime
            {
                get;
                set;
            }
            /// <summary>
            /// 数据库到期时间
            /// </summary>
            public DateTime serverTime
            {
                get;
                set;
            }
            /// <summary>
            /// ftp到期时间
            /// </summary>
            public DateTime ftpTime
            {
                get;
                set;
            }
            /// <summary>
            /// 创建日期
            /// </summary>
            public DateTime createTime
            {
                get;
                set;
            }
            /// <summary>
            /// 域名
            /// </summary>
            public string domainName
            {
                get;
                set;
            }
            /// <summary>
            /// 域名备注信息
            /// </summary>
            public string domainRemarks
            {
                get;
                set;
            }
            /// <summary>
            /// ftp信息
            /// </summary>
            public string ftp
            {
                get;
                set;
            }
            /// <summary>
            /// 数据库信息
            /// </summary>
            public string server
            {
                get;
                set;
            }
            /// <summary>
            /// 备注信息
            /// </summary>
            public string remarks
            {
                get;
                set;
            }
            /// <summary>
            /// 管理员姓名
            /// </summary>
            public string adminName
            {
                get;
                set;
            }
            /// <summary>
            /// 是否在我司购买ftp
            /// </summary>
            public bool isUsFtp
            {
                get;
                set;
            }
            /// <summary>
            /// 是否在我司购买数据库
            /// </summary>
            public bool isUsServer
            {
                get;
                set;
            }
            /// <summary>
            /// 是否在我司购买域名
            /// </summary>
            public bool isUsDomain
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
