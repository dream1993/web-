using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.domainName
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Request["userName"];
            var passWord = Request["passWord"];
            // var cookie = "on";
            if (string.IsNullOrEmpty(userName))
            {
                if (Request.IsAuthenticated)
                {
                    if (DAL.adminData.row(Session["domain"].ToString()).hasRow)
                    {
                        Response.Redirect("main.aspx", true);
                    }
                }
            }
            else
            {
                var result = "";
                result = login(userName, passWord);
                Response.Write(result);
            }
        }
        public static string login(string userName, string passWord)
        {
            if (CL.Common.validation(userName, passWord))
            {
                var user = BLL.admin.row(userName);
                if (user.hasRow)
                {
                    DAL.loginlog.Value log = new DAL.loginlog.Value();
                    log.IfSuccess = 0;
                    log.LoginDesc = "密码错误--域名管理";
                    string pass = CL.Common.MD5(passWord);
                    var loginIp = HttpContext.Current.Request.UserHostAddress; //获取当前客户端IP地址
                    log.LoginTime = DateTime.Now;
                    log.LoginUserIp = loginIp;
                    log.UserId = user.userid;
                    if (user.password.Equals(pass))
                    {
                        DAL.adminData.loginip(userName, loginIp); //更新登录时间、登录IP
                        HttpContext.Current.Session["domain"] = user.id;
                        log.IfSuccess = 1;
                        log.LoginDesc = "登陆成功--域名管理";

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
    }
}