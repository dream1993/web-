using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.manager
{
    /// <summary>
    /// manager 的摘要说明
    /// </summary>
    public class manager : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string act = context.Request["act"];
                DAL.adminData.Value av = new DAL.adminData.Value();
                av.createTime = DateTime.Now;
                av.id = context.Request["id"] == null ? 0 : int.Parse(context.Request["id"]);
                av.loginIp = "";
                av.loginTime = DateTime.Now;
                av.role = context.Request["level"] == null ? 0 : int.Parse(context.Request["level"]);
                switch (act)
                {
                    case "add"://添加
                        av.password = context.Request["password"];
                        if (string.IsNullOrEmpty(av.password))
                        {
                            context.Response.Redirect("add.aspx?message=密码不能为空！", false);
                            return;
                        }
                        av.password = CL.Common.MD5(av.password);
                        av.userid = context.Request["user"];
                        if (string.IsNullOrEmpty(av.userid))
                        {
                            context.Response.Redirect("add.aspx?message=用户名不能为空！", false);
                            return;
                        }
                        if (DAL.adminData.row(av.userid).hasRow)
                        {
                            context.Response.Redirect("add.aspx?message=用户名已存在！", false);
                            return;
                        }
                        if (DAL.adminData.Add(av))
                        {
                            context.Response.Redirect("add.aspx?message=添加成功！", false);
                        }
                        else
                        {
                            context.Response.Redirect("add.aspx?message=添加失败！&fid=", false);
                        }
                        break;
                    case "update"://修改

                        if (DAL.adminData.updatepwd(av.id, av.role))
                        {
                            context.Response.Redirect("update.aspx?message=修改成功！&id=" + av.id, false);
                        }
                        else
                        {
                            context.Response.Redirect("update.aspx?message=修改失败！&id=" + av.id, false);
                        }
                        break;
                    case "czpwd"://修改自己密码
                        av.password = context.Request["password"];
                        if (string.IsNullOrEmpty(av.password))
                        {
                            context.Response.Redirect("uppwd.aspx?message=密码不能为空！", false);
                            return;
                        }
                        av.password = CL.Common.MD5(av.password);
                        if (DAL.adminData.updatepwd(CL.Common.login(context),av.password))
                        {
                            context.Response.Redirect("uppwd.aspx?message=修改成功！" , false);
                        }
                        else
                        {
                            context.Response.Redirect("uppwd.aspx?message=修改失败！", false);
                        }
                        break;
                    case "cz"://重置密码
                        av.password = CL.Common.MD5("123456");
                        if (DAL.adminData.updatepwd(av.id, av.password))
                        {
                            context.Response.Redirect("default.aspx?message=密码重置成功，重置后的密码为123456！", false);
                        }
                        else
                        {
                            context.Response.Redirect("default.aspx?message=重置失败！", false);
                        }
                        break;
                    case "del"://修改

                        if (DAL.adminData.delete(av.id))
                        {
                            context.Response.Redirect("default.aspx?message=修改成功！", false);
                        }
                        else
                        {
                            context.Response.Redirect("default.aspx?message=修改失败！", false);
                        }
                        break;
                    case "isex":
                          av.userid = context.Request["user"];
                          if (DAL.adminData.row(av.userid).hasRow)
                          {
                              context.Response.Write("1");
                              return;
                          }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                context.Response.Redirect("default.aspx?message=网络错误，请稍后再试！");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}