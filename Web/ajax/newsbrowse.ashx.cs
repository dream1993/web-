using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// newsbrowse 的摘要说明
    /// </summary>
    public class newsbrowse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request["id"]);
                DAL.articleData.hits(id);
                context.Response.Write(DAL.articleData.row(id).hits+1);
            }
            catch (Exception)
            {
                context.Response.Write(100);
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