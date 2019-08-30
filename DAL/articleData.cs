using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 文章
    /// </summary>
    public class articleData : publicData
    {
        public static string select = "select [id],[title],[keyword],[description],[realTitle],[imgSrc],[fileSrc],[createTime],[updateTime],[editor],[source],[sort],[hits],[content],[typeId],[fine],[view],[role],[url],[a1],[a2],[a3],[a4],[a5],[a6],[a7],[a8],[a9],[a10] from [article]";
        /// <summary>
        /// 添加文章
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
                    cmd.CommandText = "insert into [article] ([title],[keyword],[description],[realTitle],[imgSrc],[fileSrc],[createTime],[updateTime],[editor],[source],[sort],[hits],[content],[typeId],[fine],[view],[role],[url],[a1],[a2],[a3],[a4],[a5],[a6],[a7],[a8],[a9],[a10]) values (@title,@keyword,@description,@realTitle,@imgSrc,@fileSrc,@createTime,@updateTime,@editor,@source,@sort,@hits,@content,@typeId,@fine,@view,@role,@url,@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10)";
                    SqlParameter[] odp = new SqlParameter[]{
                        new SqlParameter("@title",v.title),
                        new SqlParameter("@keyword",v.keyword),
                        new SqlParameter("@description",v.description),
                        new SqlParameter("@realTitle",v.realTitle),
                        new SqlParameter("@imgSrc",v.imgSrc),
                        new SqlParameter("@fileSrc",v.fileSrc),
                        new SqlParameter("@createTime",DateTime.Now),
                        new SqlParameter("@updateTime",v.updateTime),
                        new SqlParameter("@editor",v.editor),
                        new SqlParameter("@source",v.source), 
                        new SqlParameter("@sort",sort()),
                        new SqlParameter("@hits",v.hits),
                        new SqlParameter("@content",v.content),
                        new SqlParameter("@typeId",v.typeId),
                        new SqlParameter("@fine",v.fine),
                        new SqlParameter("@view",v.view),
                        new SqlParameter("@role",v.role),
                        new SqlParameter("@url",v.url),
                        new SqlParameter("@a1",v.a1),
                        new SqlParameter("@a2",v.a2),
                        new SqlParameter("@a3",v.a3),
                        new SqlParameter("@a4",v.a4),
                        new SqlParameter("@a5",v.a5),
                        new SqlParameter("@a6",v.a6),
                        new SqlParameter("@a7",v.a7),
                        new SqlParameter("@a8",v.a8),
                        new SqlParameter("@a9",v.a9),
                        new SqlParameter("@a10",v.a10)
                    };
                    cmd.Parameters.AddRange(odp);
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
        /// 通过ID删除
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
                    cmd.CommandText = "delete from [article] where [id] = @id";
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
        /// 类别删除，对应文章删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool deletetype(int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "delete from [article] where [typeId] in (select id from [type] where [typeId] like '%," + id + ",%')";
                    odc.Open();
                    var result = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        /// <summary>
        /// 修改文章
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
                    cmd.CommandText = "update [article] set [view]=@view,[title]=@title,[keyword]=@keyword,[description]=@description,[realTitle]=@realTitle,[imgSrc]=@imgSrc,[fileSrc]=@fileSrc,[updateTime]=@updateTime,[editor]=@editor,[source]=@source,[hits]=@hits,[content]=@content,[typeId]=@typeId,[url]=@url,[a1]=@a1,[a2]=@a2,[a3]=@a3,[a4]=@a4,[a5]=@a5,[a6]=@a6,[a7]=@a7,[a8]=@a8,[a9]=@a9,[a10]=@a10 where [id] = @id";
                    SqlParameter[] odp = new SqlParameter[]{
                        new SqlParameter("@title",v.title),
                        new SqlParameter("@keyword",v.keyword),
                        new SqlParameter("@description",v.description),
                        new SqlParameter("@realTitle",v.realTitle),
                        new SqlParameter("@imgSrc",v.imgSrc),
                        new SqlParameter("@fileSrc",v.fileSrc),
                        new SqlParameter("@updateTime",v.updateTime),
                        new SqlParameter("@editor",v.editor),
                        new SqlParameter("@source",v.source), 
                        new SqlParameter("@hits",v.hits),
                        new SqlParameter("@content",v.content),
                        new SqlParameter("@typeId",v.typeId),
                        
                        new SqlParameter("@view",v.view),
                        new SqlParameter("@url",v.url),
                        new SqlParameter("@a1",v.a1),
                        new SqlParameter("@a2",v.a2),
                        new SqlParameter("@a3",v.a3),
                        new SqlParameter("@a4",v.a4),
                        new SqlParameter("@a5",v.a5),
                        new SqlParameter("@a6",v.a6),
                        new SqlParameter("@a7",v.a7),
                        new SqlParameter("@a8",v.a8),
                        new SqlParameter("@a9",v.a9),
                        new SqlParameter("@a10",v.a10),
                        new SqlParameter("@id",v.id)
                    };
                    cmd.Parameters.AddRange(odp);
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
        /// 隐藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool view(bool view, int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [article] set [view] = @view where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@view",view),
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
        /// 置顶
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool fine(bool fine, int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = "update [article] set [fine] = @fine where [id] = @id";
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@fine",fine),
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
        /// 通过id查行
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
                    cmd.CommandText = select + " where [id] = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    odc.Open();
                    var v = new Value();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
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
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> Recycle(string so)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = select + " where [view] = 'false' and [title] like '%" + so + "%' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> likeTitle(int typeId, string so)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = select + " where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and [title] like '%" + so + "%' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }

        /// <summary>
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> fengge(int typeId, string sp)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = select + " where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and [editor] like '%" + sp + "%' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 搜全站
        /// </summary>
        /// <param name="so"></param>
        /// <returns></returns>
        public static List<Value> search(string so)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = select + " where [view] = 'true' and [title] like '%" + so + "%' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 搜全站
        /// </summary>
        /// <param name="so"></param>
        /// <returns></returns>
        public static List<Value> search(string so, int top)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select * from article where [view] = 'true' and [title] like '%" + so + "%' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="date">每页显示的几条数据</param>
        /// <param name="page">当前页</param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> page(int date, int page, int typeId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = " select top " + date + " * from [article]  where id not in ( select top " + date * (page - 1) + " id from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc ) and [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        public static List<Value> page_a3(int date, int page, int a3)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = " select top " + date + " * from [article]  where id not in ( select top " + date * (page - 1) + " id from [article]  where [view] = 'true' and a3='"+a3+"' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc ) and [view] = 'true' and a3='"+a3+"' order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                   
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="date">每页显示的几条数据</param>
        /// <param name="page">当前页</param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> page(int date, int page, int typeId, string title)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = " select top " + date + " * from [article]  where id not in ( select top " + date * (page - 1) + " id from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc ) and [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@title", "%" + title + "%"));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        public static List<Value> page(int date, int page, int typeId, string title,string a3)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = " select top " + date + " * from [article]  where id not in ( select top " + date * (page - 1) + " id from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and a3 like @a3 and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc ) and [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and a3 like @a3 and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                       new SqlParameter("@title", "%" + title + "%"),
                        new SqlParameter("@a3", "%" + a3 + "%")
                    });
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        public static List<Value> pagesearch(int date, int page, string so, int typeid)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = " select top " + date + " * from [article]  where id not in ( select top " + date * (page - 1) + " id from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where typeId like '%," + typeid + ",%') and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc ) and [view] = 'true' and [typeId] in (select [id] from [type] where typeId like '%," + typeid + ",%') and title like @title order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@title", "%" + so + "%"));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> table(string where)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    var sql = where;
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> table(int typeId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = select + " where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过分类列表查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static int count(int typeId, string title)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select count(id) from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and title like @title ";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@title", "%" + title + "%"));
                    odc.Open();

                    var dr = cmd.ExecuteScalar();

                    return (int)dr;
                }
            }
        }
        public static int count(int typeId, string title,string a3)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select count(id) from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and a3 like @a3 and title like @title ";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                       new SqlParameter("@title", "%" + title + "%"),
                        new SqlParameter("@a3", "%" + a3 + "%")
                    });
                    odc.Open();

                    var dr = cmd.ExecuteScalar();

                    return (int)dr;
                }
            }
        }
        public static int count(int typeId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select count(id) from [article]  where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%')  ";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();

                    var dr = cmd.ExecuteScalar();

                    return (int)dr;
                }
            }
        }
        public static int count_a3(int a3)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select count(id) from [article]  where [view] = 'true' and a3='"+a3+"'  ";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();

                    var dr = cmd.ExecuteScalar();

                    return (int)dr;
                }
            }
        }
        /// <summary>
        /// 查询第一个
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static Value tableRow(int typeId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select top 1 * from [article] where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
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
        /// 通过分类ID查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> table(int typeId, int top)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select top " + top + " * from [article] where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 前几个除去自身id
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<Value> table_ru(int typeId, int top,int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select top " + top + " * from [article] where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and id<>"+id+" order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        public static List<Value> table_rua3(int a3, int top, int id,int typeid)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select top " + top + " * from [article] where [view] = 'true' and typeId<> " + typeid + " and a3=@a3 and id<>" + id + " order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@a3", a3));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        /// <summary>
        /// 通过分类ID查找
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<Value> table(int typeId, int top, int chule)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "select top " + top + " * from [article] where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') and [id] not in (select top " + chule + " [id] from [article] where [view] = 'true' and [typeId] in (select [id] from [type] where [typeId] like '%," + typeId + ",%') order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc) order by [fine] desc,[sort] desc,[updateTime] desc, [id] desc";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@typeId", typeId));
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.id = Convert.ToInt32(dr["id"]);
                        v.title = dr["title"].ToString();
                        v.keyword = dr["keyword"].ToString();
                        v.description = dr["description"].ToString();
                        v.realTitle = dr["realTitle"].ToString();
                        v.imgSrc = dr["imgSrc"].ToString();
                        v.fileSrc = dr["fileSrc"].ToString();
                        v.createTime = Convert.ToDateTime(dr["createTime"].ToString());
                        v.updateTime = Convert.ToDateTime(dr["updateTime"].ToString());
                        v.editor = dr["editor"].ToString();
                        v.source = dr["source"].ToString();
                        v.sort = Convert.ToInt32(dr["sort"]);
                        v.hits = Convert.ToInt32(dr["hits"].ToString());
                        v.content = dr["content"].ToString();
                        v.typeId = Convert.ToInt32(dr["typeId"]);
                        v.fine = Convert.ToBoolean(dr["fine"]);
                        v.view = Convert.ToBoolean(dr["view"]);
                        v.role = Convert.ToInt32(dr["role"]);
                        v.url = dr["url"].ToString();
                        v.a1 = dr["a1"].ToString();
                        v.a2 = dr["a2"].ToString();
                        v.a3 = dr["a3"].ToString();
                        v.a4 = dr["a4"].ToString();
                        v.a5 = dr["a5"].ToString();
                        v.a6 = dr["a6"].ToString();
                        v.a7 = dr["a7"].ToString();
                        v.a8 = dr["a8"].ToString();
                        v.a9 = dr["a9"].ToString();
                        v.a10 = dr["a10"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
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
                using (var cmd = new SqlCommand("update [article] set [sort] = @sort where [id] = @id", odc))
                {
                    cmd.Transaction = odt;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@sort",hb),
                        new SqlParameter("@id",idA)
                    });
                    oA = cmd.ExecuteNonQuery();
                }
                var oB = 0;
                using (var cmdB = new SqlCommand("update [article] set [sort] = @sort where [id] = @id", odc))
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
                    string sql = "update [article] set [sort] = @sort where [id] = @id";
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
                    cmd.CommandText = "select max([sort]) from [article] where [view] = 'true'";
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
        /// 修改点击率
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool hits(int id)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    string sql = "update [article] set [hits] = [hits] + 1 where [id] = @id";
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
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
        /// 下一页 sp
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static Value q(int sort, int typeId)
        {
            string sql = select + " where [view] = 'true' and [typeId] = " + typeId + "  and [sort] < " + sort + " order by [sort] desc,[updateTime] desc, [id] desc";
            var v = new Value();
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        v.id = int.Parse(rd["id"].ToString());
                        v.title = rd["title"].ToString();
                        v.hasRow = true;
                    }
                    else
                    {
                        v.hasRow = false;
                    }
                }
            }
            return v;
        }
        /// <summary>
        /// 下一页 sp
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static Value x(int sort, int typeId)
        {
            string sql = select + " where [view] = 'true' and [typeId] = " + typeId + "  and [sort] > " + sort + " order by [sort] asc,[updateTime] desc, [id] desc";
            var v = new Value();
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    odc.Open();
                    var rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        v.id = int.Parse(rd["id"].ToString());
                        v.title = rd["title"].ToString();
                        v.hasRow = true;
                    }
                    else
                    {
                        v.hasRow = false;
                    }
                }
            }
            return v;
        }
        /// <summary>
        /// 实体
        /// </summary>
        public struct Value
        {
            /// <summary>
            /// 标识
            /// </summary>
            public int id
            {
                get;
                set;
            }
            /// <summary>
            /// 标题
            /// </summary>
            public string title
            {
                get;
                set;
            }
            /// <summary>
            /// 关键字
            /// </summary>
            public string keyword
            {
                get;
                set;
            }
            /// <summary>
            /// 描述
            /// </summary>
            public string description
            {
                get;
                set;
            }
            /// <summary>
            /// 详细标题
            /// </summary>
            public string realTitle
            {
                get;
                set;
            }
            /// <summary>
            /// 图片
            /// </summary>
            public string imgSrc
            {
                get;
                set;
            }
            /// <summary>
            /// 文件
            /// </summary>
            public string fileSrc
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
            /// 更新时间
            /// </summary>
            public DateTime updateTime
            {
                get;
                set;
            }
            /// <summary>
            /// 作者
            /// </summary>
            public string editor
            {
                get;
                set;
            }
            /// <summary>
            /// 来源
            /// </summary>
            public string source
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
            /// 点击率
            /// </summary>
            public int hits
            {
                get;
                set;
            }
            /// <summary>
            /// 内容
            /// </summary>
            public string content
            {
                get;
                set;
            }
            /// <summary>
            /// 分类
            /// </summary>
            public int typeId
            {
                get;
                set;
            }
            /// <summary>
            /// 置顶
            /// </summary>
            public bool fine
            {
                get;
                set;
            }
            /// <summary>
            /// 显示
            /// </summary>
            public bool view
            {
                get;
                set;
            }
            /// <summary>
            /// 权限
            /// </summary>
            public int role
            {
                get;
                set;
            }
            /// <summary>
            /// 路径
            /// </summary>
            public string url
            {
                get;
                set;
            }
            public string a1
            {
                get;
                set;
            }

            public string a2
            {
                get;
                set;
            }

            public string a3
            {
                get;
                set;
            }

            public string a4
            {
                get;
                set;
            }

            public string a5
            {
                get;
                set;
            }

            public string a6
            {
                get;
                set;
            }

            public string a7
            {
                get;
                set;
            }

            public string a8
            {
                get;
                set;
            }

            public string a9
            {
                get;
                set;
            }

            public string a10
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
            public int count { get; set; }
            public long Sort { get; set; }
        }
    }
}
