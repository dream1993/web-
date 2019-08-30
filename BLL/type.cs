using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 分类
    /// </summary>
    public class type
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string Add(typeData.Value v)
        {
            if (typeData.add(v))
            {
                return "0";
            }
            return "操作失败，请联系管理员";
        }
        /// <summary>
        /// 通过ID删除类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string delete(int id)
        {
            if (articleData.deletetype(id))
            {
                if (typeData.delete(id))
                {
                    return "0";
                }
            }
            return "操作失败，请联系管理员";
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string update(typeData.Value v)
        {
            if (typeData.update(v))
            {
                return "0";
            }
            return "操作失败，请联系管理员";
        }
        /// <summary>
        /// 更新typeId
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string typeId(typeData.Value v)
        {
            if (typeData.typeId(v))
            {
                return "0";
            }
            return "操作失败，请联系管理员";
        }

        /// <summary>
        /// 通过ID查行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static typeData.Value row(int id)
        {
            return typeData.row(id);
        }
        /// <summary>
        /// 得到全部
        /// </summary>
        /// <returns></returns>
        public static DataTable table()
        {
            return typeData.table();
        }

        /// <summary>
        /// 得到全部父级ID
        /// </summary>
        /// <returns></returns>
        public static DataTable table(int pid)
        {
            return typeData.table(pid);
        }
        /// <summary>
        /// 生成类型列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static List<typeData.Value> typelist(int pid)
        {
            var v = new typeData.Value();
            var list = new List<typeData.Value>();
            foreach (DataRow dr in typeData.table(pid).Rows)
            {
                v.layer = Convert.ToInt32(dr["layer"]);
                if (v.parentId == pid)
                {
                    v.title = dr["title"].ToString();
                }
                else
                {
                    v.title = "├ " + dr["title"].ToString();
                    v.title = StringOfChar(v.layer - 1, "&nbsp;&nbsp;&nbsp;") + v.title;
                }
                v.id = Convert.ToInt32(dr["id"]);
                v.view = Convert.ToBoolean(dr["view"].ToString());
                if (v.view)
                {
                    list.Add(v);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据层级加空格
        /// </summary>
        /// <param name="strLong"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }

            return ReturnStr;
        }
        /// <summary>
        /// 根据父ID查询显示的列表 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<typeData.Value> list(int id)
        {
            return typeData.list(id);
        }
        /// <summary>
        /// 根据父ID查询显示的列表 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<typeData.Value> list(int id, int top)
        {
            return typeData.list(id,top);
        }
        /// <summary>
        /// 显示/隐藏
        /// </summary>
        /// <param name="view"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string view(bool view, int id)
        {
            if (typeData.view(view, id))
            {
                return "0";
            }
            return "操作失败，请联系管理员";
        }

        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <returns></returns>
        public static int MaxId()
        {
            return typeData.MaxId();
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
            if (typeData.sort(Convert.ToInt32(idA), Convert.ToInt32(idB), Convert.ToInt32(ha), Convert.ToInt32(hb)))
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
            if (typeData.sort(sort, id))
            {
                return "0";
            }
            return "错误";
        }
    }
}
