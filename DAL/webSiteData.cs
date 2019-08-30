using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 基本信息
    /// </summary>
    public class webSiteData : publicData
    {
        /// <summary>
        /// 查询基本信息
        /// </summary>
        /// <returns></returns>
        public static Value table()
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "select top 1 [title],[description],[keywords],[copyright],[pager],[mail],[tel],[address],[code],[fax],[QQ1],[QQ2],[tel1],[weburl] from [website]";
                    cmd.Connection = odc;
                    odc.Open();
                    var v = new Value();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        v.title = dr["title"].ToString();
                        v.description = dr["description"].ToString();
                        v.keywords = dr["keywords"].ToString();
                        v.copyright = dr["copyright"].ToString();
                        v.pager = dr["pager"].ToString();
                        v.mail = dr["mail"].ToString();
                        v.tel = dr["tel"].ToString();
                        v.address = dr["address"].ToString();
                        v.code = dr["code"].ToString();
                        v.fax = dr["fax"].ToString();
                        v.QQ1 = dr["QQ1"].ToString();
                        v.QQ2 = dr["QQ2"].ToString();
                        v.tel1 = dr["tel1"].ToString();
                        v.weburl = dr["weburl"].ToString();
                    }
                    return v;
                }
            }
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool update(Value v)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "update [website] set [title]=@title,[description]=@description,[keywords]=@keywords,[copyright]=@copyright,[mail]=@mail,[tel]=@tel,[address]=@address,[code]=@code,[fax]=@fax,[QQ1]=@QQ1,[QQ2]=@QQ2,[tel1]=@tel1,[weburl]=@weburl";
                    cmd.Connection = odc;
                    cmd.Parameters.AddRange(new SqlParameter[]{
                        new SqlParameter("@title",v.title),
                        new SqlParameter("@description",v.description),
                        new SqlParameter("@keywords",v.keywords),
                        new SqlParameter("@copyright",v.copyright),
                        new SqlParameter("@mail",v.mail),
                        new SqlParameter("@tel",v.tel),
                        new SqlParameter("@address",v.address),
                        new SqlParameter("@code",v.code),
                         new SqlParameter("@fax",v.fax),
                        new SqlParameter("@QQ1",v.QQ1),
                        new SqlParameter("@QQ2",v.QQ2),
                        new SqlParameter("@tel1",v.tel1),
                        new SqlParameter("@weburl",v.weburl)
                    });
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
        /// 修改分页
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool page(string fy)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "update [website] set [pager]=@pager";
                    cmd.Connection = odc;
                    cmd.Parameters.Add(new SqlParameter("@pager", fy));
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
        /// 实体
        /// </summary>
        public struct Value
        {
            /// <summary>
            /// 网站标题
            /// </summary>
            public string title
            {
                get;
                set;
            }
            /// <summary>
            /// 网站描述
            /// </summary>
            public string description
            {
                get;
                set;
            }
            /// <summary>
            /// 网站关键字
            /// </summary>
            public string keywords
            {
                get;
                set;
            }
            /// <summary>
            /// 版权信息
            /// </summary>
            public string copyright
            {
                get;
                set;
            }
            /// <summary>
            /// 分页样式
            /// </summary>
            public string pager
            {
                get;
                set;
            }
            /// <summary>
            /// 邮箱地址
            /// </summary>
            public string mail
            {
                get;
                set;
            }
            /// <summary>
            /// 联系电话
            /// </summary>
            public string tel
            {
                get;
                set;
            }
            /// <summary>
            /// 联系电话
            /// </summary>
            public string tel1 { get; set; }

            /// <summary>
            /// 联系地址
            /// </summary>
            public string address
            {
                get;
                set;
            }
            /// <summary>
            /// 统计代码
            /// </summary>
            public string code
            {
                get;
                set;
            }
            /// <summary>
            /// 在线QQ1
            /// </summary>
            public string QQ1 { get; set; }

            /// <summary>
            /// 在线QQ2
            /// </summary>
            public string QQ2 { get; set; }

            /// <summary>
            /// 传真
            /// </summary>
            public string fax { get; set; }
            /// <summary>
            /// 网址
            /// </summary>
            public string weburl { get; set; }
        }
    }
}
