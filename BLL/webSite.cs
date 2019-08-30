using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Web;


namespace BLL
{
    /// <summary>
    /// 基本信息
    /// </summary>
    public class webSite
    {
        /// <summary>
        /// 查询基本信息
        /// </summary>
        /// <returns></returns>
        public static webSiteData.Value table()
        {
            return webSiteData.table();
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="v">实体</param>
        /// <param name="userName">管理员帐号</param>
        /// <returns></returns>
        public static string update(webSiteData.Value v, string userName)
        {
            
                if (webSiteData.update(v))
                {
                    return "0";
                }
            
            return "修改信息失败，权限不足！";
        }
        /// <summary>
        /// 修改分页样式
        /// </summary>
        /// <param name="fy"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string page(string fy, string userName)
        {
          
                if (webSiteData.page(fy))
                {
                    return "0";
                }
           
            return "修改信息失败，权限不足！";
        }
    }
}
