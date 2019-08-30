using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.message
{
    /// <summary>
    /// message 的摘要说明
    /// </summary>
    public class message : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var del = context.Request["del"];
            if (!string.IsNullOrEmpty(del))
            {
                if (DAL.userRoleData.Del(int.Parse(del)) > 0)
                {
                    context.Response.Redirect("default.aspx?message=删除成功");
                }
                else
                {
                    context.Response.Redirect("default.aspx?message=删除失败");
                }
                return;
            }
            var title = context.Request.Form["title"];
            var contents = context.Request.Form["contents"];
            var id = context.Request["id"];
            DAL.sysMessageData.Value mf = new DAL.sysMessageData.Value();
            mf.title = title;
            mf.contents = contents;
            if (string.IsNullOrEmpty(id))
            {

                if (DAL.sysMessageData.Add(mf))
                {
                    context.Response.Redirect("add.aspx?message=添加成功");
                }
                else
                {
                    context.Response.Redirect("add.aspx?message=添加失败");
                }
            }
            else
            {
                mf.id = int.Parse(id);
          
                if (DAL.sysMessageData.update(mf) )
                {
                    context.Response.Redirect("update.aspx?message=修改成功&id=" + id);
                }
                else
                {
                    context.Response.Redirect("update.aspx?message=修改失败&id=" + id);
                }
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