using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.ajax
{
    public class gethtml
    {
        public  static string gethtmls(HttpContext context, string name)
        {
            using (StreamReader reader = new StreamReader(context.Server.MapPath(@"/common/" + name + ".html"), Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
    }
}