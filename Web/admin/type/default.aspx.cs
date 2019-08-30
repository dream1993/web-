using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type
{
    public partial class _default : System.Web.UI.Page
    {
        public int pid=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pid = Request["pid"] == null ? 0 : int.Parse(Request["pid"]);
            }
            catch (Exception)
            {
                
            }
        }
    }
}