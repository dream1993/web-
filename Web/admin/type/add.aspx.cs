using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type
{
    public partial class add : System.Web.UI.Page
    {
        public DAL.typeData.Value sv;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int pid = Request["pid"] == null ? 0 : int.Parse(Request["pid"]);
                sv = DAL.typeData.row(pid);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}