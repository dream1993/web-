using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// type 的摘要说明
    /// </summary>
    public class type : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int pid = int.Parse(context.Request["pid"]);
            List<DAL.typeData.Value> list = DAL.typeData.list(pid);
            context.Response.Write(CL.JsonHelper.GetJson(list));
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