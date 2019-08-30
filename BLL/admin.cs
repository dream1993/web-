using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Web;
using System.Web.Security;

namespace BLL
{
    public class admin
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
                var user = admin.row(userName);
                if (user.hasRow)
                {
                    DAL.loginlog.Value log = new DAL.loginlog.Value();
                    log.IfSuccess = 0;
                    log.LoginDesc = "密码错误";
                    string pass = CL.Common.MD5(passWord);
                    var loginIp = HttpContext.Current.Request.UserHostAddress; //获取当前客户端IP地址
                    log.LoginTime = DateTime.Now;
                    log.LoginUserIp = loginIp;
                    log.UserId = user.userid;
                    if (user.password.Equals(pass))
                    {
                        adminData.loginip(userName, loginIp); //更新登录时间、登录IP
                        HttpContext.Current.Session["hy_user"] = user.userid;
                        log.IfSuccess = 1;
                        log.LoginDesc = "登陆成功";


                        var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                        var Expires = DateTime.Now.AddHours(8); //7天内无需登录
                        httpCookie.Expires = DateTime.MinValue;
                        httpCookie.Value = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(0, userName, DateTime.Now, Expires, false, userName));
                        HttpContext.Current.Response.Cookies.Add(httpCookie);
                        
                        DAL.loginlog.AddLoginLog(log);
                        return "0";
                    }
                    DAL.loginlog.AddLoginLog(log);
                    return "P";
                }
                return "Z";
            }
            return "";
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool delete(int id)
        {
            return adminData.delete(id);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool add(adminData.Value v)
        {
            return adminData.Add(v);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public static bool updatepwd(string userid, string pwd)
        {
            return adminData.updatepwd(userid, pwd);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public static List<adminData.Value> table()
        {
            return adminData.table();
        }
        /// <summary>
        /// 通过账号查行
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public static adminData.Value row(string id)
        {
            return adminData.row(id);
        }

    }
}
