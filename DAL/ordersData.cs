using System;
using System.Collections;
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
    public class ordersData : publicData
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
                    cmd.CommandText = "delete from [orders] where [id] = @id";
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
            strSql.Append("insert into [orders](");
            strSql.Append("aid,pid,userid,createTime,price,remake,startTime,state,proname,orderId)");
            strSql.Append(" values (");
            strSql.Append("@aid,@pid,@userid,@createTime,@price,@remake,@startTime,@state,@proname,@orderId)");
            strSql.Append(";select @@IDENTITY");
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = strSql.ToString();
                    cmd.Parameters.AddRange(new SqlParameter[]{
                         new SqlParameter("@aid",model.aid),
                         new SqlParameter("@pid",model.pid),
                         new SqlParameter("@userid",model.userid),
                         new SqlParameter("@createTime",model.createTime),
                         new SqlParameter("@price",model.price),
                         new SqlParameter("@remake",model.remake),
                         new SqlParameter("@startTime",model.startTime),
                         new SqlParameter("@state",model.state),
                             new SqlParameter("@orderId",DateTime.Now.ToString("yyyyMMddHHmmss")+rund(4)),
                         new SqlParameter("@proname",model.proname)
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
        public static string rund(int num)
        {
            ArrayList MyArray = new ArrayList();
            Random random = new Random();
            string str = null;
            //循环的次数     
            int Nums = num;
            while (Nums > 0)
            {
                int i = random.Next(0, 9);
                //  if (!MyArray.Contains(i))  
                //  {  
                if (MyArray.Count < 6)
                {
                    MyArray.Add(i);
                }
                // }  
                Nums -= 1;
            }
            for (int j = 0; j <= MyArray.Count - 1; j++)
            {
                str += MyArray[j].ToString();
            }
            return str;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public static bool price(string userid, string price)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [orders] set [price] = @price,[remake]=@remake where [userid] = @userid";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@userid",userid),
                        new SqlParameter("@remake",DateTime.Now),
                        new SqlParameter("@price",price)
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
                    cmd.CommandText = "update [orders] set [aid] = @pwd where [userid] = @userid";
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
                    cmd.CommandText = "update [orders] set [aid] = @pwd where [id] = @id";
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
        public static bool update(int id, int state,double price)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [orders] set [state] = @state,[price]=@price where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@id",id),
                        new SqlParameter("@price",price),
                        new SqlParameter("@state",state)
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
            var sql = "select * from [orders] order by [id] desc";
            return GetListBySql(sql);
        }
        /// <summary>
        /// 根查询全部
        /// </summary>
        /// <returns></returns>
        public static int count(int state,string start,string end,string userid)
        {
            var sql = "select count(id) from [orders] where 1=1 ";
            if (state != -1)
            {
                sql += " and [state]="+state;
            }
            if ((!string.IsNullOrEmpty(start)) && (!string.IsNullOrEmpty(end)))
            {
                sql += " and createTime between '"+DateTime.Parse(start)+"' and '"+DateTime.Parse(end)+"' ";
            }
            if (!string.IsNullOrEmpty(userid))
            {
                sql += " and userid=@userid";
                SqlParameter[] par = new SqlParameter[]{
                        new SqlParameter("@userid",userid)
                    };
                return (int)DBHelper.getScalar(sql,par);
            }
            return (int)DBHelper.getScalar(sql);
        }
        public static List<Value> table(int state, string start, string end, string userid)
        {
            var sql = "select * from [orders] where 1=1 ";
            if (state != -1)
            {
                sql += " and [state]=" + state;
            }
            if ((!string.IsNullOrEmpty(start)) && (!string.IsNullOrEmpty(end)))
            {
                sql += " and createTime between '" + DateTime.Parse(start) + "' and '" + DateTime.Parse(end) + "' ";
            }
            if (!string.IsNullOrEmpty(userid))
            {
                sql += " and userid=@userid";
                SqlParameter[] par = new SqlParameter[]{
                        new SqlParameter("@userid",userid)
                    };
                return GetListBySql(sql, par);
            }
            return GetListBySql(sql);
        }
        public static List<Value> page(int state, string start, string end, string userid,int data,int page)
        {
            string sql = " ";
           
            if (state != -1)
            {
                sql += " and [state]=" + state;
            }
            if ((!string.IsNullOrEmpty(start)) && (!string.IsNullOrEmpty(end)))
            {
                sql += " and createTime between '" + DateTime.Parse(start) + "' and '" + DateTime.Parse(end) + "' ";
            }
            var sqls = "select top " + data + " * from [orders]  where id not in ( select top " + data * (page - 1) + " id from [orders]  where 1=1 "+sql+"  order by [id] desc ) "+sql+" order by  [id] desc ";
            if (!string.IsNullOrEmpty(userid))
            {
                sql += " and userid=@userid";
                sqls = "select top " + data + " * from [orders]  where id not in ( select top " + data * (page - 1) + " id from [orders]  where 1=1 " + sql + "  order by [id] desc ) " + sql + " order by  [id] desc ";
                SqlParameter[] par = new SqlParameter[]{
                        new SqlParameter("@userid",userid)
                    };
                return GetListBySql(sqls,par);
            }
            return  GetListBySql(sqls);
        }
        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static Value row(string id)
        {
            string sql = "select * from [orders] where [userid] = @id";
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
            string sql = "select * from [orders] where [id] = @id";
            SqlParameter para = new SqlParameter("@id", id);
            List<Value> list = GetListBySql(sql, para);
            if (list.Count > 0)
            {
                return list[0];
            }
            return new Value() { hasRow = false };
        }
        public static Value rowpro(int pid,string userid)
        {
            string sql = "select * from [orders] where [pid] = "+pid+" and createTime>'"+DateTime.Now.AddMonths(-1)+"' and state<>2 and userid=@userid";
            SqlParameter para = new SqlParameter("@userid", userid);
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
                    temp.proname = DBHelper.GetString(dr["proname"]);
                    temp.id = DBHelper.GetInt(dr["id"]);
                    temp.state = DBHelper.GetInt(dr["state"]);
                    temp.createTime = DBHelper.GetDateTime(dr["createTime"]);
                    temp.startTime = DBHelper.GetDateTime(dr["startTime"]);
                    temp.remake = DBHelper.GetString(dr["remake"]);
                    temp.orderId = DBHelper.GetString(dr["orderId"]);
                    temp.price = DBHelper.GetDouble(dr["price"]);
                    temp.aid = DBHelper.GetInt(dr["aid"]);
                    temp.pid = DBHelper.GetInt(dr["pid"]);
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
            /// 所属会员
            /// </summary>
            public string userid
            {
                get;
                set;
            }
            /// <summary>
            /// 订单名称
            /// </summary>
            public string proname
            {
                get;
                set;
            }
            /// <summary>
            ///产品编号
            /// </summary>
            public int pid
            {
                get;
                set;
            }
            /// <summary>
            /// 订单金额
            /// </summary>
            public double price
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
            /// 订单审核时间
            /// </summary>
            public DateTime startTime
            {
                get;
                set;
            }
            /// <summary>
            /// 订单状态  0待审核1通过2未通过3已发货4已收货5逾期6订单完成
            /// </summary>
            public int state
            {
                get;
                set;
            }
            /// <summary>
            /// 地址id（待用）
            /// </summary>
            public int aid
            {
                get;
                set;
            }
            /// <summary>
            /// 备注
            /// </summary>
            public string remake
            {
                get;
                set;
            }
            /// <summary>
            /// 订单编号
            /// </summary>
            public string orderId
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
