using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace Web.ajax
{
    /// <summary>
    /// message 的摘要说明
    /// </summary>
    public class message : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request["name"];
            string phone = context.Request["phone"];
            string qq = context.Request["qq"];
            string email = context.Request["email"];
            string contents = context.Request["contents"];
            StringBuilder sb = new StringBuilder();
            sb.Append("姓名："+name+"<br/>");
            sb.Append("手机：" + phone + "<br/>");
            sb.Append("QQ：" + qq + "<br/>");
            sb.Append("邮箱：" + email + "<br/>");
            sb.Append("合作需求：" +contents + "<br/>");
            CL.Common.SendActiveEmail("1140583349@qq.com", "", sb.ToString(), name + "的合作需求", "18911993521@163.com", "longyu1314gudu");
            DAL.messageData.Value mv = new DAL.messageData.Value();
            mv.userid = name;
            mv.createTime = DateTime.Now;
            mv.contents = sb.ToString();
            if (DAL.messageData.Add(mv))
            {
                context.Response.Write("0");
            }
            else
            {
                context.Response.Write("1");
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