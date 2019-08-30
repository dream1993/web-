using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 分类
    /// </summary>
    public class typeData : publicData
    {
        /// <summary>
        /// 添加分类信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool add(Value v)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "insert into [type] ([title],[imgSrc],[content],[parentId],[typeId],[layer],[sort],[view],img) values (@title,@imgSrc,@content,@parentId,@typeId,@layer,@sort,@view,@img)";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@title",v.title),
                        new SqlParameter("@imgSrc",v.imgSrc),
                        new SqlParameter("@content",v.content),
                        new SqlParameter("@parentId",v.parentId),
                        new SqlParameter("@typeId",v.typeId),
                        new SqlParameter("@img",v.img),
                        new SqlParameter("@layer",v.layer),
                        new SqlParameter("@sort", sort()),
                        new SqlParameter("@view",v.view),
                    });
                    odc.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 通过ID删除类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delete(int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "delete from [type] where [id] = @id;delete from [type] where [typeId] like '%," + id + ",%';";
                    cmd.Parameters.Add("@id", id);
                    odc.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool update(Value v)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [type] set [title] = @title , [imgSrc] = @imgSrc , [content] = @content , [view] = @view,[img]=@img  where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@title",v.title),
                        new SqlParameter("@imgSrc",v.imgSrc),
                         new SqlParameter("@img",v.img),
                        new SqlParameter("@content",v.content),
                        new SqlParameter("@view",v.view),
                        new SqlParameter("@id",v.id)
                    });
                    odc.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// 更新typeId
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool typeId(Value v)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [type] set [typeId] = @typeId where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@typeId",v.typeId),
                        new SqlParameter("@id",v.id)
                    });
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
        /// 通过ID查行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Value row(int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select * from [type] where [id] = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    odc.Open();
                    var dr = cmd.ExecuteReader();
                    var v = new Value();
                    if (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.content = dr["content"].ToString();
                        v.parentId = Convert.ToInt32(dr["parentId"]);
                        v.typeId = dr["typeId"].ToString();
                        v.layer = Convert.ToInt32(dr["layer"]);
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.img = dr["img"].ToString();
                        v.hasRow = true;
                    }
                    else
                    {
                        v.hasRow = false;
                    }
                    return v;
                }
            }
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public static DataTable table()
        {
            string sql = "select * from [type] order by [sort] desc,[id] desc";
            return Odt(sql);
        }

        /// <summary>
        /// 通过父级ID
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static DataTable table(int preatId)
        {
            string sql = "select * from [type] order by [sort] desc,[id] desc";
            var oldData = Odt(sql);
            var newData = oldData.Clone();
            getChild(oldData, newData, preatId);
            return newData;
        }

        /// <summary>
        /// 根据父ID查询显示的列表 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<typeData.Value> list(int parentId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select * from [type] where [parentId] = @parentId and [view] = 'true' order by [sort] ";
                    cmd.Parameters.Add(new SqlParameter("@parentId", parentId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<typeData.Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.content = dr["content"].ToString();
                        v.parentId = Convert.ToInt32(dr["parentId"]);
                        v.typeId = dr["typeId"].ToString();
                        v.layer = Convert.ToInt32(dr["layer"]);
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.img = dr["img"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }

        /// <summary>
        /// 根据父ID查询显示的列表 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<typeData.Value> list(int parentId, int top)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select top " + top + " * from [type] where [parentId] = @parentId and [view] = 'true' order by [sort] desc";
                    cmd.Parameters.Add(new SqlParameter("@parentId", parentId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<typeData.Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.img = dr["img"].ToString();
                        v.content = dr["content"].ToString();
                        v.parentId = Convert.ToInt32(dr["parentId"]);
                        v.typeId = dr["typeId"].ToString();
                        v.layer = Convert.ToInt32(dr["layer"]);
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                 
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过父级ID查找显示的类型列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static DataTable listtype(int preatId)
        {
            string sql = "select * from [type] where [view] = 'true' order by [sort] desc,[id] desc";
            var oldData = Odt(sql);
            var newData = oldData.Clone();
            getChild(oldData, newData, preatId);
            return newData;
        }

        /// <summary>
        /// 通过父级ID 罗列顺序
        /// </summary>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <param name="pid"></param>
        public static void getChild(DataTable oldData, DataTable newData, int pid)
        {
            DataRow[] dr = oldData.Select("ParentId=" + pid);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = Convert.ToInt32(dr[i]["id"]);
                row["title"] = dr[i]["title"].ToString();
                row["imgSrc"] = dr[i]["imgSrc"].ToString();
                row["content"] = dr[i]["content"].ToString();
                row["parentId"] = Convert.ToInt32(dr[i]["parentId"]);
                row["typeId"] = dr[i]["typeId"].ToString();
                row["layer"] = Convert.ToInt32(dr[i]["layer"]);
                row["sort"] = Convert.ToInt32(dr[i]["sort"]);
                row["view"] = Convert.ToBoolean(dr[i]["view"]);
              
                newData.Rows.Add(row);
                //调用自身迭代
                getChild(oldData, newData, int.Parse(dr[i]["Id"].ToString()));
            }
        }
        /// <summary>
        /// 显示/隐藏
        /// </summary>
        /// <param name="view">显示、隐藏</param>
        /// <param name="id">该行id</param>
        /// <returns></returns>
        public static bool view(bool view, int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand("update [type] set [view] = @view where [id] = @id", odc))
                {
                    cmd.Parameters.AddRange(new SqlParameter[] { 
                        new SqlParameter("@view",view),
                        new SqlParameter("@id",id)
                    });
                    odc.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="idA">行AID</param>
        /// <param name="idB">行BID</param>
        /// <param name="ha">行A排序</param>
        /// <param name="hb">行B排序</param>
        /// <returns></returns>
        public static bool sort(int idA, int idB, int ha, int hb)
        {
            using (var odc = Odc())
            {
                odc.Open();
                var odt = odc.BeginTransaction();
                int oA = 0;
                using (var cmd = new SqlCommand("update [type] set [sort] = @sort where [id] = @id", odc))
                {
                    cmd.Transaction = odt;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@sort",hb),
                        new SqlParameter("@id",idA)
                    });
                    oA = cmd.ExecuteNonQuery();
                }
                var oB = 0;
                using (var cmdB = new SqlCommand("update [type] set [sort] = @sort where [id] = @id", odc))
                {
                    cmdB.Transaction = odt;
                    cmdB.Parameters.AddRange(new SqlParameter[] { 
                        new SqlParameter("@sort",ha),
                        new SqlParameter("@id",idB)
                    });
                    oB = cmdB.ExecuteNonQuery();
                }
                if (oA == 1 && oB == 1)
                {
                    odt.Commit();
                    return true;
                }
                else
                {
                    odt.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改排序号
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool sort(int sort, int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "update [type] set [sort] = @sort where [id] = @id";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@sort",sort),
                        new SqlParameter("@id",id)
                    });
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
        /// 查询排序号
        /// </summary>
        /// <returns></returns>
        private static int sort()
        {
            int result = 1;
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select max([sort]) from [type]";
                    odc.Open();
                    var sum = cmd.ExecuteScalar();
                    if (!Convert.IsDBNull(sum))
                    {
                        result = Convert.ToInt32(sum) + 1;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获得最大ID号
        /// </summary>
        /// <returns></returns>
        public static int MaxId()
        {
            int result = 0;
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "select max([id]) from [type]";
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
        /// 实体
        /// </summary>
        public struct Value
        {
            /// <summary>
            /// 标识id
            /// </summary>
            public int id
            {
                get;
                set;
            }
            /// <summary>
            /// 类名
            /// </summary>
            public string title
            {
                get;
                set;
            }
            /// <summary>
            /// 图片小标
            /// </summary>
            public string imgSrc
            {
                get;
                set;
            }
            /// <summary>
            /// 图片路径
            /// </summary>
            public string img
            {
                get;
                set;
            }
            /// <summary>
            /// 文字描述
            /// </summary>
            public string content
            {
                get;
                set;
            }
            /// <summary>
            /// 父级ID
            /// </summary>
            public int parentId
            {
                get;
                set;
            }
            /// <summary>
            /// 类别
            /// </summary>
            public string typeId
            {
                get;
                set;
            }
            /// <summary>
            /// 当前层级
            /// </summary>
            public int layer
            {
                get;
                set;
            }
            /// <summary>
            /// 排序
            /// </summary>
            public int sort
            {
                get;
                set;
            }
            /// <summary>
            /// 是否显示
            /// </summary>
            public bool view
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
