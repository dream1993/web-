using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Web;
using System.Web.Security;
namespace BLL
{
   public class user
    {
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="passWord">密码</param>
        /// <param name="cookie">是否记录</param>
        /// <returns></returns>
        public static string login(string userName, string passWord)
        {

            if (CL.Common.validation(userName, passWord))
            {
                var user = userData.row(userName);
                if (user.hasRow)
                {
                    string pass = CL.Common.MD5(passWord);
                   
                    if (user.passWord.Equals(pass))
                    {
                       // adminData.loginip(userName, loginIp); //更新登录时间、登录IP
                        HttpContext.Current.Session["user"] = user.userId;
                        return "0";
                    }
                  
                    return "P";
                }
                return "Z";
            }
            return "";
        }
    }
}
