using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.web.ajax
{
    /// <summary>
    /// artzd 的摘要说明
    /// </summary>
    public class artzd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request["url"];
            try
            {
                int id = int.Parse(context.Request["id"]);
                string fine = context.Request["fine"];
                string sort = context.Request["sort"];
              
                if (string.IsNullOrEmpty(fine))
                {
                    context.Response.Write(BLL.article.sort(int.Parse(sort),id));
                }
                else
                {
                    BLL.article.fine(Convert.ToBoolean(fine)?false:true, id);
                    context.Response.Redirect(url);
                }
            }
            catch (Exception)
            {
                context.Response.Redirect(url);
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