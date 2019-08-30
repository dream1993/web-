using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// casedj 的摘要说明
    /// </summary>
    public class casedj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request["act"];
            string id = context.Request["id"];
            switch (act)
            {
                case "hq":
                    context.Response.Write(DAL.articleData.row(int.Parse(id)).hits);
                    break;
                case "up":
                    context.Response.Write(DAL.articleData.hits(int.Parse(id)));
                    break;
                default:
                    break;
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