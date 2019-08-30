using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.IO;
using System.Web;

namespace BLL
{
    /// <summary>
    /// 文章
    /// </summary>
    public class article
    {
     
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="date">每页显示几条数据</param>
        /// <param name="page">当前页</param>
        /// <param name="typeId">类别</param>
        /// <returns></returns>
        public static List<articleData.Value> page(int date, int page, int typeId)
        {
            return articleData.page(date, page, typeId);
        }
        public static List<articleData.Value> page(int date, int page, int typeId,string search)
        {
            if (string.IsNullOrEmpty(search))
            { 
            return articleData.page(date, page, typeId);
            }
            return articleData.pagesearch(date, page, search, typeId);
        }
        /// <summary>
        /// 通过ID删除类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string delete(int id)
        {
            if (row(id).hasRow)
            {
                var fileSrc = HttpContext.Current.Server.MapPath(row(id).fileSrc);
                if (File.Exists(fileSrc))
                {
                    File.Delete(fileSrc);
                }
                if (articleData.delete(id))
                {
                    return "0";
                }
            }
            return "删除失败";
        }

        /// <summary>
        /// 类别删除，对应文章删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string deletetype(int id)
        {
            if (articleData.deletetype(id))
            {
                return "0";
            }
            return "删除失败";
        }

        public static string update(articleData.Value v)
        {
            if (articleData.update(v))
            {
                return "0";
            }
            return "";
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="fine"></param>
        /// <returns></returns>
        public static string fine(bool fine, int id)
        {
            if (articleData.fine(fine, id))
            {
                return "0";
            }
            return "删除失败，权限不足！";
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <param name="view"></param>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string view(bool view, int id, string user)
        {
            //int dqRole = admin.getRole(user);
            //int role = row(id).role;
            //if (dqRole >= role)
            //{
            //    articleData.view(view, id);
            //   // adminData.deleteArticle(user);
            //    return "0";
            //}
            return "操作失败，权限不足！";
        }

        /// <summary>
        /// id查行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static articleData.Value row(int id)
        {
            return articleData.row(id);
        }

        /// <summary>
        /// 查标题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string articleTitle(int id)
        {
            return row(id).title;
        }

        /// <summary>
        /// 查内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string articleContent(int id)
        {
            return row(id).content;
        }
        /// <summary>
        /// 通过父级ID查询信息（父类及子类）
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<articleData.Value> likeTitle(int typeId, string so)
        {
            return articleData.likeTitle(typeId, so);
        }
        /// <summary>
        /// 搜全站
        /// </summary>
        /// <param name="so"></param>
        /// <returns></returns>
        public static List<articleData.Value> search(string so)
        {
            return articleData.search(so);
        }
        /// <summary>
        /// 通过父级ID查询信息（父类及子类）
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<articleData.Value> Recycle(string so)
        {
            return articleData.Recycle(so);
        }
        
        /// <summary>
        /// 通过父级ID查询信息（父类及子类）
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<articleData.Value> table(int typeId)
        {
            return articleData.table(typeId);
        }
        public static List<articleData.Value> table(int typeId,string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return articleData.table(typeId);
            }
            return articleData.search(search);
        }
        /// <summary>
        /// 通过父级ID查询信息（父类及子类）
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static List<articleData.Value> table(string where)
        {
            return articleData.table(where);
        }
        /// <summary>
        /// 前几个
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<articleData.Value> table(int typeId, int top)
        {
            return articleData.table(typeId, top);
        }
        public static List<articleData.Value> table(int typeId, int top,string so)
        {
            if (string.IsNullOrEmpty(so))
            {
                return articleData.table(typeId, top);
            }
            return articleData.search(so, top);
        }
        //public static List<articleData.Value> table(int typeId, int top,string search)
        //{
        //    return articleData.table(typeId, top);
        //}
        /// <summary>
        /// 前几个除了几个
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static List<articleData.Value> table(int typeId, int top, int chule)
        {
            return articleData.table(typeId, top, chule);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="idA"></param>
        /// <param name="idB"></param>
        /// <param name="ha"></param>
        /// <param name="hb"></param>
        /// <returns></returns>
        public static string sort(string idA, string idB, string ha, string hb)
        {
            if (articleData.sort(Convert.ToInt32(idA), Convert.ToInt32(idB), Convert.ToInt32(ha), Convert.ToInt32(hb)))
            {
                return "0";
            }
            return "换位失败！";
        }

        /// <summary>
        /// 修改排序号
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string sort(int sort, int id)
        {
            if (articleData.sort(sort, id))
            {
                return "0";
            }
            return "错误";
        }
    }
}
