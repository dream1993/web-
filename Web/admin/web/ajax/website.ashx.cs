using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.web.ajax
{
    /// <summary>
    /// website 的摘要说明
    /// </summary>
    public class website : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var dqUser = context.User.Identity.Name.ToString();
            var title = context.Request["title"];
            var description = context.Request["description"];
            var keywords = context.Request["keywords"];
            var copyright = context.Request["copyright"];
            var mail = context.Request["mail"];
            var tel = context.Request["tel"];
            var address = context.Request["address"];
            var code = context.Request["code"];
            var fax = context.Request["fax"];
            var QQ1 = context.Request["QQ1"];
            var QQ2 = context.Request["QQ2"];
            var tel1 = context.Request["tel1"];
            var weburl = context.Request["weburl"];
            var v = new DAL.  webSiteData.Value();
            v.title = title;
            v.description = description;
            v.keywords = keywords;
            v.copyright = copyright;
            v.mail = mail;
            v.tel = tel;
            v.address = address;
            v.code = code;
            v.fax = fax;
            v.QQ1 = QQ1;
            v.QQ2 = QQ2;
            v.tel1 = tel1;
            v.weburl = weburl;
            context.Response.Write(BLL.webSite.update(v, dqUser));
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