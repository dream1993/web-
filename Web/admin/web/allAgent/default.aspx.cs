using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.allAgent
{
    public partial class _default : System.Web.UI.Page
    {
        public List<DAL.articleData.Value> list=DAL.articleData.table(3);
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}