using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.allAgent
{
    public partial class update : System.Web.UI.Page
    {
        public DAL.articleData.Value av;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                av = DAL.articleData.row(int.Parse(id));
            }

        }
    }
}